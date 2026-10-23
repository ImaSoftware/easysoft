using System.Globalization;
using System.Security.Cryptography;
using System.Text;
using System.Xml;
using System.Xml.Linq;

namespace Facturacion.Core;

public static class InvoiceBuilder
{
    public static decimal Money(decimal value) => decimal.Round(value, 2, MidpointRounding.AwayFromZero);
    public static void Text(string? value, string name, int max = 300)
    {
        if (string.IsNullOrWhiteSpace(value) || value.Length > max || value.Any(char.IsControl))
            throw new InvoiceValidationException($"{name}: texto obligatorio de hasta {max} caracteres, sin controles.");
        try { XmlConvert.VerifyXmlChars(value); }
        catch (XmlException) { throw new InvoiceValidationException($"{name}: contiene caracteres XML inválidos."); }
    }
    public static bool Digits(string? value, int length) => value?.Length == length && value.All(c => c is >= '0' and <= '9');
    public static void ValidateIssuer(Issuer e)
    {
        if (!Digits(e.Ruc, 13) || !e.Ruc.EndsWith("001", StringComparison.Ordinal))
            throw new InvoiceValidationException("RUC del emisor: 13 dígitos terminados en 001.");
        Text(e.RazonSocial, "Razón social"); Text(e.DirMatriz, "Dirección matriz");
        Text(e.DirEstablecimiento, "Dirección establecimiento");
        if (!Digits(e.Establecimiento, 3) || e.Establecimiento == "000" || !Digits(e.PuntoEmision, 3) || e.PuntoEmision == "000")
            throw new InvoiceValidationException("Establecimiento y punto de emisión: tres dígitos, diferentes de 000.");
        if (e.PrimerSecuencial is < 1 or > 999999999) throw new InvoiceValidationException("Secuencial inicial fuera de rango.");
        if (e.RucProveedor is not null && !Digits(e.RucProveedor, 13)) throw new InvoiceValidationException("RUC Proveedor inválido.");
    }
    public static InvoiceTotals Calculate(InvoiceRequest r)
    {
        if (r is null || r.Comprador is null || r.Detalles is null || r.Pagos is null)
            throw new InvoiceValidationException("Comprador, detalles y pagos son obligatorios.");
        Text(r.Referencia, "Referencia", 100);
        if (r.FechaEmision == default) throw new InvoiceValidationException("Fecha de emisión obligatoria.");
        Text(r.Comprador.RazonSocial, "Comprador");
        var b = r.Comprador;
        bool validBuyer = b.TipoIdentificacion switch
        {
            "04" => Digits(b.Identificacion, 13),
            "05" => Digits(b.Identificacion, 10),
            "06" or "08" => !string.IsNullOrWhiteSpace(b.Identificacion) && b.Identificacion.Length <= 20,
            "07" => b.Identificacion == "9999999999999" && b.RazonSocial == "CONSUMIDOR FINAL",
            _ => false
        };
        if (!validBuyer) throw new InvoiceValidationException("Tipo o identificación del comprador inválido.");
        if (r.Detalles.Length is < 1 or > 1000 || r.Pagos.Length is < 1 or > 20)
            throw new InvoiceValidationException("Se requieren entre 1 y 1000 detalles y entre 1 y 20 pagos.");
        if (r.Propina < 0 || Money(r.Propina) != r.Propina) throw new InvoiceValidationException("Propina inválida.");
        List<CalculatedLine> lines = [];
        foreach (var line in r.Detalles)
        {
            if (line is null) throw new InvoiceValidationException("Detalle nulo.");
            Text(line.Codigo, "Código", 25); Text(line.Descripcion, "Descripción");
            if (line.Cantidad <= 0 || line.Cantidad > 999999999 || line.PrecioUnitario < 0 || line.PrecioUnitario > 999999999
                || decimal.Round(line.Cantidad, 6) != line.Cantidad || decimal.Round(line.PrecioUnitario, 6) != line.PrecioUnitario
                || line.Descuento < 0 || Money(line.Descuento) != line.Descuento)
                throw new InvoiceValidationException("Cantidad, precio o descuento fuera de rango o precisión.");
            // First milestone deliberately supports ordinary domestic VAT 0% and 15% only.
            if (!(line.CodigoIva == "0" && line.TarifaIva == 0 || line.CodigoIva == "4" && line.TarifaIva == 15))
                throw new InvoiceValidationException("Este hito admite IVA código 0/tarifa 0 y código 4/tarifa 15.");
            decimal net = Money(line.Cantidad * line.PrecioUnitario - line.Descuento);
            if (net < 0 || line.Descuento > line.Cantidad * line.PrecioUnitario || net > 999999999999m)
                throw new InvoiceValidationException("Descuento mayor que el importe o base fuera de rango.");
            lines.Add(new(line, net, Money(net * line.TarifaIva / 100m)));
        }
        decimal subtotal = lines.Sum(l => l.Base), iva = lines.Sum(l => l.Iva);
        decimal total = subtotal + iva + r.Propina;
        if (total <= 0 || total > 999999999999m) throw new InvoiceValidationException("Total fuera de rango.");
        if (b.TipoIdentificacion == "07" && total > 50) throw new InvoiceValidationException("Sobre USD 50 debe identificar al comprador.");
        foreach (var p in r.Pagos)
        {
            if (p is null || !new[] { "01", "15", "16", "17", "18", "19", "20", "21" }.Contains(p.FormaPago)
                || p.Total <= 0 || p.Total > total || Money(p.Total) != p.Total || p.Plazo < 0
                || (p.Plazo is null) != (p.UnidadTiempo is null))
                throw new InvoiceValidationException("Forma, importe o plazo de pago inválido.");
        }
        if (r.Pagos.Sum(p => p.Total) != total) throw new InvoiceValidationException("Los pagos no coinciden con el total calculado.");
        if ((r.InformacionAdicional?.Length ?? 0) > 14) throw new InvoiceValidationException("Máximo 14 campos adicionales; se reserva uno para RUC Proveedor.");
        foreach (var f in r.InformacionAdicional ?? [])
        {
            if (f is null) throw new InvoiceValidationException("Campo adicional nulo.");
            Text(f.Nombre, "Nombre adicional"); Text(f.Valor, "Valor adicional");
            if (f.Nombre.Equals("RUC Proveedor", StringComparison.OrdinalIgnoreCase))
                throw new InvoiceValidationException("RUC Proveedor se configura en el emisor.");
        }
        return new(lines.ToArray(), subtotal, lines.Sum(l => l.Input.Descuento), iva, total);
    }
    public static int CheckDigit(string digits)
    {
        if (string.IsNullOrEmpty(digits) || digits.Any(c => c is < '0' or > '9')) throw new InvoiceValidationException("Módulo 11 requiere dígitos.");
        int sum = 0, factor = 2;
        for (int i = digits.Length - 1; i >= 0; i--) { sum += (digits[i] - '0') * factor; factor = factor == 7 ? 2 : factor + 1; }
        int digit = 11 - sum % 11;
        return digit == 11 ? 0 : digit == 10 ? 1 : digit;
    }
    public static string AccessKey(Issuer issuer, DateOnly date, long sequence, string numericCode)
    {
        ValidateIssuer(issuer);
        if (sequence is < 1 or > 999999999 || !Digits(numericCode, 8)) throw new InvoiceValidationException("Secuencial o código numérico inválido.");
        // 01 = factura, 1 = pruebas, final 1 = emisión normal. No production branch.
        string first = date.ToString("ddMMyyyy", CultureInfo.InvariantCulture) + "01" + issuer.Ruc + "1"
            + issuer.Establecimiento + issuer.PuntoEmision + sequence.ToString("D9", CultureInfo.InvariantCulture) + numericCode + "1";
        return first + CheckDigit(first).ToString(CultureInfo.InvariantCulture);
    }
    public static string NumericCode() => RandomNumberGenerator.GetInt32(0, 100000000).ToString("D8", CultureInfo.InvariantCulture);
    private static string M(decimal v) => v.ToString("0.00", CultureInfo.InvariantCulture);
    private static string Q(decimal v) => v.ToString("0.######", CultureInfo.InvariantCulture);
    private static XElement? Optional(string name, string? v) => string.IsNullOrEmpty(v) ? null : new XElement(name, v);
    public static string Build(Issuer e, InvoiceRequest r, long seq, string key)
    {
        ValidateIssuer(e);
        var t = Calculate(r);
        XElement root = new("factura", new XAttribute("id", "comprobante"), new XAttribute("version", "1.1.0"),
            new XElement("infoTributaria", new XElement("ambiente", "1"), new XElement("tipoEmision", "1"),
                new XElement("razonSocial", e.RazonSocial), Optional("nombreComercial", e.NombreComercial), new XElement("ruc", e.Ruc),
                new XElement("claveAcceso", key), new XElement("codDoc", "01"), new XElement("estab", e.Establecimiento),
                new XElement("ptoEmi", e.PuntoEmision), new XElement("secuencial", seq.ToString("D9", CultureInfo.InvariantCulture)),
                new XElement("dirMatriz", e.DirMatriz), Optional("agenteRetencion", e.AgenteRetencion), Optional("contribuyenteRimpe", e.ContribuyenteRimpe)),
            new XElement("infoFactura", new XElement("fechaEmision", r.FechaEmision.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture)),
                new XElement("dirEstablecimiento", e.DirEstablecimiento), Optional("contribuyenteEspecial", e.ContribuyenteEspecial),
                new XElement("obligadoContabilidad", e.ObligadoContabilidad ? "SI" : "NO"),
                new XElement("tipoIdentificacionComprador", r.Comprador.TipoIdentificacion), new XElement("razonSocialComprador", r.Comprador.RazonSocial),
                new XElement("identificacionComprador", r.Comprador.Identificacion), Optional("direccionComprador", r.Comprador.Direccion),
                new XElement("totalSinImpuestos", M(t.Subtotal)), new XElement("totalDescuento", M(t.Descuento)),
                new XElement("totalConImpuestos", t.Lines.GroupBy(l => new { l.Input.CodigoIva, l.Input.TarifaIva }).Select(g =>
                    new XElement("totalImpuesto", new XElement("codigo", "2"), new XElement("codigoPorcentaje", g.Key.CodigoIva),
                        new XElement("baseImponible", M(g.Sum(l => l.Base))), new XElement("tarifa", M(g.Key.TarifaIva)), new XElement("valor", M(g.Sum(l => l.Iva)))))),
                new XElement("propina", M(r.Propina)), new XElement("importeTotal", M(t.Total)), new XElement("moneda", "DOLAR"),
                new XElement("pagos", r.Pagos.Select(p => new XElement("pago", new XElement("formaPago", p.FormaPago), new XElement("total", M(p.Total)),
                    p.Plazo is null ? null : new XElement("plazo", Q(p.Plazo.Value)), Optional("unidadTiempo", p.UnidadTiempo))))),
            new XElement("detalles", t.Lines.Select(l => new XElement("detalle", new XElement("codigoPrincipal", l.Input.Codigo),
                Optional("codigoAuxiliar", l.Input.CodigoAuxiliar), new XElement("descripcion", l.Input.Descripcion), new XElement("cantidad", Q(l.Input.Cantidad)),
                new XElement("precioUnitario", Q(l.Input.PrecioUnitario)), new XElement("descuento", M(l.Input.Descuento)), new XElement("precioTotalSinImpuesto", M(l.Base)),
                new XElement("impuestos", new XElement("impuesto", new XElement("codigo", "2"), new XElement("codigoPorcentaje", l.Input.CodigoIva),
                    new XElement("tarifa", M(l.Input.TarifaIva)), new XElement("baseImponible", M(l.Base)), new XElement("valor", M(l.Iva))))))));
        var fields = (r.InformacionAdicional ?? []).ToList();
        if (e.RucProveedor is not null) fields.Add(new("RUC Proveedor", e.RucProveedor));
        if (fields.Count > 0) root.Add(new XElement("infoAdicional", fields.Select(f => new XElement("campoAdicional", new XAttribute("nombre", f.Nombre), f.Valor))));
        return "<?xml version=\"1.0\" encoding=\"utf-8\"?>" + root.ToString(SaveOptions.DisableFormatting);
    }
    public static string Fingerprint(Issuer issuer, InvoiceRequest request) => Convert.ToHexString(SHA256.HashData(
        Encoding.UTF8.GetBytes(System.Text.Json.JsonSerializer.Serialize(new { issuer, request }, JsonDefaults.Options))));
}
