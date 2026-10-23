using System;
using System.Windows.Forms;

namespace GUI
{
    static class easySoftware
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            try
            {
                SqlServerTypes.Utilities.LoadNativeAssemblies(AppDomain.CurrentDomain.BaseDirectory);
                using (var session = new FrmSesion())
                {
                    session.ShowDialog();
                    if (!session.Resultado) return;
                }
                do
                {
                    DLIB.Globales.Parametros.Otra = false;
                    using (var lobby = new Lobby()) Application.Run(lobby);
                }
                while (DLIB.Globales.Parametros.Otra);
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo ejecutar EasySoft: " + ex.Message, "EasySoft", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}