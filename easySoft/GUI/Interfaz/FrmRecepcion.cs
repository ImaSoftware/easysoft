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

        public FrmRecepcion(string titulo, string args) : this()
        {
            Titulo = titulo;
        }

        private async void button4_Click(object sender, EventArgs e)
        {
            try
            {
                button4.Enabled = false;
                miPuerto.ReadTimeout = 5000;
                textBox1.Text = await Task.Run(() =>
                {
                    try { miPuerto.Open(); return miPuerto.ReadLine(); }
                    finally { if (miPuerto.IsOpen) miPuerto.Close(); }
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally { if (!IsDisposed) button4.Enabled = true; }
        }
    }
}
