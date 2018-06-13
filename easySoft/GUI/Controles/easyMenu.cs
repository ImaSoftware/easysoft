using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace GUI.Controles
{
    public partial class easyMenu : UserControl
    {
        public event EventHandler AbrirPrograma = delegate { };

        protected virtual void OnRaiseAbrirPrograma(object xbtn)
        {
            AbrirPrograma(xbtn, EventArgs.Empty);
        }

        public easyMenu()
        {
            InitializeComponent();
        }

        public void LLena_Menu()
        {
            DataTable Generado = DLIB.Globales.Parametros.connSql.TraerTabla("LOBBY_002",null,true);
            if (Generado == null)
            {
                MessageBox.Show("Error");
                Environment.Exit(Environment.ExitCode);
            }
            if (Generado.Rows.Count == 0)
            {
                MessageBox.Show("No existen elementos de menu ", "Error", MessageBoxButtons.OK);
            }
            for(int i =0;i<this.panel1.Controls.Count;i++) {
                easymenubutton ebutt = (easymenubutton)this.panel1.Controls[i];
                if (i < Generado.Rows.Count)
                {
                    easymenubutton.Tipo xTip = (easymenubutton.Tipo)Generado.Rows[i]["Tipo"];
                    string xacce = (string)Generado.Rows[i]["codigoAcceso"];
                    string xctl = (Generado.Rows[i]["codigo"] == null ? "" : Generado.Rows[i]["codigo"].ToString());
                    ebutt.CargaOPT(xctl);
                    ebutt.ClickPrograma += Ebutt_ClickPrograma;
                }
                else {
                    ebutt.Visible = false;
                }
            }
        }
        
        public void Ebutt_ClickPrograma(object xsender, EventArgs e)
        {
            OnRaiseAbrirPrograma((easymenubutton)xsender);
        }
    }
}
