using System.Text.Json;
using System.Text.Json.Serialization;

namespace Facturacion.Core;

public static class JsonDefaults
{
    public static readonly JsonSerializerOptions Options = new(JsonSerializerDefaults.Web)
    {
        UnmappedMemberHandling = JsonUnmappedMemberHandling.Disallow,
        Converters = { new JsonStringEnumConverter() }
    };
}

public sealed record Issuer
{
    public string Ruc { get; init; } = "";
    public string RazonSocial { get; init; } = "";
    public string? NombreComercial { get; init; }
    public string DirMatriz { get; init; } = "";
    public string DirEstablecimiento { get; init; } = "";
    public string Establecimiento { get; init; } = "001";
    public string PuntoEmision { get; init; } = "001";
    public bool ObligadoContabilidad { get; init; }
    public string? ContribuyenteEspecial { get; init; }
    public string? AgenteRetencion { get; init; }
    public string? ContribuyenteRimpe { get; init; }
    public string? RucProveedor { get; init; }
    public long PrimerSecuencial { get; init; } = 1;
}

public sealed record Buyer(string TipoIdentificacion, string Identificacion, string RazonSocial, string? Direccion = null);
public sealed record InvoiceLine(string Codigo, string Descripcion, decimal Cantidad, decimal PrecioUnitario,
    decimal Descuento, string CodigoIva, decimal TarifaIva, string? CodigoAuxiliar = null);
public sealed record Payment(string FormaPago, decimal Total, decimal? Plazo = null, string? UnidadTiempo = null);
public sealed record AdditionalField(string Nombre, string Valor);
public sealed record InvoiceRequest(DateOnly FechaEmision, string Referencia, Buyer Comprador, InvoiceLine[] Detalles,
    Payment[] Pagos, decimal Propina = 0, AdditionalField[]? InformacionAdicional = null);
public sealed record CalculatedLine(InvoiceLine Input, decimal Base, decimal Iva);
public sealed record InvoiceTotals(CalculatedLine[] Lines, decimal Subtotal, decimal Descuento, decimal Iva, decimal Total);

public enum InvoiceState { Queued, Signed, AwaitingAuthorization, Authorized, Rejected, LocalError, NeedsAttention }
public sealed record SriMessage(string Identificador, string Mensaje, string? InformacionAdicional, string? Tipo);
public sealed record InvoiceEvent(DateTimeOffset At, InvoiceState State, string Detail);
public sealed record InvoiceRecord
{
    public Guid Id { get; init; }
    public string IdempotencyKey { get; init; } = "";
    public string RequestHash { get; init; } = "";
    public required Issuer Issuer { get; init; }
    public required InvoiceRequest Request { get; init; }
    public long Sequence { get; init; }
    public string AccessKey { get; init; } = "";
    public InvoiceState State { get; set; }
    public string UnsignedXml { get; init; } = "";
    public string? SignedXml { get; set; }
    public string? AuthorizedXml { get; set; }
    public string? AuthorizationNumber { get; set; }
    public int Attempts { get; set; }
    public DateTimeOffset CreatedAt { get; init; }
    public DateTimeOffset NextAttemptAt { get; set; }
    public string? LastError { get; set; }
    public List<SriMessage> Messages { get; set; } = [];
    public List<InvoiceEvent> History { get; init; } = [];
    public List<SriExchange> Exchanges { get; init; } = [];
}
public sealed record SriExchange(DateTimeOffset At, string Operation, string Response);

public sealed class InvoiceValidationException(string message) : Exception(message);
public sealed class IdempotencyConflictException() : Exception("La clave de idempotencia o referencia ya existe con otros datos.");

public interface IInvoiceStore
{
    InvoiceRecord Create(Issuer issuer, InvoiceRequest request, string idempotencyKey);
    InvoiceRecord? Get(Guid id);
    IReadOnlyList<Guid> Due(DateTimeOffset now);
    void Save(InvoiceRecord record);
}
public interface IInvoiceSigner { string Sign(string xml); }
public interface ISriClient
{
    Task<ReceptionResult> ReceiveAsync(string signedXml, CancellationToken ct);
    Task<AuthorizationResult> AuthorizeAsync(string accessKey, CancellationToken ct);
}
public sealed record ReceptionResult(string State, List<SriMessage> Messages, string RawXml);
public sealed record AuthorizationResult(string State, string? Number, string? AuthorizedXml,
    List<SriMessage> Messages, string RawXml);
