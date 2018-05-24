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
        public FrmSesion()
        {
            InitializeComponent();
            Interfaz.CtlSesion ctlX = new Interfaz.CtlSesion();
            ctlX.Dock = DockStyle.Fill;
            this.padCtl.Controls.Add(ctlX);

        }
    }
}
