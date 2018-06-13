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
using System.IO;
namespace GUI.Interfaz
{
    public partial class FrmGenBan : baseClass.easyForm
    {
        DataTable Bancos = new DataTable();
        DataTable Roles = new DataTable();
        public FrmGenBan()
        {
            InitializeComponent();
        }
        public FrmGenBan(string xtitulo, string args)
        {
            InitializeComponent();
            this.Titulo=xtitulo;
        }

        private void btnGenera_Click(object sender, EventArgs e)
        {
            generarArchivo();
        }
        private void generarArchivo(){
            if (dgvRoles.SelectedRows.Count == 0) { return; }
            if (dgvRoles.SelectedRows.Count > 1) { if (MessageBox.Show("Mas de un rol escojido. Desea continuar?", "Confirmacion", MessageBoxButtons.YesNo) == DialogResult.No) { return; } }
            
            //escoger la ruta de guardado 
            string fileName = "";
            SaveFileDialog sf = new SaveFileDialog();
            sf.Filter = "Texto Plano|*.txt";
            if (sf.ShowDialog() != DialogResult.OK)
            {
                return;
            }
            string Ruta = Path.GetDirectoryName(sf.FileName);
            //EXTRAER TIPO, Y FECHAS 
            for (int i = 0; i < dgvRoles.SelectedRows.Count; i++)
            {
                //string cTipo = ((DataRowView)dgvRoles.SelectedRows[i].DataBoundItem).Row[0].ToString();
                string cnomrep = dgvRoles.SelectedRows[i].Cells[1].Value.ToString();
                string cfecdesde = dgvRoles.SelectedRows[i].Cells[2].Value.ToString();
                string cfechasta = dgvRoles.SelectedRows[i].Cells[3].Value.ToString();
                string cbanco = cmbBanco.SelectedValue.ToString().Trim();

                List<SqlParameter> myList = new List<SqlParameter>();
                myList.Add(new SqlParameter("@desde", cfecdesde));
                myList.Add(new SqlParameter("@hasta", cfechasta));
                myList.Add(new SqlParameter("@bcodesde", cbanco));
                string consulta = ((DataRowView)cmbBanco.SelectedItem).Row["consulta"].ToString().Trim();
                string tipgen = ((DataRowView)cmbBanco.SelectedItem).Row["tipgen"].ToString().Trim();
                DataTable Generado = DLIB.Globales.Parametros.connSql.TraerTabla(consulta, myList);
                if (Generado == null)
                {
                    continue;
                }
                if (Generado.Rows.Count == 0) {
                    MessageBox.Show("No existen registros para exportar ", "Error", MessageBoxButtons.OK);
                    continue;
                }
                fileName = DLIB.DFUNC.GetSafeFilename(Path.GetFileNameWithoutExtension(sf.FileName) + "_" + cnomrep + "_" +  cfecdesde + "-" + cfechasta + "-" + i.ToString() );
                //Recorrer lo generado y poner en el archivo correcto 
                try
                {
                    if (String.Equals(tipgen, "T"))
                    {
                        var builder = new StringBuilder();
                        foreach (DataRow row in Generado.Rows)
                        {
                            foreach (var cell in row.ItemArray)
                            {
                                builder.Append(cell.ToString());
                                if (cell != row.ItemArray[((Array)row.ItemArray).Length - 1])
                                    builder.Append("\t");
                            }
                            builder.Append(Environment.NewLine);
                        }

                        var file = new FileStream(Ruta + "\\" + fileName + ".txt", FileMode.Create);
                        var writer = new StreamWriter(file);
                        writer.Write(builder.ToString());
                        writer.Flush();
                        writer.Close();
                    }
                    else { 
                        if(String.IsNullOrEmpty(tipgen))
                        {
                            //Pass the filepath and filename to the StreamWriter Constructor
                            StreamWriter sw = null;
                            StreamWriter sw2 = null;
                            foreach (DataRow dgen in Generado.Rows)
                            {
                                if (String.Equals(dgen["TIPO"], "EX"))
                                {
                                    if (sw2 == null)
                                    {
                                        sw2 = new StreamWriter(Ruta + "\\" + fileName + "EXTERNOS.txt", false);
                                    }
                                    sw2.WriteLine(dgen["RES"]);
                                }
                                else
                                {
                                    if (sw == null)
                                    {
                                        sw = new StreamWriter(Ruta + "\\" + fileName + ".txt", false);
                                    }
                                    sw.WriteLine(dgen["RES"]);
                                }
                            }
                            //Close the file
                            if (sw2 != null) { sw2.Close(); }
                            if (sw != null) { sw.Close(); }
                        }
                    }
                }
                catch (Exception e)
                {
                    MessageBox.Show("Exception: " + e.Message);
                    continue;
                }
                finally
                {
                  

                }
            }
            MessageBox.Show("El proceso ha finalizado");
        }
        private void cargaGrid()
        {
            List<SqlParameter> myList = new List<SqlParameter>();
            myList.Add(new SqlParameter("@fecini", fechaini.Value));
            myList.Add(new SqlParameter("@fecfin", fechahasta.Value));
            Roles = DLIB.Globales.Parametros.connSql.TraerTabla("FRMGENBAN_001", myList);
            if (Roles == null)
            {
                MessageBox.Show("Error al traer los datos", "Error", MessageBoxButtons.OK);
            }
            dgvRoles.DataSource = Roles;
            dgvRoles.Update();
        }

        private void cargaCMB() {
            
            Bancos = DLIB.Globales.Parametros.connSql.TraerTabla("FRMGENBAN_002");
            if (Bancos == null)
            {
                MessageBox.Show("Error al traer los datos", "Error", MessageBoxButtons.OK);
            }
            cmbBanco.DataSource = Bancos;
            cmbBanco.ValueMember = "codigo";
            cmbBanco.DisplayMember = "Nombre";
            cmbBanco.SelectedIndex = 0;
            cmbBanco.Update();
            
        }

        private void FrmGenBan_Load(object sender, EventArgs e)
        {
            cargaCMB();
            cargaGrid();
            int var_mesActual = DateTime.Now.Month; // obtengo el mes actual
            int var_anio = DateTime.Now.Year; // obtengo el año actual
            int var_mesSiguiente = DateTime.Now.Month + 1; // obtengo el mes siguiente
            fechaini.Value = Convert.ToDateTime("01/" + var_mesActual + "/" + var_anio);// pongo el 1 porque siempre es el primer día obvio
            fechahasta.Value = Convert.ToDateTime("01/" + var_mesSiguiente + "/" + var_anio).AddDays(-1); //resto un día al mes y con esto obtengo el ultimo día
                                                                                                                   //fin

        }

        private void fechahasta_ValueChanged(object sender, EventArgs e)
        {
            cargaGrid();
        }

        private void dgvRoles_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            generarArchivo();
        }
    }
}
