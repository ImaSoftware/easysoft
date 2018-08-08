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
    public partial class FrmRep07001 : baseClass.easyForm
    {
        public FrmRep07001()
        {
            InitializeComponent();
        }
        public FrmRep07001(string xtitulo, string args)
        {
            InitializeComponent();
            this.Titulo=xtitulo;
        }
        private void btnGenera_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            CreaRepo();
            Cursor = Cursors.Default;
        }
        private void CreaRepo() {
            List<DLIB.Parametro> lo = new List<DLIB.Parametro>();
            lo.Add(new DLIB.Parametro("userid", DLIB.Globales.Parametros.UsrId,DLIB.Parametro.tipo.Ambos));
            lo.Add(new DLIB.Parametro("fecini", fecIni.Value, DLIB.Parametro.tipo.Ambos));
            lo.Add(new DLIB.Parametro("fecfin", fecFin.Value, DLIB.Parametro.tipo.Ambos));
            lo.Add(new DLIB.Parametro("provee", txtprov.Text.Trim(), DLIB.Parametro.tipo.SoloSQL));
            lo.Add(new DLIB.Parametro("loteini", txtLoteIni.Text.Trim(), DLIB.Parametro.tipo.SoloSQL));
            lo.Add(new DLIB.Parametro("lotefin", txtLoteFin.Text.Trim(), DLIB.Parametro.tipo.SoloSQL));

            List<SqlParameter> prmtr = new List<SqlParameter>();
            foreach (DLIB.Parametro pm in lo)
            {
                if(pm.tip != DLIB.Parametro.tipo.SoloRepo )
                    prmtr.Add(new SqlParameter(pm.Nombre, pm.value));
            }
            DLIB.RepoMan repo = new DLIB.RepoMan("R_07001D", prmtr);
            repo.load();
            this.visor.SetDisplayMode(DisplayMode.Normal);
            //this.Titulo = repo.Comentario;
            if (String.IsNullOrEmpty(visor.LocalReport.ReportPath)) {
                this.visor.LocalReport.ReportPath = System.IO.Directory.GetCurrentDirectory() + "\\Reportes\\R_07001D.rdlc";
            }
            //this.WindowState = FormWindowState.Maximized;
            this.visor.ProcessingMode = ProcessingMode.Local;
            this.visor.LocalReport.DataSources.Clear();
            try
            {
                for (int j = 0; j <= repo.db.Tables.Count - 1; j++)
                {
                    if (j == 0)
                        continue;
                    DataTable table = repo.db.Tables[j];
                    this.visor.LocalReport.DataSources.Add(new ReportDataSource(table.TableName, table));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("opps: " + ex.Message);
            }
            this.visor.LocalReport.EnableExternalImages = repo.EnableExternalImages;
            if (lo != null)
            {
                ReportParameter[] parametr = new ReportParameter[0];
                
                int i = 0;
                foreach (DLIB.Parametro pm in lo)
                {
                    if (pm.tip != DLIB.Parametro.tipo.SoloSQL) {
                        Array.Resize(ref parametr, i+1);
                        parametr[i] = new ReportParameter(pm.Nombre, pm.value.ToString());
                        i++;
                    }
                }
                try
                {
                    visor.LocalReport.SetParameters(parametr);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("opps: " + ex.Message);
                }
            }
            this.visor.RefreshReport();
        }
        
        private void FrmRep07001_Load(object sender, EventArgs e)
        {

            this.visor.RefreshReport();
            pnlPrinDist = pnlPrin.SplitterDistance;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            saltaDist = true;
            this.pnlPrin.SplitterDistance = (this.button4.ImageIndex == 0 ? pnlPrinDist : button4.Height); ;
            this.panelFiltro.Visible = (this.button4.ImageIndex == 0 ? true : false);
            this.button4.ImageIndex = (this.button4.ImageIndex == 0 ? 1 : 0);
            saltaDist = false;
        }
        private int pnlPrinDist = 0;
        private bool saltaDist = false;
        private void pnlPrin_SplitterMoved(object sender, SplitterEventArgs e)
        {
            if (saltaDist ){ return; }
            pnlPrinDist= pnlPrin.SplitterDistance;
        }

        private void txtprov_Leave(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtprov.Text.Trim())) {
                proveDesc.Text = "Todos los proveedores";
                return;
            }
            List<SqlParameter> lo = new List<SqlParameter>();
            lo.Add(new SqlParameter("@codprov", txtprov.Text.Trim()));
            DataTable dbYY = DLIB.Globales.Parametros.connSql.TraerTabla("RSC_001", lo);
            if (dbYY != null)
            {
                if (dbYY.Rows.Count != 1)
                {
                    MessageBox.Show("Codigo no existe o se encuentra repetido. Verifique...");
                    txtprov.Text = "";
                    proveDesc.Text = "Todos los proveedores";
                    return;
                }
                else
                {
                    proveDesc.Text = (dbYY.Rows[0][0] == null ? "" : (string)dbYY.Rows[0][0]);
                }
            }
            else
            {
                MessageBox.Show("Error al seleccionar el conjunto de datos...");
                txtprov.Text = "";
                proveDesc.Text = "Todos los proveedores";
                return;
            }
        }

        private void txtLoteIni_Leave(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtLoteFin.Text.Trim()))
            {
                txtLoteFin.Text = txtLoteIni.Text;
            }
        }

        private void txtprov_KeyUp(object sender, KeyEventArgs e)
        {
            easySearch repoSearch = new easySearch("E_TB06A110", "Codigo",null);
            switch (e.KeyCode)
            {
                case DLIB.Globales.keyhelp:
                        DialogResult x = repoSearch.ShowDialog();
                    if (x == DialogResult.OK && repoSearch.Resultado!=null) {
                        txtprov.Text = repoSearch.Resultado.ToString();
                    }
                    break;
            }
        }

        private void pnlPrin_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txtLoteIni_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
