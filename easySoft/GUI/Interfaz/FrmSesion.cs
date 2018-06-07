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


        Point cursor = new Point(0, 0);
        bool mouseD = false;


        private void FrmSesion_Load(object sender, EventArgs e)
        {
            ctlSesion1.loader();
            this.barraTitulo.Visible = false;
            this.ctlSesion1.Location = new Point(0, 0);
            this.Height = this.Height - 38;
        }

        private void ctlSesion1_Acceso_Correcto(object sender, EventArgs e)
        {
            _Resultado = ctlSesion1.Acceso ;
            this.Close();
        }

        private void ctlSesion1_MouseDown(object sender, MouseEventArgs e)
        {
            mouseD = true;
            cursor = Cursor.Position;
        }

        private void ctlSesion1_MouseUp(object sender, MouseEventArgs e)
        {
            if (mouseD)
            {
                this.Location = new Point(this.Location.X + Cursor.Position.X - cursor.X, this.Location.Y + Cursor.Position.Y - cursor.Y);
                mouseD = false;
            }
        }

        private void FrmSesion_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape) {
                Environment.Exit(-1);
            }
        }
    }
}
