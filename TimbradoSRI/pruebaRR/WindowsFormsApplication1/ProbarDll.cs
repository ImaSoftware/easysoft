using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Net_A;


namespace WindowsFormsApplication1
{
    public partial class ProbarDll : Form
    {
        public ProbarDll()
        {
            InitializeComponent();
            this.textBox1.Text = "2811201701091816137300120010020000000032010011811";
            this.textBox2.Text = "";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //Application.Exit;
            Environment.Exit(0);
        }

        private void ProbarDll_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.textBox2.Text = Net_A.myClassH.consumirServ(parUrl, nomMethod, contenido);
        {

            }
    }
}
