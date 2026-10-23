using Facturacion.Core;

namespace Facturacion.Infrastructure;

/// <summary>One worker per database. The API host holds an OS file lock for the lifetime of the worker.</summary>
public sealed class InvoiceProcessor(IInvoiceStore store, IInvoiceSigner signer, InvoiceSchema schema, ISriClient sri, TimeProvider? clock = null)
{
    private readonly SemaphoreSlim gate = new(1, 1);
    private DateTimeOffset Now => (clock ?? TimeProvider.System).GetUtcNow();
    private void Transition(InvoiceRecord r, InvoiceState state, string detail)
    {
        r.State = state; r.History.Add(new(Now, state, detail)); store.Save(r);
    }
    public async Task ProcessAsync(Guid id, CancellationToken ct)
    {
        await gate.WaitAsync(ct);
        try { await ProcessCoreAsync(id, ct); }
        finally { gate.Release(); }
    }
    public async Task<InvoiceRecord> ResumeAsync(Guid id, CancellationToken ct)
    {
        await gate.WaitAsync(ct);
        try
        {
            var r = store.Get(id) ?? throw new InvoiceValidationException("Comprobante inexistente.");
            if (r.State is not (InvoiceState.LocalError or InvoiceState.NeedsAttention))
                throw new InvoiceValidationException("Solo puede reactivar un error local o reanudar consultas que requieren revisión.");
            r.Attempts = 0; r.NextAttemptAt = Now; r.LastError = null;
            Transition(r, r.State == InvoiceState.LocalError ? InvoiceState.Queued : InvoiceState.AwaitingAuthorization,
                "Reactivación manual: se conserva la clave y el secuencial. No se reenvía una recepción incierta.");
            return r;
        }
        finally { gate.Release(); }
    }
    private async Task ProcessCoreAsync(Guid id, CancellationToken ct)
    {
        var r = store.Get(id) ?? throw new InvalidOperationException("Comprobante inexistente.");
        if (r.State is not (InvoiceState.Queued or InvoiceState.Signed or InvoiceState.AwaitingAuthorization)) return;
        try
        {
            if (r.State == InvoiceState.Queued)
            {
                schema.Validate(r.UnsignedXml);
                r.SignedXml = signer.Sign(r.UnsignedXml); schema.Validate(r.SignedXml);
                Transition(r, InvoiceState.Signed, "XML firmado y verificado localmente; todavía no enviado.");
            }
            r.Attempts++;
            r.NextAttemptAt = Now.AddSeconds(Math.Min(300, 5 * Math.Pow(2, Math.Min(r.Attempts, 6))));
            if (r.State == InvoiceState.Signed)
            {
                // Commit before I/O. A crash from this point only polls authorization; it never blindly resubmits.
                Transition(r, InvoiceState.AwaitingAuthorization, "Inicio de recepción; ante respuesta incierta se consultará la misma clave.");
                var reception = await sri.ReceiveAsync(r.SignedXml!, ct);
                r.Exchanges.Add(new(Now, "recepcion", reception.RawXml)); r.Messages = reception.Messages;
                if (reception.State == "DEVUELTA" && !reception.Messages.Any(m => m.Identificador is "43" or "70"))
                {
                    Transition(r, InvoiceState.Rejected, "Comprobante devuelto por el SRI; revisar mensajes."); return;
                }
                store.Save(r);
            }
            var authorization = await sri.AuthorizeAsync(r.AccessKey, ct);
            r.Exchanges.Add(new(Now, "autorizacion", authorization.RawXml)); r.Messages = authorization.Messages;
            r.LastError = null;
            if (authorization.State == "AUTORIZADO")
            {
                // The returned invoice must be exactly the signed payload we sent (apart from XML serialization).
                var returned = System.Xml.Linq.XDocument.Parse(authorization.AuthorizedXml!).Root!.Element("comprobante")!.Value;
                if (!System.Xml.Linq.XNode.DeepEquals(System.Xml.Linq.XDocument.Parse(returned, System.Xml.Linq.LoadOptions.PreserveWhitespace),
                    System.Xml.Linq.XDocument.Parse(r.SignedXml!, System.Xml.Linq.LoadOptions.PreserveWhitespace)))
                    throw new SriProtocolException("El XML autorizado difiere del XML firmado enviado.", authorization.RawXml);
                r.AuthorizationNumber = authorization.Number; r.AuthorizedXml = authorization.AuthorizedXml;
                Transition(r, InvoiceState.Authorized, "Factura AUTORIZADA en ambiente PRUEBAS del SRI.");
            }
            else if (authorization.State == "NO AUTORIZADO") Transition(r, InvoiceState.Rejected, "Factura no autorizada; revisar mensajes del SRI.");
            else if (Now - r.CreatedAt >= TimeSpan.FromHours(24) || r.Attempts >= 30)
                Transition(r, InvoiceState.NeedsAttention, "Sin autorización definitiva. Revisión manual requerida; no se genera otra clave ni se reenvía.");
            else store.Save(r);
        }
        catch (Exception e) when (e is HttpRequestException or TaskCanceledException or SriProtocolException)
        {
            r.LastError = e is SriProtocolException ? e.Message : "No se obtuvo respuesta del SRI. Se consultará la misma clave sin duplicar el envío.";
            if (e is SriProtocolException protocol && protocol.RawXml.Length > 0) r.Exchanges.Add(new(Now, "error-protocolo", protocol.RawXml));
            if (r.Attempts >= 30 || Now - r.CreatedAt >= TimeSpan.FromHours(24)) Transition(r, InvoiceState.NeedsAttention, r.LastError);
            else store.Save(r);
        }
        catch (Exception e) when (e is InvoiceValidationException or System.Security.Cryptography.CryptographicException)
        {
            r.LastError = "Error local de validación o firma: " + e.Message;
            Transition(r, InvoiceState.LocalError, r.LastError);
        }
    }
}
