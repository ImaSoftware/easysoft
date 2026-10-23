using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using Facturacion.Core;

namespace Facturacion.Tests;

internal static class Fixtures
{
    public static Issuer Issuer => new() { Ruc = "1792146739001", RazonSocial = "EMISOR SINTÉTICO & PRUEBA", DirMatriz = "Dirección matriz",
        DirEstablecimiento = "Dirección establecimiento", Establecimiento = "001", PuntoEmision = "001" };
    public static InvoiceRequest Invoice(string reference = "TEST-001") => new(new DateOnly(2026, 10, 22), reference,
        new Buyer("07", "9999999999999", "CONSUMIDOR FINAL"), [new("TEST", "Servicio sintético & prueba <XML>", 1, 1, 0, "4", 15)], [new("01", 1.15m)]);
    public static InvoiceSchema Schema() => new(Path.Combine(AppContext.BaseDirectory, "Schemas"));
    public static string Xml()
    {
        var request = Invoice(); return InvoiceBuilder.Build(Issuer, request, 1, InvoiceBuilder.AccessKey(Issuer, request.FechaEmision, 1, "12345678"));
    }
    public static X509Certificate2 Certificate()
    {
        using var rsa = RSA.Create(2048);
        var request = new CertificateRequest("CN=Certificado sintetico - NO VALIDO SRI", rsa, HashAlgorithmName.SHA256, RSASignaturePadding.Pkcs1);
        request.CertificateExtensions.Add(new X509KeyUsageExtension(X509KeyUsageFlags.DigitalSignature | X509KeyUsageFlags.NonRepudiation, true));
        return request.CreateSelfSigned(DateTimeOffset.UtcNow.AddDays(-1), DateTimeOffset.UtcNow.AddDays(7));
    }
    public static string Soap(string payload) => "<s:Envelope xmlns:s=\"http://schemas.xmlsoap.org/soap/envelope/\"><s:Body>"+payload+"</s:Body></s:Envelope>";
    public static string Reception(string state = "RECIBIDA", string code = "") => Soap($"<r:validarComprobanteResponse xmlns:r=\"http://ec.gob.sri.ws.recepcion\"><RespuestaRecepcionComprobante><estado>{state}</estado><comprobantes>"
        +(code.Length==0?"":$"<comprobante><mensajes><mensaje><identificador>{code}</identificador><mensaje>Mensaje sintético</mensaje><tipo>ERROR</tipo></mensaje></mensajes></comprobante>")
        +"</comprobantes></RespuestaRecepcionComprobante></r:validarComprobanteResponse>");
    public static string Authorization(string key, string? invoice = null, string state = "AUTORIZADO") => Soap(
        "<a:autorizacionComprobanteResponse xmlns:a=\"http://ec.gob.sri.ws.autorizacion\"><RespuestaAutorizacionComprobante><claveAccesoConsultada>"+key+"</claveAccesoConsultada><numeroComprobantes>"
        +(invoice is null?"0":"1")+"</numeroComprobantes><autorizaciones>"+(invoice is null?"":"<autorizacion><estado>"+state+"</estado><numeroAutorizacion>"+key
        +"</numeroAutorizacion><fechaAutorizacion>2026-10-22T10:00:00-05:00</fechaAutorizacion><ambiente>PRUEBAS</ambiente><comprobante><![CDATA["+invoice+"]]></comprobante><mensajes/></autorizacion>")
        +"</autorizaciones></RespuestaAutorizacionComprobante></a:autorizacionComprobanteResponse>");
}
