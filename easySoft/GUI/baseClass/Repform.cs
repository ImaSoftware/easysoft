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

namespace GUI.baseClass
{
    public partial class Repform : easyForm
    {
        string nameReport = "";
        List<DLIB.Parametro> Paramis = new List<DLIB.Parametro>();
        int id = 0;
        private int pnlPrinDist = 0;
        private bool saltaDist = false;
        public Repform()
        {
            InitializeComponent();
        }
        public Repform(string nomrepo, List<DLIB.Parametro> argParam = null)
        {
            InitializeComponent();
            nameReport = nomrepo;
            Paramis = argParam;
        }



        private void Repform_Load(object sender, EventArgs e)
        {
            if (DesignMode) { return; }
            //pnlPrinDist = splitter.SplitterDistance;
            List<SqlParameter> prmtr = new List<SqlParameter>();
            foreach (DLIB.Parametro pm in Paramis)
            {
                prmtr.Add(new SqlParameter(pm.Nombre, pm.value));
            }
            DLIB.RepoMan repo = new DLIB.RepoMan(nameReport, prmtr);
            repo.load();
            this.visor.SetDisplayMode(DisplayMode.Normal);
            this.Titulo = repo.Comentario;
            this.visor.LocalReport.ReportPath = System.IO.Directory.GetCurrentDirectory() + "\\Reportes\\" + nameReport + ".rdlc";
            this.WindowState = FormWindowState.Maximized;
            this.visor.ProcessingMode = ProcessingMode.Local;
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
            if (Paramis != null)
            {
                ReportParameter[] parametr = new ReportParameter[0];
                Array.Resize(ref parametr, Paramis.Count);
                int i = 0;
                foreach (DLIB.Parametro pm in Paramis)
                {
                    parametr[i] = new ReportParameter(pm.Nombre, pm.value.ToString());
                    i++;
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

        private void button4_Click(object sender, EventArgs e)
        {
            saltaDist = true;
            //this.splitter.SplitterDistance = (this.button4.ImageIndex == 0 ? pnlPrinDist : button4.Height); ;
           // this.ctlParam.Visible = (this.button4.ImageIndex == 0 ? true : false);
            this.button4.ImageIndex = (this.button4.ImageIndex == 0 ? 1 : 0);
            saltaDist = false;
        }
        private void CreaRepo()
        {
            List<DLIB.Parametro> lo = new List<DLIB.Parametro>();
            //lo.Add(new DLIB.Parametro("userid", DLIB.Globales.Parametros.UsrId, true));
            //lo.Add(new DLIB.Parametro("fecini", fecIni.Value, true));
            //lo.Add(new DLIB.Parametro("fecfin", fecFin.Value, true));
            //lo.Add(new DLIB.Parametro("provee", txtprov.Text.Trim()));
            //lo.Add(new DLIB.Parametro("loteini", txtLoteIni.Text.Trim()));
            //lo.Add(new DLIB.Parametro("lotefin", txtLoteFin.Text.Trim()));
            List<SqlParameter> prmtr = new List<SqlParameter>();
            foreach (DLIB.Parametro pm in lo)
            {
                prmtr.Add(new SqlParameter(pm.Nombre, pm.value));
            }
            DLIB.RepoMan repo = new DLIB.RepoMan("R_07001D", prmtr);
            repo.load();
            this.visor.SetDisplayMode(DisplayMode.Normal);
            //this.Titulo = repo.Comentario;
            if (String.IsNullOrEmpty(visor.LocalReport.ReportPath))
            {
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
                    if (pm.inReport)
                    {
                        Array.Resize(ref parametr, i + 1);
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
        //private void splitter_SplitterMoved(object sender, SplitterEventArgs e)
        //{
        //    if (saltaDist) { return; }
        //   // pnlPrinDist = splitter.SplitterDistance;
        //}
    }
}
