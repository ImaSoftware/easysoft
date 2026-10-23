using System;
using System.Data;
using System.Globalization;
using DLIB;

internal static class Regression
{
    private static int checks;
    private static void Check(bool result, string name)
    {
        if (!result) throw new Exception(name);
        checks++;
    }
    private static int Main()
    {
        try
        {
            string hash = PasswordSecurity.Hash("Contraseña de prueba ñ");
            Check(PasswordSecurity.Verify("Contraseña de prueba ñ", hash), "Hash roundtrip");
            Check(!PasswordSecurity.Verify("incorrecta", hash), "Wrong password");
            Check(!PasswordSecurity.Verify("plaintext", "plaintext"), "Reject legacy plaintext");
            Check(!PasswordSecurity.Verify("x", "PBKDF2-SHA256$600000$malformed$malformed"), "Malformed encoding");
            Check(!PasswordSecurity.Verify("x", "PBKDF2-SHA256$1$AA==$AA=="), "Weak hash");
            Check(hash != PasswordSecurity.Hash("Contraseña de prueba ñ"), "Random salts");
            Check(System.Text.RegularExpressions.Regex.IsMatch(hash, @"^PBKDF2-SHA256\$600000\$[A-Za-z0-9+/]{22}==\$[A-Za-z0-9+/]{43}=$"), "Migration hash format");
            var session = new GlobC();
            Check(!session.Inicia_Sesion("invalid", "", "password", 1), "Reject empty user before connection");
            Check(!session.Inicia_Sesion("invalid", "user", "", 1), "Reject empty password before connection");
            Check(!session.Inicia_Sesion("invalid", new string('x', 101), "password", 1), "Reject truncated user");
            Check(session.CodUser == -1 && session.CodCia == -1 && session.CadenaConexion == "", "Rejected login preserves unauthenticated state");
            string previousConnection = Environment.GetEnvironmentVariable("EASYSOFT_ROOT_CONNECTION");
            try
            {
                Environment.SetEnvironmentVariable("EASYSOFT_ROOT_CONNECTION", "Data Source=example;Integrated Security=True;Encrypt=False;TrustServerCertificate=True");
                var config = new System.Data.SqlClient.SqlConnectionStringBuilder(RuntimeConfig.RootConnectionString);
                Check(config.Encrypt && !config.TrustServerCertificate && !config.PersistSecurityInfo, "Enforce secure connection options");
                Environment.SetEnvironmentVariable("EASYSOFT_ROOT_CONNECTION", "Data Source=example;User ID=sa");
                bool adminRejected = false;
                try { string ignored = RuntimeConfig.RootConnectionString; }
                catch (System.Configuration.ConfigurationErrorsException) { adminRejected = true; }
                Check(adminRejected, "Reject administrator SQL account");
            }
            finally { Environment.SetEnvironmentVariable("EASYSOFT_ROOT_CONNECTION", previousConnection); }
            var table = new DataTable();
            table.Columns.Add("id", typeof(int));
            table.Columns.Add("a]b\\c", typeof(string));
            table.Columns.Add("amount", typeof(decimal));
            table.Columns.Add("date", typeof(DateTime));
            table.Rows.Add(1, "O'Brien [50%]*", 12.5m, DateTime.Today);
            table.Rows.Add(2, "Other", 42m, DateTime.Today);
            foreach (string text in new[] { "O'Brien", "[50%]*", "]", "%", "*", "[" })
                Check(table.Select(SearchFilter.Build(table, text)).Length == 1, "Literal search: " + text);
            Check(table.Select(SearchFilter.Build(table, "Other")).Length == 1, "Numeric first column");
            Check(table.Select(SearchFilter.Build(table, "Other", "amount")).Length == 0, "Non numeric input");
            Check(table.Select(SearchFilter.Build(table, "")).Length == 2, "Empty search");
            var oldCulture = CultureInfo.CurrentCulture;
            try
            {
                CultureInfo.CurrentCulture = CultureInfo.GetCultureInfo("es-ES");
                Check(table.Select(SearchFilter.Build(table, "12,5", "amount")).Length == 1, "Decimal culture");
            }
            finally { CultureInfo.CurrentCulture = oldCulture; }
            Check(SearchFilter.Build(null, "x") == "", "Missing data");
            bool missingReport = false;
            try { RuntimeConfig.ReportPath("missing-test-report"); }
            catch (System.IO.FileNotFoundException) { missingReport = true; }
            Check(missingReport, "Missing report diagnostic");
            bool traversal = false;
            try { RuntimeConfig.ReportPath("../private"); }
            catch (ArgumentException) { traversal = true; }
            Check(traversal, "Reject report traversal");
            Console.WriteLine("Passed " + checks + " regression checks.");
            return 0;
        }
        catch (Exception ex) { Console.Error.WriteLine(ex); return 1; }
    }
}
