using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI.Controles
{
    public partial class easymenubutton : UserControl
    {
        Negocio.Lobby capaNego = new Negocio.Lobby();
        Color ModuColor;
        Color MenuColor;
        Color ProgColor;
        public DLIB.MenuInfo myInfo;
        public event EventHandler ClickPrograma;
        protected virtual void OnRaiseClickPrograma()
        {
            EventHandler handler = ClickPrograma;
            handler(this, new EventArgs ());//Provoca el evento
        }
        public enum Tipo { Modulo, Menu,  Programa }
        Tipo miTipo = Tipo.Modulo;
        public bool contraido=true;
        public easymenubutton Padre;
        public List<easymenubutton> Hijos= new List<easymenubutton>();
        public easymenubutton()
        {
            InitializeComponent();

        }
        public void CargaOPT(string xcodigo)
        {
            //Tipo xtip, string Desc, string image_Key, string accessCode, string xprgCod
            myInfo = capaNego.getFrmInfo(xcodigo);
            miTipo = (Tipo)myInfo.xtip;
            ModuColor = Color.FromArgb(32, 57, 86);
            MenuColor = Color.FromArgb(25, 48, 72);
            ProgColor = Color.FromArgb(25, 48, 72);
            if (miTipo == Tipo.Programa)
            {
                button1.ImageKey = "";
               button2.Visible  = false;
            }
            switch (miTipo)
            {
                case Tipo.Modulo:
                    button2.BackColor = ModuColor;
                    button1.BackColor = ModuColor;
                    this.BackColor = ModuColor;
                    break;
                case Tipo.Menu:
                    button2.BackColor = MenuColor;
                    button1.BackColor = MenuColor;
                    this.BackColor = MenuColor;
                    break;
                case Tipo.Programa:
                    button1.ImageKey = "";
                    button2.BackColor = ProgColor;
                    button1.BackColor = ProgColor;
                    this.BackColor = ProgColor;
                    break;
                default:
                    button2.BackColor = ModuColor;
                    button1.BackColor = ModuColor;
                    this.BackColor = ModuColor;
                    break;
            }
            switch (myInfo.image_Key)
            {
                case  "book":
                    button2.BackgroundImage = GUI.Properties.Resources.book;
                    break;
                case "building":
                    button2.BackgroundImage = GUI.Properties.Resources.building;
                    break;
                case "employee":
                    button2.BackgroundImage = GUI.Properties.Resources.employee;
                    break;
                case "give_money":
                    button2.BackgroundImage = GUI.Properties.Resources.give_money;
                    break;
                case "growth":
                    button2.BackgroundImage = GUI.Properties.Resources.growth;
                    break;
                case "hand":
                    button2.BackgroundImage = GUI.Properties.Resources.hand;
                    break;
                case "home":
                    button2.BackgroundImage = GUI.Properties.Resources.home;
                    break;
                case "warehouse":
                    button2.BackgroundImage = GUI.Properties.Resources.warehouse;
                    break;
                case "worker":
                    button2.BackgroundImage = GUI.Properties.Resources.worker;
                    break;
                case "create":
                    button2.BackgroundImage = GUI.Properties.Resources.create;
                    break;
                case "buy":
                    button2.BackgroundImage = GUI.Properties.Resources.buy;
                    break;
                case "sell":
                    button2.BackgroundImage = GUI.Properties.Resources.sell;
                    break;
                case "line":
                    button2.BackgroundImage = GUI.Properties.Resources.line; 
                    break;
                default:
                    button2.BackgroundImage = null;
                    break;
            }
            button1.Text = myInfo.NombreMostrar;
            if (miTipo == Tipo.Programa)
            {
                button1.ImageKey = "";
            }
            button2.BackgroundImageLayout = ImageLayout.Zoom;
            //seteando tooltip
            if (this.myInfo.xtip == (int)Tipo.Modulo)
            {
                btnToolTip.SetToolTip(button2, myInfo.NombreMostrar);

            }
            else {
                btnToolTip.SetToolTip(button1, myInfo.Desc);
            }
        }
        
    

        private void button1_Click(object sender, EventArgs e)
        {
           
            if (button1.ImageKey.Equals("arrow-down.png"))
            {
                button1.ImageKey = " ";
                contraido = false;
            }
            else
            {
                button1.ImageKey = "arrow-down.png";
                contraido = true;
            }
            OnRaiseClickPrograma();
        }

        private void button1_MouseHover(object sender, EventArgs e)
        {
            
        }
    }
}
