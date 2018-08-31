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
    public partial class FrmRep08001 : baseClass.Repform 
    {
        public FrmRep08001()
        {
            InitializeComponent();
             this.nameReport = "R_08001";
        }
        public FrmRep08001(string xtitulo, string args)
        {
            InitializeComponent();
            this.Titulo = xtitulo;
             this.nameReport = "R_08001";
        }
 
       
        public override void RecogeParametros()
        {
            this.Paramis.Clear();
            Paramis.Add(new DLIB.Parametro("semno", semNo.Value, DLIB.Parametro.tipo.SoloSQL ));
            Paramis.Add(new DLIB.Parametro("anio", anio.Value, DLIB.Parametro.tipo.SoloSQL));
        }

        private void FrmRep08001_Load(object sender, EventArgs e)
        {
            //valores defecto 
            //anio.Value =

        }
    }
}
