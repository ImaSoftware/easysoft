using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Security.Cryptography;

namespace DLIB
{
    public static class RuntimeConfig
    {
        public static string RootConnectionString
        {
            get
            {
                string value = Environment.GetEnvironmentVariable("EASYSOFT_ROOT_CONNECTION");
                if (string.IsNullOrWhiteSpace(value))
                {
                    var setting = ConfigurationManager.ConnectionStrings["GUI.Properties.Settings.connSQL"];
                    value = setting == null ? null : setting.ConnectionString;
                }
                if (string.IsNullOrWhiteSpace(value))
                    throw new ConfigurationErrorsException("Configure EASYSOFT_ROOT_CONNECTION para conectar con la base central.");
                var builder = new SqlConnectionStringBuilder(value);
                if (!builder.IntegratedSecurity && string.Equals(builder.UserID, "sa", StringComparison.OrdinalIgnoreCase))
                    throw new ConfigurationErrorsException("Utilice una cuenta SQL con permisos mínimos, distinta de sa.");
                builder.PersistSecurityInfo = false;
                builder.Encrypt = true;
                builder.TrustServerCertificate = false;
                builder.ConnectTimeout = 30;
                return builder.ConnectionString;
            }
        }

        public static string ReportPath(string name)
        {
            if (string.IsNullOrWhiteSpace(name) || Path.GetFileName(name) != name ||
                name.IndexOfAny(Path.GetInvalidFileNameChars()) >= 0)
                throw new ArgumentException("Nombre de reporte inválido.");
            string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Reportes", name + ".rdlc");
            if (!File.Exists(path))
                throw new FileNotFoundException("Falta la definición del reporte: " + name + ".rdlc", path);
            return path;
        }
    }

    public static class PasswordSecurity
    {
        private const int Iterations = 600000;
        public static string Hash(string password)
        {
            if (password == null) throw new ArgumentNullException("password");
            byte[] salt = new byte[16];
            using (var random = RandomNumberGenerator.Create()) random.GetBytes(salt);
            using (var derive = new Rfc2898DeriveBytes(password, salt, Iterations, HashAlgorithmName.SHA256))
                return "PBKDF2-SHA256$" + Iterations + "$" + Convert.ToBase64String(salt) + "$" + Convert.ToBase64String(derive.GetBytes(32));
        }

        public static bool Verify(string password, string stored)
        {
            if (password == null || string.IsNullOrEmpty(stored)) return false;
            string[] parts = stored.Split('$');
            int iterations;
            if (parts.Length != 4 || parts[0] != "PBKDF2-SHA256" ||
                !int.TryParse(parts[1], out iterations) || iterations < Iterations || iterations > 2000000) return false;
            try
            {
                byte[] salt = Convert.FromBase64String(parts[2]);
                byte[] expected = Convert.FromBase64String(parts[3]);
                if (salt.Length != 16 || expected.Length != 32) return false;
                using (var derive = new Rfc2898DeriveBytes(password, salt, iterations, HashAlgorithmName.SHA256))
                {
                    byte[] actual = derive.GetBytes(expected.Length);
                    int difference = 0;
                    for (int i = 0; i < actual.Length; i++) difference |= actual[i] ^ expected[i];
                    return difference == 0;
                }
            }
            catch (FormatException) { return false; }
        }
    }
}
