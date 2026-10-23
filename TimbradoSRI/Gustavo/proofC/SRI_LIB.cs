using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Xml;
using System.Xml.Schema;
using System.Text.RegularExpressions;
using System.Net.Security;
using System.Text;
using System.Security.Cryptography;
using System.Security.Cryptography.Xml;
using System.Reflection;
using System.Drawing.Imaging;
using System.Xml.Linq;
using System.Xml.Xsl;

namespace SRI_LIB
{
    [ComVisible(true)]
    [ClassInterface(ClassInterfaceType.AutoDual)]
    [ProgId("SRI_LIB.XML_Object")]
    public class XML_Object
    {
        public class ResError
        {
            public string Severity = "";
            public string Message = "";
        }
        public bool validateResult = false;
        public ResError[] Errores = new ResError[0];
        /// <summary>
        /// Valida el xml que se encuentra en 'pathXML' contra el esquema ubicado en 'pathXSD'
        /// </summary>
        /// <param name="pathXML">Ruta completa del archivo XML a validarse</param>
        /// <param name="pathXSD">Ruta completa del esquema XSD con el que se realiza la validación</param>
        /// <returns>Verdadero si pasa la validacion, caso contrario falso</returns>
        public bool validaEsquema(string pathXML, string pathXSD)
        {
            try
            {
              
                XmlTextReader tr = new XmlTextReader(pathXML);
                XmlValidatingReader vr = new XmlValidatingReader(tr);
                vr.Schemas.Add("", pathXSD);
                vr.ValidationType = ValidationType.Schema;
                vr.ValidationEventHandler += new ValidationEventHandler(ValidationHandler);
                while (vr.Read()) ;
                if (Errores.Length == 0)
                {
                    validateResult = true;
                }

            }
            catch (Exception ex)
            {
                validateResult = false;
                ResError err = new ResError();
                err.Severity = "root";
                err.Message = ex.Message;
                Array.Resize<ResError>(ref Errores, Errores.Length + 1);
                Errores[Errores.Length - 1] = err;
            }
            return validateResult;
        }
        private void ValidationHandler(object sender, ValidationEventArgs args)
        {
            ResError err = new ResError();
            err.Severity = args.Severity.ToString();
            err.Message = args.Message.ToString();
            Array.Resize<ResError>(ref Errores, Errores.Length + 1);
            Errores[Errores.Length - 1] = err;
            validateResult = false;
        }

        /// <summary>
        /// Crea un archivo en formato XML
        /// </summary>
        /// <param name="fuente">archivo de texto plano a cargarse</param>
        /// <param name="pathXML">Ruta donde se guarda el resultado</param>
        /// <returns>true si el resultado es el esperado, caso contrario false</returns>
        public bool generaXML(string fuente, string pathXML)
        {
            try
            {
                XmlDocument varDoc;
                varDoc = new XmlDocument();
                varDoc.LoadXml(fuente);
                varDoc.Save(pathXML);
            }
            catch
            {
                return false;
            }
            return true;
        }

    }
    [ComVisible(true)]
    [ClassInterface(ClassInterfaceType.AutoDual)]
    [ProgId("SRI_LIB.NET_WServ")]
    public class NET_WServ
    {
        private bool hayErr = false;
        private string sErr = "";
        public string ErrMsg
        {
            get { return sErr; }
        }
        public bool Error
        {
            get { return hayErr; }
        }
        public string consumirServicio(string nomMethod, string contenido, bool ambientePrueba = false)
        {
            try
            {
                XmlNode[] resNode = new XmlNode[0];
                switch (nomMethod)
                {
                    case "autorizacionComprobante":
                        if (ambientePrueba)
                        {
                            proofC.OfflineAutorizaPrueba.AutorizacionComprobantesOfflineClient wsAutorizaP = new proofC.OfflineAutorizaPrueba.AutorizacionComprobantesOfflineClient();
                            object resAutP = new proofC.OfflineAutorizaPrueba.respuestaComprobante();
                            resAutP = wsAutorizaP.autorizacionComprobante(contenido);
                            resNode = (XmlNode[])resAutP;
                        }
                        else
                        {
                            proofC.OfflineAutoriza.AutorizacionComprobantesOfflineClient wsAutoriza = new proofC.OfflineAutoriza.AutorizacionComprobantesOfflineClient();
                            object resAut = new proofC.OfflineAutoriza.respuestaComprobante();
                            resAut = wsAutoriza.autorizacionComprobante(contenido);
                            resNode = (XmlNode[])resAut;
                        }

                        break;
                    case "validarComprobante":
                        //creo el buffer de bytes para enviar como parámetro
                        //Se da de baja porque sale como que esta modificado
                        //XmlDocument content = new XmlDocument();
                        //content.Load(contenido);
                        //byte[] buff = Encoding.Default.GetBytes(content.OuterXml);
                        byte[] buff = System.IO.File.ReadAllBytes(contenido);
                        if (ambientePrueba)
                        {
                            proofC.OfflineRecepcion_Prueba.RecepcionComprobantesOfflineClient wsClientP = new proofC.OfflineRecepcion_Prueba.RecepcionComprobantesOfflineClient();
                            object resReceP = new proofC.OfflineRecepcion_Prueba.respuestaSolicitud();
                            resReceP = wsClientP.validarComprobante(buff);
                            resNode = (XmlNode[])resReceP;
                        }
                        else
                        {
                            proofC.OfflineRecepcion.RecepcionComprobantesOfflineClient wsClient = new proofC.OfflineRecepcion.RecepcionComprobantesOfflineClient();
                            object resRece = new proofC.OfflineRecepcion.respuestaSolicitud();
                            resRece = wsClient.validarComprobante(buff);
                            resNode = (XmlNode[])resRece;
                        }
                        break;
                    default:
                        break;
                }
                string ret = "";
                for (int i = 0; i <= resNode.Length - 1; i++)
                {
                    ret = ret + resNode[i].OuterXml;
                }
                //Elemento Raíz 
                return "<root>" + ret + "</root>";
            }
            catch (Exception ex)
            {
                hayErr = true;
                sErr = ex.Message;
                return "";
            }

        }
    }
    [ComVisible(true)]
    [ClassInterface(ClassInterfaceType.AutoDual)]
    [ProgId("SRI_LIB.Net_Mail")]
    public class Net_Mail
    {
        Exception Excepcion;
        public string ClaveMail;
        public string DireccionMail;
        public bool EnableSSl;
        public int Puerto;


        private string _SMTPServer;
        public string SMTPServer
        {
            get { return _SMTPServer; }
        }
        public Net_Mail() {
        }
        public Net_Mail(string Mail, string Clave, string ServidorSMTP, int puertoDefecto, bool SSL)
        {
            DireccionMail = Mail;
            ClaveMail = Clave;
            _SMTPServer = ServidorSMTP;
            EnableSSl = SSL;
            Puerto = puertoDefecto;
        }
        public bool EnviarMensaje(string Destinatario, string mensaje, string Asunto, string[] adjuntos = null)
        {
            List<string> res = new List<string>();
            res.Add(Destinatario);
            List<System.Net.Mail.Attachment> adj = new List<System.Net.Mail.Attachment>();
            if (adjuntos != null)
            {
                foreach (string sadj in adjuntos) {
                    adj.Add(new System.Net.Mail.Attachment(sadj));
                }
               
            }
            return EnviarMensaje(res, mensaje, Asunto, adj);
        }


        public bool EnviarMensaje(string Destinatario, string mensaje, string Asunto, string adjunto = null)
        {
            List<string> res = new List<string>();
            res.Add(Destinatario);
            List<System.Net.Mail.Attachment> adj = new List<System.Net.Mail.Attachment>();
            if (adjunto != null)
            {
                adj.Add(new System.Net.Mail.Attachment(adjunto));
            }
            return EnviarMensaje(res, mensaje, Asunto, adj);
        }




        public bool EnviarMensaje(string Destinatario, string mensaje, string Asunto, System.Net.Mail.Attachment adjunto = null)
        {
            List<string> res = new List<string>();
            res.Add(Destinatario);
            List<System.Net.Mail.Attachment> adj = new List<System.Net.Mail.Attachment>();
            if (adjunto != null)
            {
                adj.Add(adjunto);
            }
            return EnviarMensaje(res, mensaje, Asunto, adj);
        }
        public bool EnviarMensaje(List<string> ListaDestinatarios, string mensaje, string Asunto, List<System.Net.Mail.Attachment> adjuntos = null)
        {
            System.Net.Mail.MailMessage miCorreo = new System.Net.Mail.MailMessage();
            miCorreo.IsBodyHtml = true;
            miCorreo.From = new System.Net.Mail.MailAddress(DireccionMail);//mail desde donde se envía
            foreach (string mail in ListaDestinatarios)
            {
                miCorreo.To.Add(mail);//mail del destinatario
            }
            miCorreo.Subject = Asunto;//Asunto
            miCorreo.Body = mensaje;
            miCorreo.IsBodyHtml = true;
            miCorreo.Priority = System.Net.Mail.MailPriority.Normal;//Prioridad
            if (adjuntos != null)
            {
                foreach (System.Net.Mail.Attachment adj in adjuntos)
                {
                    miCorreo.Attachments.Add(adj);
                }
            }
            //no modificar las siguientes lineas ya qye corresponden a la coniguracion del server smtp de microsoft (windows live)
            System.Net.Mail.SmtpClient smtp = new System.Net.Mail.SmtpClient();
            smtp.Host = SMTPServer;
            smtp.Port = Puerto; //465
            smtp.EnableSsl = EnableSSl;
            //estas lineas pueden o no ser necesarias pero las puse por una validacion que no avanzaba
            ServicePointManager.ServerCertificateValidationCallback =
                delegate (Object a, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors) { return true; };
            // para las credenciales debo pasarle la cuenta y la clave desde donde se envía
            smtp.Credentials = new System.Net.NetworkCredential(DireccionMail, ClaveMail);
            try
            {

                smtp.Send(miCorreo);
                // lineas para el registro de mail
                return true;
            }
            catch (Exception ex)
            {
                Excepcion = ex;
                return false;
            }
        }
        public bool EnviarMensaje(List<string> ListaDestinatarios, string Asunto, List<System.Net.Mail.AlternateView> ListAlternateView, List<System.Net.Mail.Attachment> adjuntos = null)
        {
            System.Net.Mail.MailMessage miCorreo = new System.Net.Mail.MailMessage();
            miCorreo.IsBodyHtml = true;
            miCorreo.From = new System.Net.Mail.MailAddress(DireccionMail);//mail desde donde se envía
            foreach (string mail in ListaDestinatarios)
            {
                miCorreo.To.Add(mail);//mail del destinatario
            }
            miCorreo.Subject = Asunto;//Asunto
            foreach (System.Net.Mail.AlternateView view in ListAlternateView)
            {
                miCorreo.AlternateViews.Add(view);
            }
            miCorreo.Priority = System.Net.Mail.MailPriority.Normal;//Prioridad
            if (adjuntos != null)
            {
                foreach (System.Net.Mail.Attachment adj in adjuntos)
                {
                    miCorreo.Attachments.Add(adj);
                }
            }
            //no modificar las siguientes lineas ya qye corresponden a la coniguracion del server smtp de microsoft (windows live)
            System.Net.Mail.SmtpClient smtp = new System.Net.Mail.SmtpClient();
            smtp.Host = SMTPServer;
            smtp.Port = Puerto; //465
            smtp.EnableSsl = EnableSSl;
            ServicePointManager.ServerCertificateValidationCallback =
               delegate (Object a, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors) { return true; };
            // para las credenciales debo pasarle la cuenta y la clave desde donde se envía
            string usr_mail = DireccionMail.Split('@')[0].Trim();
            smtp.Credentials = new System.Net.NetworkCredential(usr_mail, ClaveMail);
            try
            {
                smtp.Send(miCorreo);
                // lineas para el registro de mail
                return true;
            }
            catch (Exception ex)
            {
                Excepcion = ex;
                return false;
            }
        }
        public bool IsValidEmail(string email)
        {
            if (String.IsNullOrEmpty(email)) { return false; }
            //Compruebo si el formato de la dirección es correcto.
            Regex re = new Regex(@"^(?("")("".+?(?<!\\)""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
                @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-\w]*[0-9a-z]*\.)+[a-z0-9][\-a-z0-9]{0,22}[a-z0-9]))$");
            Match m = re.Match(email);
            return m.Captures.Count != 0;
        }
    }
    [ComVisible(true)]
    [ClassInterface(ClassInterfaceType.AutoDual)]
    [ProgId("SRI_LIB.Net_Sign")]
    public class Net_Sign
    {
        private bool hayErr = false;
        private string sErr = "";
        public string ErrMsg
        {
            get { return sErr; }
        }
        public bool Error
        {
            get { return hayErr; }
        }
        public void SignXml(string pathSign, string key, string pathXML, string pathOut)
        {
            try
            {
                X509Certificate2 uidCert = new X509Certificate2(pathSign, key, X509KeyStorageFlags.DefaultKeySet);
                // Create a new XML document.

               // Regex regex = new Regex(@">\s*<");
               // string cleanXin = regex.Replace(File.ReadAllText(pathXML), "><");

                // XmlDocument testDoc = new XmlDocument();
                //testDoc.PreserveWhitespace = true;
                //testDoc.LoadXml(cleanXin);
                //testDoc.Load(pathXML);
                // Sign the XML document. 
                XmlDocument testDoc = new XmlDocument();
                testDoc.PreserveWhitespace = true;
                // Load the passed XML file using its name.
                testDoc.Load(new XmlTextReader(pathXML));

                SignXml(testDoc, uidCert);
                // Console.WriteLine("XML file signed.");
                //  v   | xmlDoc.PreserveWhitespace = true;
                //XmlWriterSettings settings = new XmlWriterSettings();
                //settings.Indent = false;
                //settings.NewLineChars = String.Empty;
                //settings.NewLineHandling = NewLineHandling.Replace;
                //settings.NewLineOnAttributes = false;
                //settings.CheckCharacters = true;
                //XmlWriter writer = XmlWriter.Create(pathOut, settings);
                //testDoc.PreserveWhitespace = false;
                //testDoc.Save(writer);
                //writer.Close();

                if (testDoc.FirstChild is XmlDeclaration)
                {
                    testDoc.RemoveChild(testDoc.FirstChild);
                }

                // Save the signed XML document to a file specified
                // using the passed string.
                XmlTextWriter xmltw = new XmlTextWriter(pathOut, new UTF8Encoding(false));
                testDoc.PreserveWhitespace = true;
                testDoc.Save(xmltw);
                xmltw.Close();

                //File.WriteAllText(pathOut, testDoc.OuterXml);

                //testDoc.PreserveWhitespace = true;
                //testDoc.Save(pathOut);
                bool valid = validSign(pathOut); ;
                
                ///revisar la integridad 
                XmlDocument xd = new XmlDocument();
                xd.PreserveWhitespace = true;
                xd.Load(pathOut);

                SignedXml signedXml = new SignedXml(xd);

                // load the first <signature> node and load the signature  
                XmlNode MessageSignatureNode =
                   xd.GetElementsByTagName("ds:Signature")[0];

                signedXml.LoadXml((XmlElement)MessageSignatureNode);

               
                // Extrae el certificado desde el nodo de firma 
                X509Certificate2 certificate = null;
                foreach (KeyInfoClause clause in signedXml.KeyInfo)
                {
                    if (clause is KeyInfoX509Data)
                    {
                        if (((KeyInfoX509Data)clause).Certificates.Count > 0)
                        {
                            certificate =
                            (X509Certificate2)((KeyInfoX509Data)clause).Certificates[0];

                            valid = valid && signedXml.CheckSignature(uidCert.PrivateKey);
                            valid = valid && signedXml.CheckSignature(certificate, true);
                            valid = valid && signedXml.CheckSignature();
                        }
                    }
                }

                if (!valid)
                {
                    this.hayErr = true;
                    sErr = "No pasó la verificacion de firma";
                }


            }
            catch (Exception e)
            {
                this.hayErr = true;
                sErr = e.Message;
            }

        }
       public bool validSign(string pathXMLSign)
       {
            ///revisar la integridad 
            XmlDocument xd = new XmlDocument();
            xd.PreserveWhitespace = true;
            xd.Load(pathXMLSign);

            SignedXml signedXml = new SignedXml(xd);

            // load the first <signature> node and load the signature  
            XmlNode MessageSignatureNode =
               xd.GetElementsByTagName("ds:Signature")[0];

            signedXml.LoadXml((XmlElement)MessageSignatureNode);

            bool valid = true;
            // Extrae el certificado desde el nodo de firma 
            X509Certificate2 certificate = null;
            foreach (KeyInfoClause clause in signedXml.KeyInfo)
            {
                if (clause is KeyInfoX509Data)
                {
                    if (((KeyInfoX509Data)clause).Certificates.Count > 0)
                    {
                        certificate =
                        (X509Certificate2)((KeyInfoX509Data)clause).Certificates[0];
                        valid = valid && signedXml.CheckSignature(certificate, true);
                        valid = valid && signedXml.CheckSignature();
                    }
                }
            }

            if (!valid)
            {
                this.hayErr = true;
                sErr = "No pasó la verificacion de firma";
            }
            return valid;
        }
        // Sign an XML file.  
        // This document cannot be verified unless the verifying  
        // code has the key with which it was signed. 
        private void SignXml(XmlDocument xmlDoc, X509Certificate2 uidCert)
        {
            Random rnd = new Random();
            //RSA rsaKey = (RSA)uidCert.PrivateKey;
            RSACryptoServiceProvider rsaKey = (RSACryptoServiceProvider)uidCert.PrivateKey;
            // Check arguments. 
            if (xmlDoc == null)
                throw new ArgumentException("xmlDoc");
            if (rsaKey == null)
                throw new ArgumentException("Key");
          
            PrefixedSignedXML signedXml = new PrefixedSignedXML(xmlDoc);

            signedXml.SigningKey = uidCert.PrivateKey;
            signedXml.Signature.Id = "Signature" + rnd.Next(0,999999).ToString().Trim();
            signedXml.Signature.SignedInfo.Id = "Signature-SignedInfo" + rnd.Next(0, 999999).ToString().Trim();
            signedXml.SignatureValueId = "SignatureValue"  +rnd.Next(0, 999999).ToString().Trim();
            // Create a reference to be signed.
            Reference reference = new Reference();
            reference.Uri = "#comprobante";
            reference.Id = "Reference-ID-" + rnd.Next(0, 999999).ToString().Trim(); ;
            // Add an enveloped transformation to the reference.            
            XmlDsigEnvelopedSignatureTransform env =
               new XmlDsigEnvelopedSignatureTransform(true);
            reference.AddTransform(env);
            // Add the reference to the SignedXml object.
            signedXml.AddReference(reference);
            /*añadir el etsi */
            //"http://uri.etsi.org/01903/v1.3.2#"

            /*ahora el nodo objeto ETSI*/
            XmlElement Etsiobject = xmlDoc.CreateElement("ds", "Object", SignedXml.XmlDsigNamespaceUrl);
           
            #region etsiObject
            XmlElement qualifyingPropertiesRoot =xmlDoc.CreateElement("etsi", "QualifyingProperties", "http://uri.etsi.org/01903/v1.3.2#");
            qualifyingPropertiesRoot.SetAttribute("Target", "#"+signedXml.Signature.Id);
            
            Etsiobject.AppendChild(qualifyingPropertiesRoot);

            XmlElement signaturePropertiesRoot = xmlDoc.CreateElement("etsi", "SignedProperties", "http://uri.etsi.org/01903/v1.3.2#");
            string SignedPropertiesID = signedXml.Signature.Id + "-SignedProperties" + rnd.Next(0, 999999).ToString().Trim();
            signaturePropertiesRoot.SetAttribute("Id", SignedPropertiesID);
            
            XmlElement SignedSignatureProperties = xmlDoc.CreateElement("etsi", "SignedSignatureProperties", "http://uri.etsi.org/01903/v1.3.2#");

            XmlElement timestamp = xmlDoc.CreateElement("etsi", "SigningTime", "http://uri.etsi.org/01903/v1.3.2#");
            timestamp.InnerText = DateTime.Now.ToString("yyyy-MM-ddTHH:mm:sszzz"); //2011-09-05T09:11:24-05:00
            SignedSignatureProperties.AppendChild(timestamp);

            XmlElement SigningCertificate = xmlDoc.CreateElement("etsi", "SigningCertificate", "http://uri.etsi.org/01903/v1.3.2#");
            XmlElement Cert = xmlDoc.CreateElement("etsi", "Cert", "http://uri.etsi.org/01903/v1.3.2#");
            XmlElement CertDigest = xmlDoc.CreateElement("etsi", "CertDigest", "http://uri.etsi.org/01903/v1.3.2#");
            SHA1 cryptoServiceProvider = new SHA1CryptoServiceProvider();
            byte[] sha1 = cryptoServiceProvider.ComputeHash(uidCert.RawData);

            XmlElement DigestMethod = xmlDoc.CreateElement("ds", "DigestMethod", SignedXml.XmlDsigNamespaceUrl);

            DigestMethod.SetAttribute("Algorithm", SignedXml.XmlDsigSHA1Url);
            XmlElement DigestValue = xmlDoc.CreateElement("ds", "DigestValue", SignedXml.XmlDsigNamespaceUrl);
            DigestValue.InnerText = Convert.ToBase64String(sha1);
            CertDigest.AppendChild(DigestMethod);
            CertDigest.AppendChild(DigestValue);
            Cert.AppendChild(CertDigest);

            XmlElement IssuerSerial = xmlDoc.CreateElement("etsi", "IssuerSerial", "http://uri.etsi.org/01903/v1.3.2#");
            XmlElement X509IssuerName = xmlDoc.CreateElement("ds", "X509IssuerName", SignedXml.XmlDsigNamespaceUrl);
            X509IssuerName.InnerText = uidCert.IssuerName.Name;
            XmlElement X509SerialNumber = xmlDoc.CreateElement("ds", "X509SerialNumber", "http://www.w3.org/2000/09/xmldsig#");
            X509SerialNumber.InnerText = uidCert.SerialNumber;
            IssuerSerial.AppendChild(X509IssuerName);
            IssuerSerial.AppendChild(X509SerialNumber);
            Cert.AppendChild(IssuerSerial);

            SigningCertificate.AppendChild(Cert);
            SignedSignatureProperties.AppendChild(SigningCertificate);

            signaturePropertiesRoot.AppendChild(SignedSignatureProperties);
            qualifyingPropertiesRoot.AppendChild(signaturePropertiesRoot);

            // /////////////////////////////////
           
            XmlElement SignedDataObjectProperties = xmlDoc.CreateElement("etsi", "SignedDataObjectProperties", "http://uri.etsi.org/01903/v1.3.2#");
            XmlElement DataObjectFormat = xmlDoc.CreateElement("etsi", "DataObjectFormat", "http://uri.etsi.org/01903/v1.3.2#");
            DataObjectFormat.SetAttribute("ObjectReference", "#"+reference.Id);
            signaturePropertiesRoot.AppendChild(SignedDataObjectProperties);
            SignedDataObjectProperties.AppendChild(DataObjectFormat);
            XmlElement MimeType = xmlDoc.CreateElement("etsi", "MimeType", "http://uri.etsi.org/01903/v1.3.2#");
            MimeType.InnerText = "text/xml";
            XmlElement Description = xmlDoc.CreateElement("etsi", "Description", "http://uri.etsi.org/01903/v1.3.2#");
            Description.InnerText = "contenido comprobante";
            DataObjectFormat.AppendChild(Description);
            DataObjectFormat.AppendChild(MimeType);
            #endregion
            // /////////////////////////////////////////////////////////////
            KeyInfo keyInfo = new KeyInfo();
           
            keyInfo.Id = "Certificate" + rnd.Next(0, 999999).ToString().Trim();
            KeyInfoX509Data keyInfoData = new KeyInfoX509Data(uidCert);

            keyInfo.AddClause(keyInfoData);
            keyInfo.AddClause(new RSAKeyValue((RSA)uidCert.PrivateKey));
            signedXml.KeyInfo = keyInfo;
            

            // Create a data object to hold the data to sign.
            DataObject dataObject = new DataObject();
            dataObject.LoadXml(Etsiobject);
            dataObject.Id = signedXml.Signature.Id + "-Object" + rnd.Next(0, 999999).ToString().Trim();
            signedXml.AddObject(dataObject);
            

            signedXml.signaturePropertiesRoot = signaturePropertiesRoot;


            Reference propertiesRef = new Reference("#" + SignedPropertiesID);
            propertiesRef.Id = "SignedPropertiesID" + rnd.Next(0, 999999).ToString().Trim();
            propertiesRef.Type = "http://www.w3.org/2000/02/xmldsig#SignatureProperty";
            signedXml.AddReference(propertiesRef);


            // Create a data object to hold the data to sign.


            //var reference2 = new Reference("#" + keyInfo.Id);
            //signedXml.AddReference(reference2);

            Reference reference2 = new Reference("#" + keyInfo.Id);
            //reference2.Uri = "#" + keyInfo.Id;
            signedXml.AddReference(reference2);


            //signedXml.AddReference(reference);

            signedXml.ComputeSignature("ds");
            //signedXml.ComputeSignature();
            // Get the XML representation of the signature and save
            // it to an XmlElement object.
           XmlElement xmlDigitalSignature = signedXml.GetXml("ds");
           // XmlElement xmlDigitalSignature = signedXml.GetXml();





            //xmlDigitalSignature.AppendChild(Etsiobject);
            // string signXML = xmlDoc.ImportNode(xmlDigitalSignature, true).OuterXml;
            //         Regex regex = new Regex(@">\s*<");
            //        string cleanXML = regex.Replace(signXML, "><");
            //Regex regex = new Regex(@">\s*<");

            // string cleansignNode  = regex.Replace(xmlDigitalSignature.OuterXml, "><");

            
            xmlDoc.DocumentElement.AppendChild(xmlDoc.ImportNode(xmlDigitalSignature, true));
            //bool checkSign = signedXml.CheckSignature(uidCert);

            //return xmlDoc.OuterXml;


            // Compute the signature.
            
            // Get the XML representation of the signature and save 
            // it to an XmlElement object.
            
           

            #region OTROMETH
            // RSA rsaKey = (RSA)uidCert.PrivateKey;
            //// RSACryptoServiceProvider rsaKey = (RSACryptoServiceProvider)uidCert.PrivateKey;



            // // Create a SignedXml object.
            // //SignedXml signedXml = new SignedXml(xmlDoc);
            // PrefixedSignedXML signedXml = new PrefixedSignedXML(xmlDoc);
            // // Add the key to the SignedXml document.
            // signedXml.SigningKey = rsaKey;


            // // Create a reference to be signed.
            // Reference reference = new Reference();
            // reference.Uri = "";

            // // Add an enveloped transformation to the reference.
            // XmlDsigEnvelopedSignatureTransform env = new XmlDsigEnvelopedSignatureTransform();
            // reference.AddTransform(env);

            // // Add the reference to the SignedXml object.
            // signedXml.AddReference(reference);


            // // Add an RSAKeyValue KeyInfo (optional; helps recipient find key to validate).
            // KeyInfo keyInfo = new KeyInfo();    

            // KeyInfoX509Data clause = new KeyInfoX509Data(rsaKey);
            // clause.AddSubjectName(uidCert.Subject);
            // clause.AddCertificate(uidCert);
            // keyInfo.AddClause(clause);
            // signedXml.KeyInfo = keyInfo;

            // // Compute the signature.
            // signedXml.ComputeSignature("ds");

            // // Get the XML representation of the signature and save 
            // // it to an XmlElement object.
            // XmlElement xmlDigitalSignature = signedXml.GetXml("ds");

            // //System.Console.WriteLine(signedXml.GetXml().InnerXml);

            // // Append the element to the XML document.
            // xmlDoc.DocumentElement.AppendChild(xmlDoc.ImportNode(xmlDigitalSignature, true));
            //}
            #endregion




        }
        /// <summary>
        /// Get an element refered to by its ID
        /// </summary>
        /// <param name="doc">XML document to search for the element in</param>
        /// <param name="id">element to search for</param>
        /// <returns>Element with the given ID, null if it could not be found</returns>
     


        public class PrefixedSignedXML : SignedXml
        {
            private string signatureValueId;
            public string SignatureValueId
            {
                get
                {
                    return this.signatureValueId;
                }
                set
                {
                    this.signatureValueId = value;
                }
            }

            public PrefixedSignedXML(XmlDocument document)
            : base(document)
            { }

            public PrefixedSignedXML(XmlElement element)
                : base(element)
            { }
            public XmlElement signaturePropertiesRoot;
            
            
            public PrefixedSignedXML()
                : base()
            { }
            /// <summary>
            /// Get an element refered to by its ID
            /// </summary>
            /// <param name="doc">XML document to search for the element in</param>
            /// <param name="id">element to search for</param>
            /// <returns>Element with the given ID, null if it could not be found</returns>
            public override XmlElement GetIdElement(XmlDocument doc, string id)
            {
                if (id == null)
                    return null;

                // see if this is the signature properties being referenced, otherwise fall back to default behavior
                if (String.Compare(id, signaturePropertiesRoot.GetAttribute("Id"), StringComparison.OrdinalIgnoreCase) == 0)
                    return signaturePropertiesRoot;
                else if (String.Compare(id, this.KeyInfo.Id, StringComparison.OrdinalIgnoreCase) == 0)
                {
                    XmlElement alg = this.KeyInfo.GetXml();
                    SetPrefix("ds", alg);
                    return alg;
                }
                return base.GetIdElement(doc, id);
            }
            public void ComputeSignature(string prefix)
            {
                this.BuildDigestedReferences();
                AsymmetricAlgorithm signingKey = this.SigningKey;
                if (signingKey == null)
                {
                    throw new CryptographicException("Cryptography_Xml_LoadKeyFailed");
                }
                if (this.SignedInfo.SignatureMethod == null)
                {
                    if (!(signingKey is DSA))
                    {
                        if (!(signingKey is RSA))
                        {
                            throw new CryptographicException("Cryptography_Xml_CreatedKeyFailed");
                        }
                        if (this.SignedInfo.SignatureMethod == null)
                        {
                            this.SignedInfo.SignatureMethod = "http://www.w3.org/2000/09/xmldsig#rsa-sha1";
                        }
                    }
                    else
                    {
                        this.SignedInfo.SignatureMethod = "http://www.w3.org/2000/09/xmldsig#dsa-sha1";
                    }
                }
                SignatureDescription description = CryptoConfig.CreateFromName(this.SignedInfo.SignatureMethod) as SignatureDescription;
                if (description == null)
                {
                    throw new CryptographicException("Cryptography_Xml_SignatureDescriptionNotCreated");
                }
                HashAlgorithm hash = description.CreateDigest();
                if (hash == null)
                {
                    throw new CryptographicException("Cryptography_Xml_CreateHashAlgorithmFailed");
                }
                this.GetC14NDigest(hash, prefix);
                this.m_signature.SignatureValue = description.CreateFormatter(signingKey).CreateSignature(hash);
            }

            

            public XmlElement GetXml(string XmlDSigPrefix)
            {

                XmlElement retVal;
                XmlNodeList xmlNodeList;
                XmlNamespaceManager xmlNamespaceManager;

                retVal = base.GetXml();
                retVal.SetAttribute("xmlns:etsi", "http://uri.etsi.org/01903/v1.3.2#");
                // Add "ds" namespace prefix to all XmlDsig nodes in the signature
                SetPrefix(XmlDSigPrefix, retVal);
                xmlNamespaceManager = new XmlNamespaceManager(retVal.OwnerDocument.NameTable);
                xmlNamespaceManager.AddNamespace("ds", SignedXml.XmlDsigNamespaceUrl);
                //xmlNamespaceManager.AddNamespace("etsi", "http://uri.etsi.org/01903/v1.3.2#");

                if (this.signatureValueId != null && this.signatureValueId != "")
                { //Id on Signature value is needed for XAdES-T. We inject it here.
                    xmlNamespaceManager = new XmlNamespaceManager(retVal.OwnerDocument.NameTable);
                    xmlNamespaceManager.AddNamespace("ds", SignedXml.XmlDsigNamespaceUrl);
                    xmlNodeList = retVal.SelectNodes("ds:SignatureValue", xmlNamespaceManager);
                    //xmlNamespaceManager.AddNamespace("etsi", "http://uri.etsi.org/01903/v1.3.2#");
                    if (xmlNodeList.Count > 0)
                    {
                        ((XmlElement)xmlNodeList[0]).SetAttribute("Id", this.signatureValueId);
                    }
                }


                return retVal;

            }

            //Invocar por reflexión al método privado SignedXml.BuildDigestedReferences
            private void BuildDigestedReferences()
            {
                Type t = typeof(SignedXml);
                MethodInfo m = t.GetMethod("BuildDigestedReferences", BindingFlags.NonPublic | BindingFlags.Instance);
                m.Invoke(this, new object[] { });
            }

            private byte[] GetC14NDigest(HashAlgorithm hash, string prefix)
            {
                //string securityUrl = (this.m_containingDocument == null) ? null : this.m_containingDocument.BaseURI;
                //XmlResolver xmlResolver = new XmlSecureResolver(new XmlUrlResolver(), securityUrl);
                XmlDocument document = new XmlDocument();
                document.PreserveWhitespace = true;
                XmlElement e = this.SignedInfo.GetXml();


                document.AppendChild(document.ImportNode(e, true));
                //CanonicalXmlNodeList namespaces = (this.m_context == null) ? null : Utils.GetPropagatedAttributes(this.m_context);
                //Utils.AddNamespaces(document.DocumentElement, namespaces);

                Transform canonicalizationMethodObject = this.SignedInfo.CanonicalizationMethodObject;
                //canonicalizationMethodObject.Resolver = xmlResolver;
                //canonicalizationMethodObject.BaseURI = securityUrl;
                SetPrefix(prefix, document.DocumentElement); //establecemos el prefijo antes de se que calcule el hash (o de lo contrario la firma no será válida)
                canonicalizationMethodObject.LoadInput(document);
                return canonicalizationMethodObject.GetDigestedOutput(hash);
            }

            private void SetPrefix(string prefix, XmlNode node)
            {
                foreach (XmlNode n in node.ChildNodes)
                    SetPrefix(prefix, n);
                if (node.Prefix.Trim()==String.Empty)
                    node.Prefix = prefix;
            }
        }


        ///se da de baja
        #region RIDE
        /*
            public class Net_RIDE {
                private bool hayErr = false;
                private string sErr = "";
                public string ErrMsg
                {
                    get { return sErr; }
                }
                public bool Error
                {
                    get { return hayErr; }
                }
                public bool RIDE(string rutaLogo,string rutaXML, string rutaEsquema,string rutaPDFOut) {
                    XmlDocument doc = new XmlDocument();
                    doc.Load(rutaXML);
                    try {
                        string esquema = File.ReadAllText(rutaEsquema);
                        ///
                        ///Remplazar  contenido
                        ///
                        ///logo de compañía
                        string ext = Path.GetExtension(rutaLogo).Replace('.',' ').Trim();
                        using (var fs = new FileStream(rutaLogo, FileMode.Open))
                        {
                            byte[] byData = new byte[fs.Length];
                            fs.Read(byData, 0, byData.Length);
                            var base64 = Convert.ToBase64String(byData);
                            var imgSrc = String.Format("data:image/{1};base64,{0}", base64, ext.Trim().ToLower());
                            esquema = esquema.Replace("#logoGen#", imgSrc);
                        }
                        XmlNodeList elemList = doc.GetElementsByTagName("claveAcceso");
                        ;

                        ////GENERANDO BARCODE
                        //Barcode barcode = new Barcode();
                        //barcode.BarType = BarCodeType.Code128;
                        //barcode.Data = elemList[0].InnerText;
                        //barcode.ShowText = false;
                        //barcode.Width = 350;
                        //barcode.Height = 40;
                        //barcode.QRCodeECL = ErrorCorrectionLevelMode.L;
                        //barcode.PictureFormat = ImageFormat.Jpeg;
                        string nameTMP = Path.GetRandomFileName() + ".jpg";
                        Process alg = Process.Start("BarcodeCreatorDemo.exe", elemList[0].InnerText + " " + nameTMP);
                        while (!alg.HasExited)
                        {
                            var x = "";
                        }
                        //barcode.CreateBarcode(nameTMP);
                        //using (var fs = new MemoryStream()) {
                        //    byte[] byData = barcode.CreateBarcodeInBytes();
                        //    var base64 = Convert.ToBase64String(byData);
                        //    var imgSrc = String.Format("data:image/jpg;base64,{0}", base64);
                        //    esquema = esquema.Replace("#barras#", imgSrc);
                        //}
                        using (var fs = new FileStream(nameTMP, FileMode.Open))
                        {
                            byte[] byData = new byte[fs.Length];
                            fs.Read(byData, 0, byData.Length);
                            var base64 = Convert.ToBase64String(byData);
                            var imgSrc = String.Format("data:image/jpg;base64,{0}", base64);
                            esquema = esquema.Replace("#barras#", imgSrc);
                        }



                        esquema = esquema.Replace("#CLAVEACCESO#", elemList[0].InnerText);
                        esquema = esquema.Replace("#RUC#", doc.GetElementsByTagName("ruc")[0].InnerText);
                        esquema = esquema.Replace("#ESTAB#", doc.GetElementsByTagName("estab")[0].InnerText);
                        esquema = esquema.Replace("#PTOEMI#", doc.GetElementsByTagName("ptoEmi")[0].InnerText);
                        esquema = esquema.Replace("#SECU#", doc.GetElementsByTagName("secuencial")[0].InnerText);
                        string ambiente = doc.GetElementsByTagName("secuencial")[0].InnerText;
                        ambiente = (ambiente.Trim() == "1" ? "PRUEBAS" : "PRODUCCION");
                        esquema = esquema.Replace("#AMB#", ambiente);
                        esquema = esquema.Replace("#RAZONSOCIAL#", doc.GetElementsByTagName("razonSocial")[0].InnerText);
                        esquema = esquema.Replace("#NOMBRECOMERCIAL#", doc.GetElementsByTagName("nombreComercial")[0].InnerText);
                        esquema = esquema.Replace("#DIRMATRIZ#", doc.GetElementsByTagName("dirEstablecimiento")[0].InnerText);
                        esquema = esquema.Replace("#DIRESTAB#", doc.GetElementsByTagName("dirMatriz")[0].InnerText);
                        esquema = esquema.Replace("#CONTESP#", doc.GetElementsByTagName("contribuyenteEspecial")[0].InnerText);
                        esquema = esquema.Replace("#CNTOBL#", doc.GetElementsByTagName("obligadoContabilidad")[0].InnerText);
                        // esquema = esquema.Replace("#lafecha#", ((DateTime)registro["fecha_gen"]).ToLongDateString());
                        // esquema = esquema.Replace("#lahora#", string.Format("{0:hh:mm:ss tt}", (DateTime)registro["fecha_gen"]));
                        //Creacion del PDF
                        createPDF(esquema, rutaPDFOut);
                        hayErr = false;
                    } catch (Exception ex) {
                        hayErr = true;
                        sErr = ex.Message;
                    }
                    return !hayErr;
                }
                private void createPDF(string htmlString,  string pathSave)
                {
                    try
                    {
                        //Crear el PDF
                        PdfPageSize pageSize = PdfPageSize.A4;
                        PdfPageOrientation pdfOrientation = PdfPageOrientation.Portrait;
                        int webPageWidth = 1000;
                        int webPageHeight = 1000;
                        // instantiate a html to pdf converter object
                        HtmlToPdf converter = new HtmlToPdf();
                        // set converter options
                        converter.Options.PdfPageSize = pageSize;
                        converter.Options.PdfPageOrientation = pdfOrientation;
                        converter.Options.WebPageWidth = webPageWidth;
                        converter.Options.WebPageHeight = webPageHeight;
                        // create a new pdf document converting an url
                        PdfDocument doc = converter.ConvertHtmlString(htmlString);
                        // save pdf document
                        doc.Save(pathSave);
                        // close pdf document
                        doc.Close();
                        doc.DetachStream();
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                }

            */
    }
    #endregion
}
