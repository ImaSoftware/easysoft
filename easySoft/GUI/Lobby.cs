using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class Lobby : baseClass.easyForm
    {

        Negocio.Lobby capaNego = new Negocio.Lobby();

        public Lobby()
        {
            InitializeComponent();
            this.SetTitulo("Bienvenido: " + DLIB.Globales.Parametros.UsrNom);
        }

        private void Lobby_Load(object sender, EventArgs e)
        {
            LLenaTree();

        }
        private void LLenaTree() {

        }

        private void OpenForm(string xcodigo) {

            DLIB.FrmInfo myInfo = capaNego.getFrmInfo(xcodigo);
            if (myInfo.Err)
            {
                MessageBox.Show("Error al llenar la entidad del Programa:" + xcodigo, "Alerta", MessageBoxButtons.OK);
            }
            else {
                //crear instancia
                Type elTipo = Type.GetType("GUI.Interfaz."+myInfo.CtlNom);
                if (elTipo != null) {
                    Object obj = Activator.CreateInstance(elTipo,new Object[]{ myInfo.NombreMostrar, myInfo.CtlOpt}) as Object;
                    if (obj != null)
                    {
                        ((baseClass.easyForm)obj).Show();
                        ((baseClass.easyForm)obj).BringToFront();
                    }
                    else
                    {
                        MessageBox.Show("Error al crear la instancia del Programa:" + xcodigo, "Alerta", MessageBoxButtons.OK);
                    }
                }
                else
                {
                    MessageBox.Show("Nombre de Programa no es correcto:" + myInfo.CtlNom, "Alerta", MessageBoxButtons.OK);
                }
               

            }

        }

        private void button4_Click(object sender, EventArgs e)
        {
            //Aqui para carga directa de formulario en modo de depuracion
            OpenForm("2");
        }
    }
}
