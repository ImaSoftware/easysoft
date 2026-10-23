using System.Globalization;
using System.Text.Json;
using Facturacion.Core;
using Microsoft.Data.Sqlite;

namespace Facturacion.Infrastructure;

public sealed class SqliteInvoiceStore : IInvoiceStore
{
    private readonly string connectionString;
    private readonly InvoiceSchema schema;
    public SqliteInvoiceStore(string path, InvoiceSchema schema)
    {
        SQLitePCL.Batteries_V2.Init();
        this.schema = schema;
        Directory.CreateDirectory(Path.GetDirectoryName(Path.GetFullPath(path))!);
        connectionString = new SqliteConnectionStringBuilder { DataSource = path, Pooling = false, DefaultTimeout = 30 }.ToString();
        using var db = Open();
        using var command = db.CreateCommand();
        command.CommandText = """
            PRAGMA journal_mode=WAL;
            CREATE TABLE IF NOT EXISTS sequences(scope TEXT PRIMARY KEY, last_value INTEGER NOT NULL);
            CREATE TABLE IF NOT EXISTS invoices(
              id TEXT PRIMARY KEY, scope TEXT NOT NULL, sequence INTEGER NOT NULL,
              idempotency_key TEXT NOT NULL, reference TEXT NOT NULL, request_hash TEXT NOT NULL,
              state TEXT NOT NULL, due TEXT NOT NULL, record TEXT NOT NULL,
              UNIQUE(scope, sequence), UNIQUE(scope, idempotency_key), UNIQUE(scope, reference));
            CREATE INDEX IF NOT EXISTS ix_due ON invoices(state, due);
            """;
        command.ExecuteNonQuery();
    }
    private SqliteConnection Open()
    {
        var db = new SqliteConnection(connectionString); db.Open();
        using var command = db.CreateCommand(); command.CommandText = "PRAGMA synchronous=FULL;"; command.ExecuteNonQuery();
        return db;
    }
    public InvoiceRecord Create(Issuer issuer, InvoiceRequest request, string idempotencyKey)
    {
        InvoiceBuilder.Text(idempotencyKey, "Idempotency-Key", 100);
        InvoiceBuilder.ValidateIssuer(issuer); InvoiceBuilder.Calculate(request);
        string scope = $"{issuer.Ruc}:1:01:{issuer.Establecimiento}:{issuer.PuntoEmision}";
        string hash = InvoiceBuilder.Fingerprint(issuer, request);
        using var db = Open(); using var tx = db.BeginTransaction(deferred: false);
        using var query = db.CreateCommand(); query.Transaction = tx;
        query.CommandText = "SELECT record FROM invoices WHERE scope=$scope AND (idempotency_key=$key OR reference=$reference)";
        query.Parameters.AddWithValue("$scope", scope); query.Parameters.AddWithValue("$key", idempotencyKey);
        query.Parameters.AddWithValue("$reference", request.Referencia);
        using (var reader = query.ExecuteReader())
        {
            if (reader.Read())
            {
                var previous = JsonSerializer.Deserialize<InvoiceRecord>(reader.GetString(0), JsonDefaults.Options)!;
                if (previous.RequestHash != hash || previous.IdempotencyKey != idempotencyKey) throw new IdempotencyConflictException();
                return previous;
            }
        }
        using var counter = db.CreateCommand(); counter.Transaction = tx;
        counter.CommandText = """
            INSERT INTO sequences(scope,last_value) VALUES($scope,$initial)
            ON CONFLICT(scope) DO UPDATE SET last_value=last_value+1
            RETURNING last_value;
            """;
        counter.Parameters.AddWithValue("$scope", scope); counter.Parameters.AddWithValue("$initial", issuer.PrimerSecuencial);
        long sequence = (long)counter.ExecuteScalar()!;
        string accessKey = InvoiceBuilder.AccessKey(issuer, request.FechaEmision, sequence, InvoiceBuilder.NumericCode());
        string xml = InvoiceBuilder.Build(issuer, request, sequence, accessKey); schema.Validate(xml);
        var now = DateTimeOffset.UtcNow;
        var record = new InvoiceRecord { Id = Guid.NewGuid(), IdempotencyKey = idempotencyKey, RequestHash = hash, Issuer = issuer,
            Request = request, Sequence = sequence, AccessKey = accessKey, UnsignedXml = xml, CreatedAt = now,
            NextAttemptAt = now, State = InvoiceState.Queued, History = [new(now, InvoiceState.Queued, "Solicitud persistida; ambiente PRUEBAS.")] };
        using var insert = db.CreateCommand(); insert.Transaction = tx;
        insert.CommandText = "INSERT INTO invoices VALUES($id,$scope,$seq,$key,$reference,$hash,$state,$due,$record)";
        insert.Parameters.AddWithValue("$id", record.Id.ToString()); insert.Parameters.AddWithValue("$scope", scope);
        insert.Parameters.AddWithValue("$seq", sequence); insert.Parameters.AddWithValue("$key", idempotencyKey);
        insert.Parameters.AddWithValue("$reference", request.Referencia); insert.Parameters.AddWithValue("$hash", hash);
        AddRecordParameters(insert, record); insert.ExecuteNonQuery(); tx.Commit(); return record;
    }
    public InvoiceRecord? Get(Guid id)
    {
        using var db = Open(); using var command = db.CreateCommand();
        command.CommandText = "SELECT record FROM invoices WHERE id=$id"; command.Parameters.AddWithValue("$id", id.ToString());
        var json = command.ExecuteScalar() as string;
        return json is null ? null : JsonSerializer.Deserialize<InvoiceRecord>(json, JsonDefaults.Options);
    }
    public IReadOnlyList<Guid> Due(DateTimeOffset now)
    {
        using var db = Open(); using var command = db.CreateCommand();
        command.CommandText = "SELECT id FROM invoices WHERE state IN ('Queued','Signed','AwaitingAuthorization') AND due <= $now ORDER BY due LIMIT 20";
        command.Parameters.AddWithValue("$now", now.ToUniversalTime().ToString("O", CultureInfo.InvariantCulture));
        using var reader = command.ExecuteReader(); List<Guid> ids = [];
        while (reader.Read()) ids.Add(Guid.Parse(reader.GetString(0))); return ids;
    }
    public IReadOnlyList<InvoiceRecord> Recent()
    {
        using var db = Open(); using var command = db.CreateCommand();
        command.CommandText = "SELECT record FROM invoices ORDER BY rowid DESC LIMIT 100";
        using var reader = command.ExecuteReader(); List<InvoiceRecord> records = [];
        while (reader.Read()) records.Add(JsonSerializer.Deserialize<InvoiceRecord>(reader.GetString(0), JsonDefaults.Options)!);
        return records;
    }
    public void Save(InvoiceRecord record)
    {
        using var db = Open(); using var command = db.CreateCommand();
        command.CommandText = "UPDATE invoices SET state=$state,due=$due,record=$record WHERE id=$id";
        command.Parameters.AddWithValue("$id", record.Id.ToString()); AddRecordParameters(command, record);
        if (command.ExecuteNonQuery() != 1) throw new InvalidOperationException("Comprobante inexistente.");
    }
    private static void AddRecordParameters(SqliteCommand command, InvoiceRecord record)
    {
        command.Parameters.AddWithValue("$state", record.State.ToString());
        command.Parameters.AddWithValue("$due", record.NextAttemptAt.ToUniversalTime().ToString("O", CultureInfo.InvariantCulture));
        command.Parameters.AddWithValue("$record", JsonSerializer.Serialize(record, JsonDefaults.Options));
    }
}
