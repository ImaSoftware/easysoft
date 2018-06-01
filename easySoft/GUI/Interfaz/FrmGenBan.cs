using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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

        }
        private void cargaTodo() {
            Bancos = DLIB.Globales.Parametros.connSql.TraerTabla("FRMGENBAN_002");
            if (Bancos == null)
            {
               
            }
            cmbBanco.DataSource = Bancos;
            cmbBanco.ValueMember = "codigo";
            cmbBanco.DisplayMember = "Nombre";
            cmbBanco.SelectedIndex = 0;
            cmbBanco.Update();
        }

        private void FrmGenBan_Load(object sender, EventArgs e)
        {
            cargaTodo();
        }
    }
}
