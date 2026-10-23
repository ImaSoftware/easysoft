using System.Globalization;
using System.Numerics;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Security.Cryptography.Xml;
using System.Xml;

namespace Facturacion.Core;

/// <summary>SRI XAdES-BES 1.3.2, enveloped; uses public canonicalization and RSA APIs only.</summary>
public sealed class XadesSigner(X509Certificate2 certificate, TimeProvider? clock = null) : IInvoiceSigner
{
    public const string Ds = SignedXml.XmlDsigNamespaceUrl;
    public const string Etsi = "http://uri.etsi.org/01903/v1.3.2#";
    public const string PropertiesType = "http://uri.etsi.org/01903#SignedProperties";
    public string Sign(string xml)
    {
        var now = (clock ?? TimeProvider.System).GetUtcNow();
        if (!certificate.HasPrivateKey || now < certificate.NotBefore.ToUniversalTime() || now > certificate.NotAfter.ToUniversalTime())
            throw new InvoiceValidationException("El certificado no tiene clave privada o no está vigente.");
        using var rsa = certificate.GetRSAPrivateKey() ?? throw new InvoiceValidationException("Se requiere certificado RSA.");
        if (rsa.KeySize < 2048) throw new InvoiceValidationException("Se requiere una clave RSA de al menos 2048 bits.");
        var doc = XmlSafety.Load(xml);
        if (doc.DocumentElement?.GetAttribute("id") != "comprobante" || doc.GetElementsByTagName("Signature", Ds).Count != 0)
            throw new InvoiceValidationException("Documento de entrada inválido o ya firmado.");
        string suffix = Guid.NewGuid().ToString("N"), signatureId = "Signature-" + suffix,
            propertiesId = "SignedProperties-" + suffix, keyId = "KeyInfo-" + suffix, referenceId = "Reference-" + suffix;
        XmlElement Node(string name, string ns, XmlNode parent, string? value = null)
        {
            var node = doc.CreateElement(ns == Ds ? "ds" : "etsi", name, ns);
            if (value is not null) node.InnerText = value;
            parent.AppendChild(node); return node;
        }
        var sig = Node("Signature", Ds, doc.DocumentElement!);
        sig.SetAttribute("Id", signatureId);
        sig.SetAttribute("xmlns:ds", Ds); sig.SetAttribute("xmlns:etsi", Etsi);
        var signedInfo = Node("SignedInfo", Ds, sig);
        signedInfo.SetAttribute("xmlns:ds", Ds); signedInfo.SetAttribute("xmlns:etsi", Etsi);
        Node("CanonicalizationMethod", Ds, signedInfo).SetAttribute("Algorithm", SignedXml.XmlDsigC14NTransformUrl);
        // The SRI 2.34 profile explicitly specifies RSA-SHA1. Do not change independently of the SRI profile.
        Node("SignatureMethod", Ds, signedInfo).SetAttribute("Algorithm", SignedXml.XmlDsigRSASHA1Url);
        XmlElement Reference(string uri, string? type, string? id, bool enveloped)
        {
            var reference = Node("Reference", Ds, signedInfo); reference.SetAttribute("URI", uri);
            if (type is not null) reference.SetAttribute("Type", type);
            if (id is not null) reference.SetAttribute("Id", id);
            var transforms = Node("Transforms", Ds, reference);
            if (enveloped) Node("Transform", Ds, transforms).SetAttribute("Algorithm", SignedXml.XmlDsigEnvelopedSignatureTransformUrl);
            Node("Transform", Ds, transforms).SetAttribute("Algorithm", SignedXml.XmlDsigC14NTransformUrl);
            Node("DigestMethod", Ds, reference).SetAttribute("Algorithm", SignedXml.XmlDsigSHA1Url);
            return Node("DigestValue", Ds, reference);
        }
        var documentDigest = Reference("#comprobante", null, referenceId, true);
        var propsDigest = Reference("#" + propertiesId, PropertiesType, null, false);
        var keyDigest = Reference("#" + keyId, null, null, false);
        var signatureValue = Node("SignatureValue", Ds, sig);
        var keyInfo = Node("KeyInfo", Ds, sig); keyInfo.SetAttribute("Id", keyId);
        Node("X509Certificate", Ds, Node("X509Data", Ds, keyInfo), Convert.ToBase64String(certificate.RawData));
        var publicKey = rsa.ExportParameters(false);
        var rsaValue = Node("RSAKeyValue", Ds, Node("KeyValue", Ds, keyInfo));
        Node("Modulus", Ds, rsaValue, Convert.ToBase64String(publicKey.Modulus!));
        Node("Exponent", Ds, rsaValue, Convert.ToBase64String(publicKey.Exponent!));
        var obj = Node("Object", Ds, sig);
        var qualifying = Node("QualifyingProperties", Etsi, obj); qualifying.SetAttribute("Target", "#" + signatureId);
        var props = Node("SignedProperties", Etsi, qualifying); props.SetAttribute("Id", propertiesId);
        var signedProps = Node("SignedSignatureProperties", Etsi, props);
        Node("SigningTime", Etsi, signedProps, now.ToString("yyyy-MM-ddTHH:mm:sszzz", CultureInfo.InvariantCulture));
        var cert = Node("Cert", Etsi, Node("SigningCertificate", Etsi, signedProps));
        var certDigest = Node("CertDigest", Etsi, cert);
        Node("DigestMethod", Ds, certDigest).SetAttribute("Algorithm", SignedXml.XmlDsigSHA1Url);
        Node("DigestValue", Ds, certDigest, Convert.ToBase64String(SHA1.HashData(certificate.RawData)));
        var serial = Node("IssuerSerial", Etsi, cert);
        Node("X509IssuerName", Ds, serial, certificate.Issuer);
        Node("X509SerialNumber", Ds, serial, new BigInteger(certificate.GetSerialNumber(), isUnsigned: true).ToString(CultureInfo.InvariantCulture));
        var format = Node("DataObjectFormat", Etsi, Node("SignedDataObjectProperties", Etsi, props));
        format.SetAttribute("ObjectReference", "#" + referenceId);
        Node("Description", Etsi, format, "contenido comprobante"); Node("MimeType", Etsi, format, "text/xml");

        // Canonicalize the nodes in their final namespace context, before signing SignedInfo.
        var unsignedCopy = XmlSafety.Load(XmlSafety.Serialize(doc));
        var copiedSignature = unsignedCopy.GetElementsByTagName("Signature", Ds)[0]!;
        copiedSignature.ParentNode!.RemoveChild(copiedSignature);
        documentDigest.InnerText = Convert.ToBase64String(SHA1.HashData(Canonicalize(unsignedCopy.DocumentElement!)));
        propsDigest.InnerText = Convert.ToBase64String(SHA1.HashData(Canonicalize(props)));
        keyDigest.InnerText = Convert.ToBase64String(SHA1.HashData(Canonicalize(keyInfo)));
        signatureValue.InnerText = Convert.ToBase64String(rsa.SignData(Canonicalize(signedInfo), HashAlgorithmName.SHA1, RSASignaturePadding.Pkcs1));
        string result = XmlSafety.Serialize(doc);
        if (!Verify(result, certificate)) throw new CryptographicException("La firma del XML final no pasó la verificación independiente SignedXml.");
        return result;
    }
    private static byte[] Canonicalize(XmlElement element)
    {
        var document = new XmlDocument { PreserveWhitespace = true, XmlResolver = null };
        var copy = (XmlElement)document.ImportNode(element, true); document.AppendChild(copy);
        // Inclusive C14N needs the namespaces inherited from ancestors, not just descendants in an XPath node set.
        for (XmlNode? ancestor = element.ParentNode; ancestor is XmlElement; ancestor = ancestor.ParentNode)
            foreach (XmlAttribute attribute in ancestor.Attributes!)
                if ((attribute.Prefix == "xmlns" || attribute.Name == "xmlns" || attribute.Prefix == "xml") && !copy.HasAttribute(attribute.Name))
                    copy.SetAttribute(attribute.Name, attribute.Value);
        var transform = new XmlDsigC14NTransform();
        transform.LoadInput(document);
        using var output = (Stream)transform.GetOutput(typeof(Stream));
        using var buffer = new MemoryStream(); output.CopyTo(buffer); return buffer.ToArray();
    }
    public static bool Verify(string xml, X509Certificate2 expectedCertificate)
    {
        try
        {
            var doc = XmlSafety.Load(xml);
            var signatures = doc.GetElementsByTagName("Signature", Ds);
            if (doc.DocumentElement?.GetAttribute("id") != "comprobante" || signatures.Count != 1) return false;
            var verifier = new SignedXml(doc);
            verifier.LoadXml((XmlElement)signatures[0]!);
            var refs = verifier.SignedInfo!.References.Cast<Reference>().ToArray();
            if (refs.Length != 3 || refs.Count(r => r.Uri == "#comprobante") != 1 || refs.Count(r => r.Type == PropertiesType) != 1
                || refs.Any(r => r.Uri is null || !r.Uri.StartsWith('#'))) return false;
            return verifier.CheckSignature(expectedCertificate, verifySignatureOnly: true);
        }
        catch (Exception e) when (e is CryptographicException or XmlException or ArgumentException) { return false; }
    }
}
