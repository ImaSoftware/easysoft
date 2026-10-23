using System;
using System.Windows.Forms;
using System.Xml;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.IO;
namespace proofC
{

    public partial class Form1 : Form
    {
        string sRes = "";
        string fullfilename = "";
        int parID = 2;
        string nomMethod = "autorizacionComprobante";
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            //Solo por probar esquema

            //    Net_A.Net_XML juas = new Net_A.Net_XML();
            //   juas.validaEsquema("D:\\3110201701099221334500110010020000000412014122211.xml", "D:\\xsd\\factura.xsd");
            //    return;
            //Para consumo sin dll
            //darle();
            if (rbAutoriza.Checked)
            {
                Net_A.cons_Server jua = new Net_A.cons_Server();
                string nM = "autorizacionComprobante";
                sRes = jua.consumirServicio(nM, txtIn.Text, chkPrueba.Checked);
                var path = Path.GetTempPath();
                var fileName = Guid.NewGuid().ToString() + ".xml";
                fullfilename = Path.Combine(path, fileName);
                //write the contents of your xml string to the temporary file we just created
                File.WriteAllText(fullfilename, sRes); //xmlText is your xml string
                                                       //"navigate" to the file
                wB1.Navigate(fullfilename); //webBrowser is your WebBrowser control
            }
            else if (rbRecibe.Checked)
            {
                Net_A.cons_Server jua = new Net_A.cons_Server();
                string nM = "validarComprobante";
                sRes = jua.consumirServicio(nM, txtIn.Text,chkPrueba.Checked );
                var path = Path.GetTempPath();
                var fileName = Guid.NewGuid().ToString() + ".xml";
                fullfilename = Path.Combine(path, fileName);
                //write the contents of your xml string to the temporary file we just created
                File.WriteAllText(fullfilename, sRes); //xmlText is your xml string
                                                       //"navigate" to the file
                wB1.Navigate(fullfilename); //webBrowser is your WebBrowser control

            }
        }


            ////Para consumo con DLL pruebaRR
            //if (txtIn.Text.IndexOf(".xml") > 0)
            //{
            //    Net_A.cons_Server jua = new Net_A.cons_Server();
            //    sRes = jua.consumirServicio("autorizacionComprobante", txtIn.Text);
            //    var path = Path.GetTempPath();
            //    var fileName = Guid.NewGuid().ToString() + ".xml";
            //    fullfilename = Path.Combine(path, fileName);
            //    //write the contents of your xml string to the temporary file we just created
            //    File.WriteAllText(fullfilename, sRes); //xmlText is your xml string
            //                                           //"navigate" to the file
            //    wB1.Navigate(fullfilename); //webBrowser is your Web
               
        
      
   

        private void wB1_Navigated(object sender, WebBrowserNavigatedEventArgs e)
        {
            if (System.IO.File.Exists(fullfilename))
            { try { System.IO.File.Delete(fullfilename); } catch (System.IO.IOException ee) { return; } }
        }

        private void rdAutoriza_CheckedChanged(object sender, EventArgs e)
        {
            txtIn.Text = "3110201701099004945900120010060025183723128989415";
            label1.Text = "Clave de acceso:";
        }

        private void rdRecibe_CheckedChanged(object sender, EventArgs e)
        {
            label1.Text = "Ruta de comprobante:";
            this.txtIn.Text = "D:\\3110201701099221334500110010020000000412014122211.xml";
        }

        private void rbMail_CheckedChanged(object sender, EventArgs e)
        {

        }
    }


}