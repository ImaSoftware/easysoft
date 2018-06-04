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
            this.SetTitulo(xtitulo);
        }

        private void btnGenera_Click(object sender, EventArgs e)
        {
            generarArchivo();
        }
        private void generarArchivo(){
            if (dgvRoles.SelectedRows.Count == 0) { return; }
            if (dgvRoles.SelectedRows.Count > 1) { if (MessageBox.Show("Mas de un rol escojido. Desea continuar?", "Confirmacion", MessageBoxButtons.YesNo) == DialogResult.No) { return; } }
            //EXTRAER TIPO, Y FECHAS 
            for (int i = 0; i < dgvRoles.SelectedRows.Count; i++)
            {
                string cTipo = ((DataRowView)dgvRoles.SelectedRows[i].DataBoundItem).Row[0].ToString();
                string cfecdesde = dgvRoles.SelectedRows[i].Cells[2].ToString();
                string cfechasta = dgvRoles.SelectedRows[i].Cells[3].ToString();
                string cbanco = cmbBanco.SelectedValue.ToString();



            }
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
