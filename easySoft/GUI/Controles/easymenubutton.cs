using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI.Controles
{
    public partial class easymenubutton : UserControl
    {
        public enum Tipo { Menu, Programa}
        private enum Estado { contraido, expandido}
        Estado miEstado = Estado.contraido;
        public easymenubutton()
        {
            InitializeComponent();
        }
        public void CargaOPT(Tipo xtip, string Desc, string image_Key )
        {

        }

    }
}
