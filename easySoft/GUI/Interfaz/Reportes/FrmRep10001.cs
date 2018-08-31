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
    public partial class FrmRep10001 : GUI.baseClass.Repform
    {
        public FrmRep10001()
        {
            InitializeComponent();
            this.nameReport = "R_10001";
        }
        public FrmRep10001(string xtitulo, string args)
        {
            InitializeComponent();
            this.Titulo = xtitulo;
            this.nameReport = "R_10001";
        }
        public override void RecogeParametros()
        {
            this.Paramis.Clear();
           // Paramis.Add(new DLIB.Parametro("MES", fecIni.Value.Month));
           // Paramis.Add(new DLIB.Parametro("ANIO", fecIni.Value.Year));
        }
    }
  
}
