using System.Text;
using System.Xml;
using System.Xml.Schema;

namespace Facturacion.Core;

public static class XmlSafety
{
    public static XmlDocument Load(string xml)
    {
        var doc = new XmlDocument { PreserveWhitespace = true, XmlResolver = null };
        using var reader = XmlReader.Create(new StringReader(xml), new XmlReaderSettings
        {
            DtdProcessing = DtdProcessing.Prohibit, XmlResolver = null, MaxCharactersInDocument = 4_000_000
        });
        doc.Load(reader);
        return doc;
    }
    public static string Serialize(XmlDocument doc)
    {
        using var stream = new MemoryStream();
        using (var writer = XmlWriter.Create(stream, new XmlWriterSettings { Encoding = new UTF8Encoding(false), Indent = false, NewLineHandling = NewLineHandling.None }))
            doc.Save(writer);
        return Encoding.UTF8.GetString(stream.ToArray());
    }
}

public sealed class InvoiceSchema
{
    private readonly XmlSchemaSet schemas = new() { XmlResolver = null };
    public InvoiceSchema(string directory)
    {
        // Load only pinned local files. The W3C schema's unused DOCTYPE is ignored; no external DTD is resolved.
        foreach (var file in new[] { "xmldsig-core-schema.xsd", "XAdES.xsd", "factura_V1.1.0.xsd" })
        {
            using var reader = XmlReader.Create(Path.Combine(directory, file), new XmlReaderSettings
            { DtdProcessing = DtdProcessing.Ignore, XmlResolver = null });
            schemas.Add(null, reader);
        }
        schemas.Compile();
    }
    public void Validate(string xml)
    {
        var doc = XmlSafety.Load(xml);
        doc.Schemas = schemas;
        List<string> errors = [];
        doc.Validate((_, e) => errors.Add(e.Message));
        if (errors.Count != 0) throw new InvoiceValidationException("XML inválido según XSD SRI: " + string.Join("; ", errors.Take(5)));
    }
}
