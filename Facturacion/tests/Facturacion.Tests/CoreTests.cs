using System.Globalization;
using System.Security.Cryptography.Xml;
using System.Xml;
using Facturacion.Core;
using Xunit;

namespace Facturacion.Tests;

public class CoreTests
{
    [Theory]
    [InlineData("41261533", 6)]
    [InlineData("0", 0)]
    [InlineData("6", 1)]
    public void Modulo11MatchesVectors(string text, int digit) => Assert.Equal(digit, InvoiceBuilder.CheckDigit(text));

    [Fact]
    public void AccessKeyMatchesOfficialInvoiceVector()
    {
        var issuer = Fixtures.Issuer with { Ruc = "1792146739001", Establecimiento = "002" };
        Assert.Equal("2110201101179214673900110020010000000011234567813",
            InvoiceBuilder.AccessKey(issuer, new(2011,10,21), 1, "12345678"));
    }
    [Fact]
    public void XmlValidatesWithOfficialSchemaIndependentOfCulture()
    {
        var before = CultureInfo.CurrentCulture;
        try
        {
            CultureInfo.CurrentCulture = new("es-EC");
            string xml = Fixtures.Xml(); Fixtures.Schema().Validate(xml);
            Assert.Contains("1.15", xml); Assert.Contains("&amp;", xml); Assert.Contains("&lt;XML&gt;", xml);
            Assert.Equal("1", XmlSafety.Load(xml).SelectSingleNode("/factura/infoTributaria/ambiente")!.InnerText);
        }
        finally { CultureInfo.CurrentCulture = before; }
    }
    [Fact]
    public void MixedTaxesAndDiscountsAreReconciled()
    {
        var invoice = Fixtures.Invoice() with { Detalles = [new("A", "Gravado", 3, 0.335m, 0.01m, "4", 15), new("B", "Cero", 2, 1, 0, "0", 0)], Pagos = [new("01", 3.15m)] };
        var totals = InvoiceBuilder.Calculate(invoice);
        Assert.Equal(3, totals.Subtotal); Assert.Equal(.15m, totals.Iva); Assert.Equal(.01m, totals.Descuento);
        Fixtures.Schema().Validate(InvoiceBuilder.Build(Fixtures.Issuer, invoice, 1, InvoiceBuilder.AccessKey(Fixtures.Issuer,invoice.FechaEmision,1,"12345678")));
    }
    [Fact]
    public void InvalidPaymentVatDiscountAndAnonymousBuyerAreRejected()
    {
        Assert.Throws<InvoiceValidationException>(() => InvoiceBuilder.Calculate(Fixtures.Invoice() with {Pagos = [new("01",1)]}));
        Assert.Throws<InvoiceValidationException>(() => InvoiceBuilder.Calculate(Fixtures.Invoice() with {Detalles = [new("X","X",1,1,0,"4",0)]}));
        Assert.Throws<InvoiceValidationException>(() => InvoiceBuilder.Calculate(Fixtures.Invoice() with {Detalles = [new("X","X",1,1,2,"0",0)]}));
        Assert.Throws<InvoiceValidationException>(() => InvoiceBuilder.Calculate(Fixtures.Invoice() with {Detalles = [new("X","X",1,60,0,"0",0)], Pagos=[new("01",60)]}));
    }
    [Fact]
    public void ExternalEntitiesAndInvalidSchemasAreRejected()
    {
        Assert.Throws<XmlException>(() => XmlSafety.Load("<!DOCTYPE factura [<!ENTITY x SYSTEM 'file:///secrets'>]><factura>&x;</factura>"));
        Assert.Throws<InvoiceValidationException>(() => Fixtures.Schema().Validate(Fixtures.Xml().Replace("<ambiente>1", "<ambiente>9")));
    }
    [Fact]
    public void XadesSignatureIsVerifiedByStandardSignedXmlAndOfficialInvoiceSchema()
    {
        using var cert = Fixtures.Certificate();
        var signed = new XadesSigner(cert).Sign(Fixtures.Xml());
        Fixtures.Schema().Validate(signed);
        Assert.True(XadesSigner.Verify(signed, cert));
        // A verifier independent of the signing implementation checks all three reference digests and SignedInfo.
        var doc = XmlSafety.Load(signed); var verifier = new SignedXml(doc);
        verifier.LoadXml((XmlElement)doc.GetElementsByTagName("Signature", XadesSigner.Ds)[0]!);
        Assert.True(verifier.CheckSignature(cert, true));
        Assert.Equal(3, verifier.SignedInfo!.References.Count);
        Assert.Contains("SignedProperties", signed);
        Assert.False(XadesSigner.Verify(signed.Replace("Servicio sintético", "Documento alterado"), cert));
        Assert.False(XadesSigner.Verify(signed.Replace("contenido comprobante", "Descripción alterada"), cert));
        var keyInfo = (XmlElement)doc.GetElementsByTagName("X509Certificate",XadesSigner.Ds)[0]!;
        keyInfo.InnerText = Convert.ToBase64String(new byte[32]);
        Assert.False(XadesSigner.Verify(XmlSafety.Serialize(doc),cert));
        using var other = Fixtures.Certificate(); Assert.False(XadesSigner.Verify(signed, other));
    }
}
