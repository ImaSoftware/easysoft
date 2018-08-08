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
        private string _nameReport = "";
        public string nameReport
        {
            get { return _nameReport; }
            set { _nameReport = value; }
        }
        public List<DLIB.Parametro> Paramis = new List<DLIB.Parametro>();

        int id = 0;
        private int pnlPrinDist = 0;
        private bool saltaDist = false;
        private DataSet ActDb;
        public Repform()
        {
            InitializeComponent();
            ///No borres esto si estas en REPFORM
            ///Ubicar aqui siempre el nombre del reporte en cada uno de los formularios hijos 
            ///EJ:  this.nameReport = "R_03001";
        }
        private void Repform_Load(object sender, EventArgs e)
        {
            if (DesignMode) { return; }
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
        /// <summary>
        /// Recoger los parametros desde los controles del form hijo 
        /// </summary>
        public virtual void RecogeParametros() {
        }
        private void CreaRepo()
        {
            if (String.IsNullOrEmpty(nameReport.Trim())) { MessageBox.Show("Nombre de Reporte no está definido. Verifique"); }
            List<SqlParameter> prmtr = new List<SqlParameter>();
            foreach (DLIB.Parametro pm in Paramis)
            {
                if (pm.tip != DLIB.Parametro.tipo.SoloRepo)
                    prmtr.Add(new SqlParameter(pm.Nombre, pm.value));
            }
            DLIB.RepoMan repo = new DLIB.RepoMan(nameReport, prmtr);
            repo.load();
            this.ActDb = repo.db;
            this.visor.SetDisplayMode(DisplayMode.Normal);
            //this.Titulo = repo.Comentario;
            if (String.IsNullOrEmpty(visor.LocalReport.ReportPath))
            {
                this.visor.LocalReport.ReportPath = System.IO.Directory.GetCurrentDirectory() + "\\Reportes\\"+ nameReport+ ".rdlc";
            }
            //this.WindowState = FormWindowState.Maximized;
            this.visor.ProcessingMode = ProcessingMode.Local;
            this.visor.LocalReport.DataSources.Clear();
            try
            {
                for (int j = 0; j <= repo.db.Tables.Count - 1; j++)
                {
                    if (j == 0)
                        continue;//Saltar tabla con el nombre de las tablas que siempre debe de ser la primera en el conjunto de seleccion 
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
                int i = 0;
                foreach (DLIB.Parametro pm in Paramis)
                {
                    if (pm.tip != DLIB.Parametro.tipo.SoloSQL)
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

        private void btnGenera_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            RecogeParametros();
            CreaRepo();
            Cursor = Cursors.Default;
        }

        private void visor_Drillthrough(object sender, DrillthroughEventArgs e)
        {
            LocalReport localReport = (LocalReport)e.Report;
            string fn = System.IO.Path.GetFileNameWithoutExtension(localReport.ReportPath);
            localReport.DataSources.Clear();
            for (int j = 0; j <= this.ActDb.Tables.Count - 1; j++)
            {
                if (j == 0)
                    continue;//Saltar tabla con el nombre de las tablas que siempre debe de ser la primera en el conjunto de seleccion 
                DataTable table = this.ActDb.Tables[j];
                localReport.DataSources.Add(new ReportDataSource(table.TableName, table));
            }

         
          //  localReport.DataSources.Add(new ReportDataSource("Employees",
            //    LoadEmployeesData()));
        }
        //private void splitter_SplitterMoved(object sender, SplitterEventArgs e)
        //{
        //    if (saltaDist) { return; }
        //   // pnlPrinDist = splitter.SplitterDistance;
        //}
    }
}
