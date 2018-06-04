﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI.baseClass
{
    public partial class easyForm : Form
    {

        public easyForm()
        {
            InitializeComponent();
        }
        public easyForm(string xtitulo)
        {
            InitializeComponent();
            SetTitulo(xtitulo);
        }
        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        //definir control de click en ControlBox con un evento

        public void SetTitulo(string texto)
        {
            this.xTitulo.Text = texto;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Maximized)
            {
                this.WindowState = FormWindowState.Normal;
            }
            else {
                this.WindowState = FormWindowState.Maximized;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel2_DoubleClick(object sender, EventArgs e)
        {
            this.button2.PerformClick();
        }

        private void easyForm_Load(object sender, EventArgs e)
        {

        }

        private void xTitulo_DoubleClick(object sender, EventArgs e)
        {
            this.button2.PerformClick();
        }
    }
}
