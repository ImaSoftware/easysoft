﻿using System;
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
            this.Titulo="Bienvenido: " + DLIB.Globales.Parametros.UsrNom;
        }

        private void Lobby_Load(object sender, EventArgs e)
        {
            easyMenu1.LLena_Menu();
        }
        private void OpenForm(DLIB.MenuInfo myInfo)
        {
            if (myInfo.Err)
            {
                MessageBox.Show("Error al llenar la entidad del menu:" + myInfo.codigo, "Alerta", MessageBoxButtons.OK);
            }
            else {
                //crear instancia
                Type elTipo = Type.GetType("GUI.Interfaz."+myInfo.CtlNom);
                if (elTipo != null) {
                    Object obj = Activator.CreateInstance(elTipo,new Object[]{ myInfo.NombreMostrar, myInfo.CtlOpt}) as Object;
                    
                    if (obj != null)
                    {
                        if (!myInfo.Inform)
                        {
                            ((baseClass.easyForm)obj).Show();
                            ((baseClass.easyForm)obj).BringToFront();
                        }
                        else {
                            TabPage page = new TabPage();

                            ((baseClass.easyForm)obj).TopLevel = false;
                            ((baseClass.easyForm)obj).FormBorderStyle = FormBorderStyle.None;
                            ((baseClass.easyForm)obj).Dock = DockStyle.Fill;
                            page.Controls.Add(((baseClass.easyForm)obj));
                            page.Tag = ((baseClass.easyForm)obj);
                            page.Text = ((baseClass.easyForm)obj).Titulo;
                            ((baseClass.easyForm)obj).Show();
                            VentanaMain.TabPages.Add(page);
                            VentanaMain.SelectedTab =page;
                            ((baseClass.easyForm)obj).barraTitulo.Visible = false;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Error al crear la instancia del Programa:" + myInfo.codigo , "Alerta", MessageBoxButtons.OK);
                    }
                }
                else
                {
                    MessageBox.Show("Nombre de Programa no es correcto:" + myInfo.CtlNom, "Alerta", MessageBoxButtons.OK);
                }
            }
        }
        private void easyMenu1_AbrirPrograma(object sender, EventArgs e)
        {
            OpenForm(((Controles.easymenubutton)sender).myInfo);
            this.mainsplit.SplitterDistance = easyMenu1.cambiaWidth();
            this.easyMenu1.soloModulo();
        }

        private void easyMenu1_AbrirNoPrograma(object sender, EventArgs e)
        {
           this.mainsplit.SplitterDistance= easyMenu1.cambiaWidth();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            if (VentanaMain.SelectedTab != null) { this.VentanaMain.TabPages.Remove(VentanaMain.SelectedTab); }
        }

        private void easyMenu1_MouseLeave(object sender, EventArgs e)
        {
           
        }

        private void keyButton_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Desea cambiar de usuario y cerrar la sesion actual?", "Confirmacion", MessageBoxButtons.YesNo) == DialogResult.Yes) {
                FrmSesion Sesion = new FrmSesion();
                Sesion.ShowDialog();
                if (Sesion.Resultado)
                {
                    DLIB.Globales.Parametros.Otra = true;
                    this.Close();
                  
                }
            }
        }
    }
}
