using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json.Serialization;
using Facturacion.Api;
using Facturacion.Core;
using Facturacion.Infrastructure;

var builder = WebApplication.CreateBuilder(args);
// Certification console, loopback only. Remote/multi-tenant hosting is a separate deployment concern.
builder.WebHost.UseUrls("http://127.0.0.1:5088");
builder.WebHost.ConfigureKestrel(o => o.Limits.MaxRequestBodySize = 1_000_000);
builder.Services.ConfigureHttpJsonOptions(o =>
{
    o.SerializerOptions.UnmappedMemberHandling = JsonUnmappedMemberHandling.Disallow;
    o.SerializerOptions.Converters.Add(new JsonStringEnumConverter());
});
string dataPath = Path.GetFullPath(builder.Configuration["Sri:DataPath"] ?? Path.Combine(builder.Environment.ContentRootPath, "data"));
Directory.CreateDirectory(dataPath);
// A second host cannot run a second worker against this store, even from another process.
using var hostLock = new FileStream(Path.Combine(dataPath, "host.lock"), FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.None);
string key = builder.Configuration["Sri:ApiKey"] ?? "";
if (key.Length < 32) throw new InvalidOperationException("Defina Sri__ApiKey con al menos 32 caracteres o inicie con tools/Start-Pruebas.ps1.");
byte[] expectedKeyHash = SHA256.HashData(Encoding.UTF8.GetBytes(key));
var runtime = new RuntimeConfiguration(Path.Combine(dataPath, "issuer.json"));
var schema = new InvoiceSchema(Path.Combine(AppContext.BaseDirectory, "Schemas"));
builder.Services.AddSingleton(runtime); builder.Services.AddSingleton(schema);
builder.Services.AddSingleton<CertificateVault>();
builder.Services.AddSingleton<IInvoiceSigner>(sp => sp.GetRequiredService<CertificateVault>());
builder.Services.AddSingleton(new SqliteInvoiceStore(Path.Combine(dataPath, "invoices.db"), schema));
builder.Services.AddSingleton<IInvoiceStore>(sp => sp.GetRequiredService<SqliteInvoiceStore>());
builder.Services.AddHttpClient<ISriClient, SriClient>(client => client.Timeout = TimeSpan.FromSeconds(30))
    .ConfigurePrimaryHttpMessageHandler(() => new HttpClientHandler { AllowAutoRedirect = false });
builder.Services.AddSingleton<InvoiceProcessor>(); builder.Services.AddHostedService<EmissionWorker>();
var app = builder.Build();
app.Use(async (context, next) =>
{
    context.Response.Headers["Cache-Control"] = "no-store";
    context.Response.Headers["X-Content-Type-Options"] = "nosniff";
    context.Response.Headers["Referrer-Policy"] = "no-referrer";
    context.Response.Headers["Content-Security-Policy"] = "default-src 'self'; script-src 'self'; style-src 'self'; connect-src 'self'; frame-ancestors 'none'; base-uri 'none'; form-action 'self'";
    if (context.Connection.RemoteIpAddress is not { } ip || !IPAddress.IsLoopback(ip)
        || context.Request.Host.Host != "127.0.0.1") { context.Response.StatusCode = 403; return; }
    if (context.Request.Path.StartsWithSegments("/api"))
    {
        string? supplied = context.Request.Headers.Authorization.FirstOrDefault();
        if (supplied is null || !supplied.StartsWith("Bearer ", StringComparison.Ordinal)
            || !CryptographicOperations.FixedTimeEquals(expectedKeyHash, SHA256.HashData(Encoding.UTF8.GetBytes(supplied[7..]))))
        { context.Response.StatusCode = 401; return; }
    }
    try { await next(); }
    catch (InvoiceValidationException e) { await Results.Problem(e.Message, statusCode: 400).ExecuteAsync(context); }
    catch (IdempotencyConflictException e) { await Results.Problem(e.Message, statusCode: 409).ExecuteAsync(context); }
});
app.UseDefaultFiles(); app.UseStaticFiles();
app.MapGet("/health", () => new { service = "Facturación SRI", environment = "PRUEBAS", status = "running" });
app.MapGet("/api/configuracion", (CertificateVault vault) => new { emisor = runtime.Current, firma = vault.Status, ambiente = "PRUEBAS", produccionHabilitada = false });
app.MapPut("/api/configuracion/emisor", (Issuer issuer) =>
{
    runtime.Save(issuer); return Results.Ok(new { saved = true });
});
app.MapPost("/api/configuracion/firma", (CertificateInput input, CertificateVault vault) =>
{
    vault.Load(input.Ruta, input.Password); return Results.Ok(vault.Status);
});
app.MapPost("/api/facturas", (InvoiceRequest input, HttpRequest http, IInvoiceStore store, CertificateVault vault) =>
{
    if (!vault.Ready) return Results.Problem("Configure el emisor y cargue su firma vigente antes de emitir.", statusCode: 409);
    var issuer = runtime.Current ?? throw new InvoiceValidationException("Configure el emisor.");
    // Avoid generating an already stale/future certification invoice due to host timezone differences.
    var today = DateOnly.FromDateTime(DateTimeOffset.UtcNow.ToOffset(TimeSpan.FromHours(-5)).DateTime);
    if (input.FechaEmision != today) throw new InvoiceValidationException("Para este hito use la fecha actual de Ecuador continental.");
    var record = store.Create(issuer, input, http.Headers["Idempotency-Key"].ToString());
    return Results.Accepted($"/api/comprobantes/{record.Id}", View(record));
});
app.MapGet("/api/comprobantes", (SqliteInvoiceStore store) => store.Recent().Select(View));
app.MapGet("/api/comprobantes/{id:guid}", (Guid id, IInvoiceStore store) => store.Get(id) is { } record ? Results.Ok(View(record)) : Results.NotFound());
app.MapPost("/api/comprobantes/{id:guid}/reactivar", async (Guid id, InvoiceProcessor processor, CancellationToken ct) =>
    Results.Ok(View(await processor.ResumeAsync(id, ct))));
app.MapGet("/api/comprobantes/{id:guid}/xml/{kind}", (Guid id, string kind, IInvoiceStore store) =>
{
    var record = store.Get(id); if (record is null) return Results.NotFound();
    string? xml = kind switch { "generado" => record.UnsignedXml, "firmado" => record.SignedXml, "autorizado" => record.AuthorizedXml, _ => null };
    return xml is null ? Results.NotFound() : Results.File(Encoding.UTF8.GetBytes(xml), "application/xml", $"{record.AccessKey}-{kind}.xml");
});
app.MapGet("/api/comprobantes/{id:guid}/evidencia", (Guid id, IInvoiceStore store) =>
{
    var record = store.Get(id); return record is null ? Results.NotFound() : Results.Json(record.Exchanges);
});
app.Run();

static object View(InvoiceRecord r) => new { r.Id, r.State, r.AccessKey, r.Sequence, r.Request.Referencia,
    r.Request.FechaEmision, total = InvoiceBuilder.Calculate(r.Request).Total, r.AuthorizationNumber, r.CreatedAt, r.NextAttemptAt,
    r.Attempts, r.LastError, r.Messages, r.History, hasSignedXml = r.SignedXml is not null, hasAuthorizedXml = r.AuthorizedXml is not null };

public sealed record CertificateInput(string Ruta, string Password);

public sealed class EmissionWorker(IInvoiceStore store, InvoiceProcessor processor, CertificateVault vault, ILogger<EmissionWorker> logger) : BackgroundService
{
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            try
            {
                foreach (var id in store.Due(DateTimeOffset.UtcNow))
                {
                    if (stoppingToken.IsCancellationRequested) break;
                    // Signed/uncertain invoices can be reconciled even before the private key is reloaded after restart.
                    if (store.Get(id)?.State == InvoiceState.Queued && !vault.Ready) continue;
                    await processor.ProcessAsync(id, stoppingToken);
                }
            }
            catch (OperationCanceledException) when (stoppingToken.IsCancellationRequested) { break; }
            catch (Exception) { logger.LogError("El procesador no completó el ciclo. Se reintentará conservando el estado persistido."); }
            try { await Task.Delay(TimeSpan.FromSeconds(2), stoppingToken); }
            catch (OperationCanceledException) { break; }
        }
    }
}
