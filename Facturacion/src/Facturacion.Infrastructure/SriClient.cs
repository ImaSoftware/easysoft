using System.Text;
using System.Xml;
using System.Xml.Linq;
using Facturacion.Core;

namespace Facturacion.Infrastructure;

public sealed class SriProtocolException(string message, string rawXml) : Exception(message)
{
    public string RawXml { get; } = rawXml;
}

public sealed class SriClient(HttpClient http) : ISriClient
{
    public const string ReceptionUrl = "https://celcer.sri.gob.ec/comprobantes-electronicos-ws/RecepcionComprobantesOffline";
    public const string AuthorizationUrl = "https://celcer.sri.gob.ec/comprobantes-electronicos-ws/AutorizacionComprobantesOffline";
    private const string Soap = "http://schemas.xmlsoap.org/soap/envelope/";
    public async Task<ReceptionResult> ReceiveAsync(string signedXml, CancellationToken ct)
    {
        var invoice = XmlSafety.Load(signedXml);
        if (invoice.SelectSingleNode("/factura/infoTributaria/ambiente")?.InnerText != "1")
            throw new InvoiceValidationException("Solo se permite ambiente de pruebas (1).");
        XNamespace ns = "http://ec.gob.sri.ws.recepcion";
        string raw = await SendAsync(ReceptionUrl, new XElement(ns + "validarComprobante",
            new XElement("xml", Convert.ToBase64String(Encoding.UTF8.GetBytes(signedXml)))), ct);
        return ParseReception(raw);
    }
    public async Task<AuthorizationResult> AuthorizeAsync(string accessKey, CancellationToken ct)
    {
        if (!InvoiceBuilder.Digits(accessKey, 49) || accessKey[23] != '1' || InvoiceBuilder.CheckDigit(accessKey[..48]) != accessKey[48] - '0')
            throw new InvoiceValidationException("Clave de acceso de pruebas inválida.");
        XNamespace ns = "http://ec.gob.sri.ws.autorizacion";
        string raw = await SendAsync(AuthorizationUrl, new XElement(ns + "autorizacionComprobante", new XElement("claveAccesoComprobante", accessKey)), ct);
        return ParseAuthorization(raw, accessKey);
    }
    private async Task<string> SendAsync(string url, XElement operation, CancellationToken ct)
    {
        XNamespace soap = Soap;
        string envelope = new XElement(soap + "Envelope", new XAttribute(XNamespace.Xmlns + "soap", soap), new XElement(soap + "Body", operation)).ToString(SaveOptions.DisableFormatting);
        using var request = new HttpRequestMessage(HttpMethod.Post, url) { Content = new StringContent(envelope, Encoding.UTF8, "text/xml") };
        request.Headers.Add("SOAPAction", "\"\"");
        using var response = await http.SendAsync(request, HttpCompletionOption.ResponseHeadersRead, ct);
        await using var input = await response.Content.ReadAsStreamAsync(ct);
        using var output = new MemoryStream(); byte[] buffer = new byte[8192]; int length;
        while ((length = await input.ReadAsync(buffer, ct)) > 0)
        {
            if (output.Length + length > 4_000_000) throw new SriProtocolException("Respuesta del SRI demasiado grande.", "");
            output.Write(buffer, 0, length);
        }
        string raw = Encoding.UTF8.GetString(output.ToArray());
        if (!response.IsSuccessStatusCode) throw new SriProtocolException($"SRI HTTP {(int)response.StatusCode}.", raw);
        return raw;
    }
    private static XElement Payload(string raw, string expected)
    {
        try
        {
            var doc = XDocument.Parse(XmlSafety.Load(raw).OuterXml, LoadOptions.PreserveWhitespace);
            XNamespace soap = Soap;
            var body = doc.Root?.Name == soap + "Envelope" ? doc.Root.Element(soap + "Body") : null;
            if (body is null || body.Elements().Count() != 1 || body.Elements().Any(x => x.Name.LocalName == "Fault"))
                throw new SriProtocolException("Respuesta SOAP inválida o Fault del SRI.", raw);
            return body.Descendants().SingleOrDefault(x => x.Name.LocalName == expected)
                ?? throw new SriProtocolException("No se encontró la respuesta esperada del SRI.", raw);
        }
        catch (Exception e) when (e is XmlException or InvalidOperationException)
        { throw new SriProtocolException("Respuesta XML del SRI inválida.", raw); }
    }
    private static string? Child(XElement node, string name) => node.Elements().FirstOrDefault(x => x.Name.LocalName == name)?.Value.Trim();
    private static List<SriMessage> Messages(XElement node) => node.Descendants().Where(x => x.Name.LocalName == "mensaje" && x.Elements().Any(e => e.Name.LocalName == "identificador"))
        .Select(m => new SriMessage(Child(m, "identificador") ?? "", Child(m, "mensaje") ?? "", Child(m, "informacionAdicional"), Child(m, "tipo"))).ToList();
    public static ReceptionResult ParseReception(string raw)
    {
        var payload = Payload(raw, "RespuestaRecepcionComprobante");
        string state = Child(payload, "estado") ?? "";
        if (state is not ("RECIBIDA" or "DEVUELTA")) throw new SriProtocolException("Estado de recepción desconocido.", raw);
        return new(state, Messages(payload), raw);
    }
    public static AuthorizationResult ParseAuthorization(string raw, string accessKey)
    {
        var payload = Payload(raw, "RespuestaAutorizacionComprobante");
        if (Child(payload, "claveAccesoConsultada") != accessKey) throw new SriProtocolException("La respuesta corresponde a otra clave.", raw);
        var auths = payload.Descendants().Where(x => x.Name.LocalName == "autorizacion").ToArray();
        if (auths.Length == 0) return new("PENDIENTE", null, null, Messages(payload), raw);
        var auth = auths.FirstOrDefault(x => Child(x, "estado") == "AUTORIZADO") ?? auths[^1];
        string state = Child(auth, "estado") ?? "";
        if (state == "EN PROCESAMIENTO") return new("PENDIENTE", null, null, Messages(auth), raw);
        if (state is not ("AUTORIZADO" or "NO AUTORIZADO")) throw new SriProtocolException("Estado de autorización desconocido.", raw);
        if (state == "NO AUTORIZADO") return new(state, null, null, Messages(auth), raw);
        string? number = Child(auth, "numeroAutorizacion"), invoice = Child(auth, "comprobante"), date = Child(auth, "fechaAutorizacion");
        if (number != accessKey || invoice is null || date is null || Child(auth, "ambiente") != "PRUEBAS")
            throw new SriProtocolException("Autorización incompleta o de otro ambiente.", raw);
        var signed = XmlSafety.Load(invoice);
        if (signed.SelectSingleNode("/factura/infoTributaria/claveAcceso")?.InnerText != accessKey
            || signed.SelectSingleNode("/factura/infoTributaria/ambiente")?.InnerText != "1")
            throw new SriProtocolException("El comprobante autorizado no coincide con la solicitud.", raw);
        var authorized = new XElement("autorizacion", new XElement("estado", state), new XElement("numeroAutorizacion", number),
            new XElement("fechaAutorizacion", date), new XElement("ambiente", "PRUEBAS"), new XElement("comprobante", new XCData(invoice)),
            new XElement("mensajes"));
        return new(state, number, "<?xml version=\"1.0\" encoding=\"utf-8\"?>" + authorized.ToString(SaveOptions.DisableFormatting), Messages(auth), raw);
    }
}
