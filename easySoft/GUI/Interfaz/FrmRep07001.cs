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

namespace GUI.Interfaz
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
            lo.Add(new DLIB.Parametro("userid", "HOLGER"));
            lo.Add(new DLIB.Parametro("fecini", fecIni.Value));
            lo.Add(new DLIB.Parametro("fecfin", fecFin.Value));
            List<SqlParameter> prmtr = new List<SqlParameter>();
            foreach (DLIB.Parametro pm in lo)
            {
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
                Array.Resize(ref parametr, lo.Count);
                int i = 0;
                foreach (DLIB.Parametro pm in lo)
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
        
        private void FrmRep07001_Load(object sender, EventArgs e)
        {

            this.visor.RefreshReport();
        }
    }
}
