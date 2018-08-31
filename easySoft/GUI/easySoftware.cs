using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    static class easySoftware
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            FrmSesion Sesion = new FrmSesion();
            Sesion.ShowDialog();
            if (Sesion.Resultado)
            {
                try
                {
                    Lobby frmNew = new Lobby();
                    Application.Run(frmNew);
                    while (DLIB.Globales.Parametros.Otra)
                    {
                        DLIB.Globales.Parametros.Otra = false;
                        Lobby frm2 = new Lobby();
                        Application.Run(frm2);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message + Environment.NewLine + (ex.InnerException == null ? "" : ex.InnerException.Message));
                }

            }
            else
            {
                Environment.Exit(Environment.ExitCode);
            }


        }
    }
}
