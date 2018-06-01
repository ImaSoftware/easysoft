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
                Application.Run(new Lobby());
            }
            else {
                Environment.Exit(Environment.ExitCode);
            }
            
          
        }
    }
}
