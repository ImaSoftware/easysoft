using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI.Interfaz.Reportes
{
    public partial class FrmRep07002 : GUI.baseClass.Repform
    {
        public FrmRep07002()
        {
            InitializeComponent();
            this.nameReport = "R_07002";
        }
        public FrmRep07002(string xtitulo, string args)
        {
            InitializeComponent();
            this.Titulo = xtitulo;
            this.nameReport = "R_07002";
        }
        public override void RecogeParametros()
        {
            this.Paramis.Clear();
            Paramis.Add(new DLIB.Parametro("MES", fecIni.Value.Month));
            Paramis.Add(new DLIB.Parametro("ANIO",  fecIni.Value.Year));
        }

        private void FrmRep07002_Load(object sender, EventArgs e)
        {
            this.fecIni.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);

        }
    }
}
