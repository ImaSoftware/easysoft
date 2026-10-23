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
        //int parID = 2;
       // string nomMethod = "autorizacionComprobante";
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;

            ejecutar();
            
            this.Cursor = Cursors.Default;
        }
        private void ejecutar() {
            if (rbAutoriza.Checked)
            {
                SRI_LIB.NET_WServ jua = new SRI_LIB.NET_WServ();
                string nM = "autorizacionComprobante";
                sRes = jua.consumirServicio(nM, txtIn.Text, chkPrueba.Checked);
                if (jua.Error)
                {
                    MessageBox.Show(jua.ErrMsg);
                    return;
                }
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
                SRI_LIB.NET_WServ jua = new SRI_LIB.NET_WServ();
                string nM = "validarComprobante";
                sRes = jua.consumirServicio(nM, txtIn.Text, chkPrueba.Checked);
                if (jua.Error)
                {
                    MessageBox.Show(jua.ErrMsg);
                    return;
                }
                var path = Path.GetTempPath();
                var fileName = Guid.NewGuid().ToString() + ".xml";
                fullfilename = Path.Combine(path, fileName);
                //write the contents of your xml string to the temporary file we just created
                File.WriteAllText(fullfilename, sRes); //xmlText is your xml string
                                                       //"navigate" to the file
                wB1.Navigate(fullfilename); //webBrowser is your WebBrowser control

            }
            else if (rbFirmado.Checked)
            {
                string[] parMS = txtIn.Text.Trim().Split(';');
                if (parMS.Length != 4)
                {
                    MessageBox.Show("Respetar el formato de entrada de parámetros: 'rutaCertificado; claveCertificado;  rutaXMLOut;rutaXML'");
                    return;
                }
                SRI_LIB.Net_Sign MySign = new SRI_LIB.Net_Sign();
                MySign.SignXml(parMS[0], parMS[1],  parMS[3], parMS[2]);
                if (MySign.Error)
                {
                    MessageBox.Show("Error: " + MySign.ErrMsg);
                    return;
                }
                wB1.Navigate(parMS[2]); //webBrowser is your WebBrowser control

            }
            else if (rbXSD.Checked)
            {
                string[] parMS = txtIn.Text.Trim().Split(';');
                if (parMS.Length != 2)
                {
                    MessageBox.Show("Respetar el formato de entrada de parámetros: 'rutaXML;rutaXSD'");
                    return;
                }
                SRI_LIB.XML_Object jua = new SRI_LIB.XML_Object();
                bool res = jua.validaEsquema(parMS[0], parMS[1]);
                if (!res)
                {
                    string sres = "";
                    foreach (SRI_LIB.XML_Object.ResError s in jua.Errores)
                    {
                        sres = sres + Environment.NewLine + s.Message;
                    }
                    MessageBox.Show("Error: " + sres);
                }
            }
            else if (rbVerify.Checked)
            {
                //Verificacion de firma
                SRI_LIB.Net_Sign MySign = new SRI_LIB.Net_Sign();
                if (!MySign.validSign(txtIn.Text))
                {
                    MessageBox.Show("Error: " + MySign.ErrMsg);
                }else
                    MessageBox.Show("Firma válida");
            }
            else if (rbMail.Checked)
            {
                string[] parMS = txtIn.Text.Trim().Split(';');
                string e_mailDest = parMS[0].Trim();
                SRI_LIB.Net_Mail m_obj = new SRI_LIB.Net_Mail();
                if (!m_obj.IsValidEmail(parMS[0].Trim()))
                {
                    MessageBox.Show(String.Format("El correo {0} no es un correo con formato válido. Revise por favor", e_mailDest));
                    return;
                }
                string e_mailRem = parMS[2].Trim();
                if (!m_obj.IsValidEmail(parMS[0].Trim()))
                {
                    MessageBox.Show(String.Format("El correo {0} no es un correo con formato válido. Revise por favor", e_mailRem));
                    return;
                }
                int Port = 0;
                int.TryParse(parMS[5], out Port);
                if (Port == 0)
                {
                    MessageBox.Show("El puerto especificado no es válido. Revise por favor");
                    return;
                }
                bool SSLen = (parMS[6].Trim() == "True" ? true : false);

                m_obj = new SRI_LIB.Net_Mail(parMS[2].Trim(),
                parMS[3].Trim(), parMS[4].Trim(), Port, SSLen);
                string[] adjs = parMS[1].Trim().Split(',');
                bool sent = m_obj.EnviarMensaje(e_mailDest, "Una prueba de envío", "Prueba Email", adjs);
                if (sent)
                {
                    MessageBox.Show("Email Enviado");
                }
            }

        }



        private void wB1_Navigated(object sender, WebBrowserNavigatedEventArgs e)
        {
            if (System.IO.File.Exists(fullfilename))
            { try { System.IO.File.Delete(fullfilename); } catch  { return; } }
        }

        private void rdAutoriza_CheckedChanged(object sender, EventArgs e)
        {
            chkPrueba.Enabled = true;
            txtIn.Text = "2002201801099221334500110010020000000412014122216";
            label1.Text = "Clave de acceso:";
        }
        private void rdFirmado_CheckedChanged(object sender, EventArgs e)
        {
            chkPrueba.Enabled = false;
            txtIn.Text = "C:\\TMPALP\\cert1.p12;CONFIGURAR_LOCALMENTE;C:\\TMPALP\\signed.xml;C:\\TMPALP\\unsigned.xml";
            label1.Text = "Firmado:";
        }
        private void rdRIDE_CheckedChanged(object sender, EventArgs e)
        {
            chkPrueba.Enabled = false;
            txtIn.Text = "C:\\TMPALP\\signed.xml";
            label1.Text = "Verificar Firma:";
        }

        private void rdRecibe_CheckedChanged(object sender, EventArgs e)
        {
            chkPrueba.Enabled = true; ;
            label1.Text = "Ruta de comprobante:";
            this.txtIn.Text = "C:\\TMPALP\\signed.xml";
        }

        private void rbMail_CheckedChanged(object sender, EventArgs e)
        {
            chkPrueba.Checked = false;
            chkPrueba.Enabled = false;
            label1.Text = "E-mail:";
            this.txtIn.Text = "emaildestino;ruta_archivo_adjunto;correo_Remitente;Contraseña;smtpServer;Puerto;(True/False)RequiereSSL";
        }

        private void rbXSD_CheckedChanged(object sender, EventArgs e)
        {
            chkPrueba.Enabled = false;
            txtIn.Text = "rutaXML;rutaXSD";
            label1.Text = "Validar contra XSD:";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //// Compare the two files that referenced in the textbox controls.
            //if (FileCompare("C:\\TMPALP\\signed.xml", "C:\\TMPALP\\unsigned.xml"))
            //{
            //    MessageBox.Show("Files are equal.");
            //}
            //else
            //{
            //    MessageBox.Show("Files are not equal.");
            //}
            ConsoleApplication2.SriFirma alg = new ConsoleApplication2.SriFirma();
            alg.Xml("","","");
        }
        private bool FileCompare(string file1, string file2)
        {
            int file1byte;
            int file2byte;
            FileStream fs1;
            FileStream fs2;

            // Determine if the same file was referenced two times.
            if (file1 == file2)
            {
                // Return true to indicate that the files are the same.
                return true;
            }

            // Open the two files.
            fs1 = new FileStream(file1, FileMode.Open);
            fs2 = new FileStream(file2, FileMode.Open);

            // Check the file sizes. If they are not the same, the files 
            // are not the same.
            if (fs1.Length != fs2.Length)
            {
                // Close the file
                fs1.Close();
                fs2.Close();

                // Return false to indicate files are different
                return false;
            }

            // Read and compare a byte from each file until either a
            // non-matching set of bytes is found or until the end of
            // file1 is reached.
            do
            {
                // Read one byte from each file.
                file1byte = fs1.ReadByte();
                file2byte = fs2.ReadByte();
            }
            while ((file1byte == file2byte) && (file1byte != -1));

            // Close the files.
            fs1.Close();
            fs2.Close();

            // Return the success of the comparison. "file1byte" is 
            // equal to "file2byte" at this point only if the files are 
            // the same.
            return ((file1byte - file2byte) == 0);
        }

    }


}