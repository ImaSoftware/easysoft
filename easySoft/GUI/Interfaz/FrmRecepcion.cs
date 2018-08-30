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
    public partial class FrmRecepcion : baseClass.easyForm 
    {
        public FrmRecepcion()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                miPuerto.Open();
                textBox1.Text = miPuerto.ReadLine();
                miPuerto.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
          

        }
    }
}
