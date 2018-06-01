using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class FrmSesion : baseClass.easyForm 
    {
        private bool _Resultado;
        public bool Resultado {
            get { return _Resultado; }
           // set { Resultado = value; }
        }

        public FrmSesion()
        {
            InitializeComponent();
            
            //Interfaz.CtlSesion ctlX = new Interfaz.CtlSesion();
            //ctlX.Dock = DockStyle.Fill;
            //this.padCtl.Controls.Add(ctlX);
        }

        private void FrmSesion_Load(object sender, EventArgs e)
        {
            ctlSesion1.loader();
        }

        private void ctlSesion1_Acceso_Correcto(object sender, EventArgs e)
        {
            _Resultado = ctlSesion1.Acceso ;
            this.Close();
        }
    }
}
