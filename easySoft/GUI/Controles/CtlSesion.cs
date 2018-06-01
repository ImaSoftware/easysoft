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
            handler(this,null);//Provoca el evento
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
          
        }


        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (!DLIB.Globales.Parametros.Inicia_Sesion(System.Configuration.ConfigurationManager.ConnectionStrings[1].ConnectionString, txtusernom.Text, txtuserpwd.Text, (int)cmbEmpresas.SelectedValue))
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
                _Acceso = true;
            }
           
        }
        public void loader()
        {
            DLIB.Globales.Parametros.CadenaConexionRoot = System.Configuration.ConfigurationManager.ConnectionStrings[1].ConnectionString;
            Empresas = DLIB.Globales.Parametros.connSql.TraerTabla("LOGGIN_001");
            if (Empresas == null)
            {
                Environment.Exit(Environment.ExitCode);
            }
            cmbEmpresas.DataSource = Empresas;
            cmbEmpresas.ValueMember = "codcia";
            cmbEmpresas.DisplayMember = "Nombre";
            cmbEmpresas.SelectedIndex = 0;
            cmbEmpresas.Update();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            _Acceso = false;
            OnRaiseResultado();
        }
    }
}
