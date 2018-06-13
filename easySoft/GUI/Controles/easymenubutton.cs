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
                pictureBox1.Visible = false;
            }
            switch (miTipo)
            {
                case Tipo.Modulo:
                    pictureBox1.BackColor = ModuColor;
                    button1.BackColor = ModuColor;
                    this.BackColor = ModuColor;
                    break;
                case Tipo.Menu:
                    pictureBox1.BackColor = MenuColor;
                    button1.BackColor = MenuColor;
                    this.BackColor = MenuColor;
                    break;
                case Tipo.Programa:
                    button1.ImageKey = "";
                    pictureBox1.BackColor = ProgColor;
                    button1.BackColor = ProgColor;
                    this.BackColor = ProgColor;
                    break;
                default:
                    pictureBox1.BackColor = ModuColor;
                    button1.BackColor = ModuColor;
                    this.BackColor = ModuColor;
                    break;
            }
            switch (myInfo.image_Key)
            {
                case  "book":
                    pictureBox1.BackgroundImage = GUI.Properties.Resources.book;
                    break;
                case "building":
                    pictureBox1.BackgroundImage = GUI.Properties.Resources.building;
                    break;
                case "employee":
                    pictureBox1.BackgroundImage = GUI.Properties.Resources.employee;
                    break;
                case "give_money":
                    pictureBox1.BackgroundImage = GUI.Properties.Resources.give_money;
                    break;
                case "growth":
                    pictureBox1.BackgroundImage = GUI.Properties.Resources.growth;
                    break;
                case "hand":
                    pictureBox1.BackgroundImage = GUI.Properties.Resources.hand;
                    break;
                case "home":
                    pictureBox1.BackgroundImage = GUI.Properties.Resources.home;
                    break;
                case "warehouse":
                    pictureBox1.BackgroundImage = GUI.Properties.Resources.warehouse;
                    break;
                case "worker":
                    pictureBox1.BackgroundImage = GUI.Properties.Resources.worker;
                    break;
                case "create":
                    pictureBox1.BackgroundImage = GUI.Properties.Resources.create;
                    break;
                case "buy":
                    pictureBox1.BackgroundImage = GUI.Properties.Resources.buy;
                    break;
                case "sell":
                    pictureBox1.BackgroundImage = GUI.Properties.Resources.sell;
                    break;
                case "line":
                    pictureBox1.BackgroundImage = GUI.Properties.Resources.line; ;
                    break;
                default:
                    pictureBox1.BackgroundImage = pictureBox1.InitialImage;
                    break;
            }
            button1.Text = myInfo.NombreMostrar;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (miTipo == Tipo.Programa) {
                button1.ImageKey = "";
            }
            if (button1.ImageKey.Equals("arrow-down.png"))
            {
                button1.ImageKey = "arrow-up.png";
            }
            else
            {
                button1.ImageKey = "arrow-down.png";
            }
            OnRaiseClickPrograma();
        }
    }
}
