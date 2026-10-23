using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;

namespace GUI.Interfaz
{
    public partial class CtlSesion : UserControl
    {
        public event EventHandler Resultado;
        protected virtual void OnRaiseResultado(){
            EventHandler handler = Resultado;
            if (handler != null) handler(this, EventArgs.Empty);//Provoca el evento
        }
        DataTable Empresas = new DataTable();
        private bool _Acceso =false;
        public bool Acceso
        {
            get { return _Acceso; }
            // set { _CadenaConexion = value; }
        }

        public CtlSesion()
        {
            InitializeComponent();
            string[] localCNF = DLIB.DFUNC.UsrWinReg();
            txtusernom.Text = (string.IsNullOrEmpty(localCNF[0])) ? String.Empty :localCNF[0];
            if (!String.IsNullOrEmpty(localCNF[1]))
            { cmbEmpresas.SelectedValue = localCNF[1]; }
            if (!string.IsNullOrEmpty(txtusernom.Text)) { txtuserpwd.Focus(); } else { txtusernom.Focus(); }
        }


        private async void button1_Click(object sender, EventArgs e)
        {
            if (cmbEmpresas.SelectedValue == null || string.IsNullOrWhiteSpace(txtusernom.Text) || string.IsNullOrEmpty(txtuserpwd.Text))
            { MessageBox.Show("Seleccione empresa e ingrese usuario y contraseña."); return; }
            string user = txtusernom.Text;
            string password = txtuserpwd.Text;
            int company = Convert.ToInt32(cmbEmpresas.SelectedValue);
            Enabled = false;
            _Acceso = false;
            try
            {
                string connection = DLIB.RuntimeConfig.RootConnectionString;
                if (!await Task.Run(() => DLIB.Globales.Parametros.Inicia_Sesion(connection, user, password, company)))
                {
                    MessageBox.Show("Combinación inválida de parámetros para inicio de sesion", "ERROR CONEXION", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    _Acceso = true;
                    OnRaiseResultado();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error de conexión:" +Environment.NewLine  +  ex.Message, "ERROR CONEXION", MessageBoxButtons.OK, MessageBoxIcon.Information);
                _Acceso = false;
            }
            finally { if (!IsDisposed) { Enabled = true; txtuserpwd.Clear(); } }
           
        }

        public async Task loader()
        {
            Enabled = false;
            try
            {
            DLIB.Globales.Parametros.CadenaConexionRoot = DLIB.RuntimeConfig.RootConnectionString;
            Empresas = await Task.Run(() => DLIB.Globales.Parametros.connSql.TraerTabla("LOGGIN_001",null,true));
            if (IsDisposed) return;
            if (Empresas == null)
            {
                throw new InvalidOperationException("No se pudieron cargar las empresas.");
            }
            cmbEmpresas.DataSource = Empresas;
            cmbEmpresas.ValueMember = "codcia";
            cmbEmpresas.DisplayMember = "Nombre";
            if (Empresas.Rows.Count == 0) throw new InvalidOperationException("No existen empresas configuradas.");
            cmbEmpresas.SelectedIndex = 0;
            string[] remembered = DLIB.DFUNC.UsrWinReg();
            int rememberedCompany;
            if (int.TryParse(remembered[1], out rememberedCompany)) cmbEmpresas.SelectedValue = rememberedCompany;
            }
            finally { if (!IsDisposed) Enabled = true; }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            _Acceso = false;
            OnRaiseResultado();
        }
    }
}
