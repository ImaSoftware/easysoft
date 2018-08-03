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
            this.nameReport = "R_03001";
           // this.Titulo = "Contraste Existencia y Costos";
        }
        public FrmRep03001(string xtitulo, string args)
        {
            InitializeComponent();
            this.nameReport = "R_03001";
            // this.Titulo = "Contraste Existencia y Costos";
        }
        

        private void FrmRep03001_Load(object sender, EventArgs e)
        {
            this.visor.RefreshReport();
        }
        public override void RecogeParametros() {
            this.Paramis.Clear();
            Paramis.Add(new DLIB.Parametro("userid", DLIB.Globales.Parametros.UsrId,true));
            Paramis.Add(new DLIB.Parametro("inikardex", fecIni.Value,true));
            Paramis.Add(new DLIB.Parametro("noparteIni", "120100421D12110"));
            Paramis.Add(new DLIB.Parametro("noparteFin", "120100421D12110"));
            Paramis.Add(new DLIB.Parametro("loteIni", ""));
            Paramis.Add(new DLIB.Parametro("loteFin", ""));
        }
    }
}
