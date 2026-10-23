using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text.Json;
using Facturacion.Core;

namespace Facturacion.Api;

public sealed class RuntimeConfiguration
{
    private readonly object gate = new();
    private readonly string issuerFile;
    private Issuer? issuer;
    public RuntimeConfiguration(string issuerFile)
    {
        this.issuerFile = issuerFile;
        if (File.Exists(issuerFile)) issuer = JsonSerializer.Deserialize<Issuer>(File.ReadAllText(issuerFile), JsonDefaults.Options);
        if (issuer is not null) InvoiceBuilder.ValidateIssuer(issuer);
    }
    public Issuer? Current { get { lock (gate) return issuer; } }
    public void Save(Issuer value)
    {
        InvoiceBuilder.ValidateIssuer(value);
        lock (gate)
        {
            Directory.CreateDirectory(Path.GetDirectoryName(issuerFile)!);
            string temp = issuerFile + ".tmp";
            File.WriteAllText(temp, JsonSerializer.Serialize(value, JsonDefaults.Options));
            File.Move(temp, issuerFile, overwrite: true); issuer = value;
        }
    }
}

public sealed class CertificateVault(RuntimeConfiguration settings) : IInvoiceSigner, IDisposable
{
    private readonly object gate = new();
    private X509Certificate2? certificate;
    private string? ruc;
    public object Status { get { lock (gate) return new { loaded = certificate is not null && ruc == settings.Current?.Ruc,
        expiresAt = certificate is null ? (DateTime?)null : certificate.NotAfter.ToUniversalTime() }; } }
    public bool Ready { get { lock (gate) return certificate is not null && ruc == settings.Current?.Ruc && certificate.NotAfter.ToUniversalTime() > DateTime.UtcNow; } }
    public void Load(string path, string password)
    {
        var issuer = settings.Current ?? throw new InvoiceValidationException("Configure primero el emisor.");
        if (!Path.IsPathFullyQualified(path) || !new[] { ".p12", ".pfx" }.Contains(Path.GetExtension(path).ToLowerInvariant()))
            throw new InvoiceValidationException("Indique la ruta absoluta de un archivo .p12/.pfx.");
        X509Certificate2? candidate = null;
        try
        {
            candidate = X509CertificateLoader.LoadPkcs12FromFile(path, password, X509KeyStorageFlags.EphemeralKeySet);
            using var rsa = candidate.GetRSAPrivateKey();
            if (rsa is null || rsa.KeySize < 2048 || DateTime.UtcNow < candidate.NotBefore.ToUniversalTime() || DateTime.UtcNow > candidate.NotAfter.ToUniversalTime())
                throw new InvoiceValidationException("El certificado debe estar vigente y tener clave privada RSA de al menos 2048 bits.");
            var usage = candidate.Extensions.OfType<X509KeyUsageExtension>().FirstOrDefault();
            if (usage is not null && (usage.KeyUsages & (X509KeyUsageFlags.DigitalSignature | X509KeyUsageFlags.NonRepudiation)) == 0)
                throw new InvoiceValidationException("El certificado no permite firma digital.");
            lock (gate) { certificate?.Dispose(); certificate = candidate; ruc = issuer.Ruc; candidate = null; }
        }
        catch (Exception e) when (e is CryptographicException or IOException or UnauthorizedAccessException)
        { throw new InvoiceValidationException("No se pudo abrir la firma. Revise archivo, contraseña y permisos locales."); }
        finally { candidate?.Dispose(); }
    }
    public string Sign(string xml)
    {
        lock (gate)
        {
            string? xmlRuc = XmlSafety.Load(xml).SelectSingleNode("/factura/infoTributaria/ruc")?.InnerText;
            if (certificate is null || xmlRuc != ruc) throw new InvoiceValidationException("Cargue la firma del emisor correspondiente.");
            return new XadesSigner(certificate).Sign(xml);
        }
    }
    public void Dispose() { lock (gate) certificate?.Dispose(); }
}
