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

namespace GUI
{
    public partial class Repform : baseClass.easyForm
    {
        string nameReport = "";
        List<DLIB.Parametro> Paramis = new List<DLIB.Parametro>();
        int id = 0;

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
    }
}
