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
        public event EventHandler AbrirNoPrograma = delegate { };
        int[] splitDistances = new int[3] { 71, 83, 300 };
        public enum SplitterMode { Solo_Botones, Botones_y_Barra, Completo }
        protected virtual void OnRaiseAbrirPrograma(object xbtn)
        {
            AbrirPrograma(xbtn, EventArgs.Empty);
        }
        protected virtual void OnRaiseAbrirNoPrograma(object xbtn)
        {
            AbrirNoPrograma(xbtn, EventArgs.Empty);
        }
        SplitterMode ModoSplitter = SplitterMode.Solo_Botones;
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

            for (int i = this.panel1.Controls.Count - 1; i >= 0; i--)
            {
                int iTabla = this.panel1.Controls.Count - 1 - i;
                easymenubutton ebutt = (easymenubutton)this.panel1.Controls[i];
                if (iTabla < Generado.Rows.Count && iTabla >= 0)
                {
                    easymenubutton.Tipo xTip = (easymenubutton.Tipo)Generado.Rows[iTabla]["Tipo"];
                    string xacce = (string)Generado.Rows[iTabla]["codigoAcceso"];
                    string xctl = (Generado.Rows[iTabla]["codigo"] == null ? "" : Generado.Rows[iTabla]["codigo"].ToString());
                    ebutt.CargaOPT(xctl);
                    ebutt.Name = "menubtn" + xctl;
                    if (ebutt.myInfo.Nivel != 1)
                    {
                        //siempre va a ser niveles mayores a uno 
                        easymenubutton miPadre = getFather(ebutt);
                        if (miPadre != null)
                        {
                            miPadre.Hijos.Add(ebutt);
                            ebutt.Padre = miPadre;
                        }

                    }
                    ebutt.ClickPrograma += Ebutt_ClickPrograma;
                    ebutt.Visible = ebutt.myInfo.xtip == (int)easymenubutton.Tipo.Modulo;
                }
                else
                {
                    ebutt.Visible = false;
                }

            }
        }
        private easymenubutton getFather(easymenubutton xboton)
        {
            easymenubutton ret;
            try
            {
                string codAcceso = xboton.myInfo.codAcceso;
                var foundIndexes = new List<int>();
                for (int i = 0; i < codAcceso.Length; i++)
                {
                    if (codAcceso[i] == '.')
                        foundIndexes.Add(i);
                }
                string fcode = codAcceso.Substring(0, 1 + foundIndexes[foundIndexes.Count - 2]);
                string codCode = Generado.Select(String.Format("codigoAcceso='{0}'", fcode))[0][0].ToString();
                object button = this.panel1.Controls.Find("menubtn" + codCode.ToString().Trim(), false)[0];
                ret = (easymenubutton)button;
            }
            catch (Exception ex)
            {
                ret = null;
            }
            return ret;

        }
        private void Ebutt_ClickPrograma(object xsender, EventArgs e)
        {
            ProcesaClick(((easymenubutton)xsender).myInfo.codAcceso, (easymenubutton.Tipo)((easymenubutton)xsender).myInfo.xtip);
            if (((easymenubutton)xsender).myInfo.xtip == (int)easymenubutton.Tipo.Programa)
            {
                ModoSplitter = SplitterMode.Solo_Botones;
                OnRaiseAbrirPrograma((easymenubutton)xsender);
            }
            else {
                OnRaiseAbrirNoPrograma((easymenubutton)xsender);
            }
           
        }

        private void ProcesaClick(string codAcceso, easymenubutton.Tipo tipo)
        {
            for (int i = 0; i < this.panel1.Controls.Count; i++)
            {
                easymenubutton ebutt = (easymenubutton)this.panel1.Controls[i];
                if (ebutt.myInfo == null) { continue; }
                // if (ebutt.Padre == null) { continue; }
                if (ebutt.myInfo.codAcceso.StartsWith(codAcceso) && !ebutt.myInfo.codAcceso.Equals(codAcceso))
                {
                    if (tipo == easymenubutton.Tipo.Modulo && ebutt.myInfo.xtip != (int)easymenubutton.Tipo.Modulo && ebutt.myInfo.Nivel == ((int)tipo) + 2)
                    {
                        ebutt.Visible = !ebutt.Visible;
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
            if (tipo == easymenubutton.Tipo.Modulo)
            {
                ModoSplitter = SplitterMode.Completo;
            }
        }
        public int cambiaWidth()
        {
            return  splitDistances[(int)ModoSplitter];
        }
        public void  soloModulo() {
            for (int i = this.panel1.Controls.Count - 1; i >= 0; i--)
            {
                int iTabla = this.panel1.Controls.Count - 1 - i;
                easymenubutton ebutt = (easymenubutton)this.panel1.Controls[i];
                if (ebutt.myInfo !=null)
                {
                    if (ebutt.myInfo.Nivel != 1)
                    {
                        //siempre va a ser niveles mayores a uno 
                        ebutt.Visible = false;
                    }
                }
            }
        }
    }
}
