using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI.Interfaz.Reportes
{
    public partial class FrmRep03001 : GUI.baseClass.Repform
    {
        public FrmRep03001()
        {
            InitializeComponent();
            this.Titulo = "Contraste Existencia y Costos";
        }
        
    }
}
