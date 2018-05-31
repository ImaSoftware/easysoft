using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;

namespace GUI.Interfaz
{
    public partial class CtlSesion : UserControl
    {
        public CtlSesion()
        {
            InitializeComponent();
            if (!DLIB.Globales.Parametros.Inicia_Sesion(System.Configuration.ConfigurationManager.ConnectionStrings[1].ConnectionString,"","",1)) 
            {
                MessageBox.Show("No se logra conexion con la base de datos");
                Environment.Exit(-1);
            }

        }
    }
}
