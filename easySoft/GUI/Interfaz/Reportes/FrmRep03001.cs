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
            this.Titulo = xtitulo;
            this.nameReport = "R_03001";
            // this.Titulo = "Contraste Existencia y Costos";
        }
        

        private void FrmRep03001_Load(object sender, EventArgs e)
        {
            this.visor.RefreshReport();
        }
        public override void RecogeParametros() {
            this.Paramis.Clear();
            Paramis.Add(new DLIB.Parametro("userid", DLIB.Globales.Parametros.UsrId));
            Paramis.Add(new DLIB.Parametro("inikardex", new DateTime(fecIni.Value.Year, fecIni.Value.Month, 1)));
            Paramis.Add(new DLIB.Parametro("noparteIni", txtItmIni.Text.Trim(), DLIB.Parametro.tipo.SoloSQL));
            Paramis.Add(new DLIB.Parametro("noparteFin", txtItmFin.Text.Trim(), DLIB.Parametro.tipo.SoloSQL));
            Paramis.Add(new DLIB.Parametro("loteIni", txtloteIni.Text.Trim(), DLIB.Parametro.tipo.SoloSQL));
            Paramis.Add(new DLIB.Parametro("loteFin", txtloteFin.Text.Trim(), DLIB.Parametro.tipo.SoloSQL));
        }

        private void txtItmIni_Leave(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtItmIni.Text.Trim()))
            {
                return;
            }
            List<SqlParameter> lo = new List<SqlParameter>();
            lo.Add(new SqlParameter("@no_parte", txtItmIni.Text.Trim()));
            DataTable dbYY = DLIB.Globales.Parametros.connSql.TraerTabla("RSC_002", lo);
            if (dbYY != null)
            {
                if (dbYY.Rows.Count != 1)
                {
                    MessageBox.Show("Codigo no existe o se encuentra repetido. Verifique...");
                    txtItmIni.Text = "";
                    return;
                }
                else {
                    if (((Control)sender).Name == "txtItmIni")
                        txtItmFin.Text = txtItmIni.Text;
                }
            }
            else
            {
                MessageBox.Show("Error al seleccionar el conjunto de datos...");
                txtItmIni.Text = "";
               return;
            }
        }

        private void txtloteIni_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtloteIni_Leave(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtloteFin.Text.Trim()))
            {
                txtloteFin.Text = txtloteIni.Text;
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void fecIni_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
