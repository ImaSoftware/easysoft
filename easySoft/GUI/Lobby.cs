using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class Lobby : baseClass.easyForm
    {
        private const int WM_SYSCOMMAND = 274;
        private const int SC_MAXIMIZE = 61488;

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        static extern int SetParent(IntPtr hWndChild, IntPtr hWndNewParent);
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        Negocio.Lobby capaNego = new Negocio.Lobby();
        public Lobby()
        {
            InitializeComponent();
            this.Titulo="Bienvenido: " + DLIB.Globales.Parametros.UsrNom;
        }

        private void Lobby_Load(object sender, EventArgs e)
        {
            try { easyMenu1.LLena_Menu(); }
            catch (Exception ex) { MessageBox.Show("No se pudo cargar el menú: " + ex.Message); Close(); }
        }
        private async Task OpenForm(DLIB.MenuInfo myInfo)
        {
            if (myInfo.Err)
            {
                MessageBox.Show("Error al llenar la entidad del menu:" + myInfo.codigo, "Alerta", MessageBoxButtons.OK);
            }
            else {
                if (myInfo.esEasy)
                {
                    TabPage page = new TabPage();
                    //page.Name = "Panel" + myInfo.codigo.ToString()
                    VentanaMain.TabPages.Add(page);
                    VentanaMain.SelectedTab = page;
                    string ruta = System.Configuration.ConfigurationManager.AppSettings["ExternalApplicationPath"];
                    //ruta: Direccion donde se encuetra la aplicacion.
                    //"": Parametro en caso de que tu aplicacion este esperando un valor
                    if (string.IsNullOrWhiteSpace(ruta) || !System.IO.Path.IsPathRooted(ruta) || !System.IO.File.Exists(ruta))
                    { VentanaMain.TabPages.Remove(page); page.Dispose(); throw new InvalidOperationException("Configure una ruta válida en ExternalApplicationPath."); }
                    ProcessStartInfo info = new ProcessStartInfo(ruta, "");
                    Process proc1 = null;
                    try
                    {
                       proc1 =  Process.Start(info);
                    }
                    catch (Exception ex)
                    {
                        VentanaMain.TabPages.Remove(page); page.Dispose();
                        MessageBox.Show("No se pudo abrir la aplicación externa: " + ex.Message);
                        return;
                    }
                    if (proc1 == null) { VentanaMain.TabPages.Remove(page); page.Dispose(); return; }
                    try
                    {
                        if (!await Task.Run(() => proc1.WaitForInputIdle(10000)) || proc1.HasExited || proc1.MainWindowHandle == IntPtr.Zero)
                            throw new InvalidOperationException("La aplicación externa no abrió una ventana a tiempo.");
                    if (page.IsDisposed || IsDisposed) return;
                    SetParent(proc1.MainWindowHandle, page.Handle);
                        SendMessage(proc1.MainWindowHandle, WM_SYSCOMMAND, SC_MAXIMIZE, 0);
                    }
                    catch (Exception ex)
                    {
                        VentanaMain.TabPages.Remove(page); page.Dispose();
                        MessageBox.Show(ex.Message);
                    }
                    finally { proc1.Dispose(); }
                }
                else {
                    //crear instancia
                    string xpr = "GUI.Interfaz.";
                    if (myInfo.CtlNom.ToUpper().Contains("FRMREP")) {
                        xpr = "GUI.Interfaz.Reportes.";
                    }
                    Type elTipo = Type.GetType(xpr+myInfo.CtlNom);
                    if (elTipo != null) {
                        Object obj = Activator.CreateInstance(elTipo,new Object[]{ myInfo.NombreMostrar, myInfo.CtlOpt}) as Object;
                    
                        if (obj != null)
                        {
                            if (!myInfo.Inform)
                            {
                                ((baseClass.easyForm)obj).Show(this);
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

                                ((baseClass.easyForm)obj).quitarBarraTitulo();

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
        }
        private async void easyMenu1_AbrirPrograma(object sender, EventArgs e)
        {
            try { await OpenForm(((Controles.easymenubutton)sender).myInfo); }
            catch (Exception ex) { MessageBox.Show("No se pudo abrir el formulario: " + ex.Message); }
            if (IsDisposed || Disposing) return;
            this.mainsplit.SplitterDistance = easyMenu1.cambiaWidth();
            this.easyMenu1.soloModulo();
        }

        private void easyMenu1_AbrirNoPrograma(object sender, EventArgs e)
        {
           this.mainsplit.SplitterDistance= easyMenu1.cambiaWidth();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            if (VentanaMain.SelectedTab != null) { var page = VentanaMain.SelectedTab; VentanaMain.TabPages.Remove(page); page.Dispose(); }
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
