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
        DataTable Generado;
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
            Generado = DLIB.Globales.Parametros.connSql.TraerTabla("LOBBY_002", null, true);
            if (Generado == null)
            {
                MessageBox.Show("Error");
                Environment.Exit(Environment.ExitCode);
            }
            if (Generado.Rows.Count == 0)
            {
                MessageBox.Show("No existen elementos de menu ", "Error", MessageBoxButtons.OK);
            }
            easymenubutton miPadre=null;
            for (int i = this.panel1.Controls.Count-1 ; i >=0 ; i--) {
                int iTabla = this.panel1.Controls.Count - 1 -i;
                easymenubutton ebutt = (easymenubutton)this.panel1.Controls[i];
                if (iTabla < Generado.Rows.Count && iTabla >=0)
                {
                    easymenubutton.Tipo xTip = (easymenubutton.Tipo)Generado.Rows[iTabla]["Tipo"];
                    string xacce = (string)Generado.Rows[iTabla]["codigoAcceso"];
                    string xctl = (Generado.Rows[iTabla]["codigo"] == null ? "" : Generado.Rows[iTabla]["codigo"].ToString());
                    ebutt.CargaOPT(xctl);
                    if (miPadre == null) {
                        miPadre = ebutt;
                    }
                    else {
                        if (ebutt.myInfo.Nivel == miPadre.myInfo.Nivel + 1)
                        {
                            miPadre.Hijos.Add(ebutt);
                            ebutt.Padre = miPadre;
                        }
                        else {
                            miPadre = ebutt;
                        }
                    }               
                    ebutt.ClickPrograma += Ebutt_ClickPrograma;
                    ebutt.Visible = ebutt.myInfo.xtip == (int)easymenubutton.Tipo.Modulo;
                }
                else {
                    ebutt.Visible = false;
                }
            }
        }

        public void Ebutt_ClickPrograma(object xsender, EventArgs e)
        {
            if (((easymenubutton)xsender).myInfo.xtip == (int)easymenubutton.Tipo.Programa) {
                OnRaiseAbrirPrograma((easymenubutton)xsender);
            }
            ProcesaClick(((easymenubutton)xsender).myInfo.codAcceso, (easymenubutton.Tipo)((easymenubutton)xsender).myInfo.xtip);
        }

        private void ProcesaClick(string codAcceso, easymenubutton.Tipo tipo)
        {
            for (int i = 0; i < this.panel1.Controls.Count; i++)
            {                
                easymenubutton ebutt = (easymenubutton)this.panel1.Controls[i];
                if (ebutt.myInfo == null){ continue ; }
                //if (ebutt.Padre == null) { continue; }
                if (ebutt.myInfo.codAcceso.StartsWith(codAcceso)&& !ebutt.myInfo.codAcceso.Equals(codAcceso)) {
                    if (tipo == easymenubutton.Tipo.Modulo && ebutt.myInfo.xtip != (int)easymenubutton.Tipo.Modulo && ebutt.myInfo.Nivel == ((int)tipo) + 2) {
                        ebutt.Visible = !ebutt.Visible ;
                    }
                    if (tipo == easymenubutton.Tipo.Modulo && ebutt.myInfo.xtip != (int)easymenubutton.Tipo.Modulo && ebutt.myInfo.Nivel > ((int)tipo) + 2)
                    {
                        ebutt.Visible = (ebutt.Visible ? !ebutt.Visible : !ebutt.Padre.contraido);
                    }
                    if (tipo == easymenubutton.Tipo.Menu && ebutt.myInfo.xtip != (int)easymenubutton.Tipo.Menu)
                    {
                        ebutt.Visible = !ebutt.Visible; 
                    }
                }
            }
        }
    }
}
