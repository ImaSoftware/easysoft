using System;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Net;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sys_LicGen
{
    public class mailSender
    {
        Exception Exepccion;
        public string ClaveMail;
        public string DireccionMail;
        public bool EnableSSl;
        public int Puerto;

        
        private string _SMTPServer;
        public string SMTPServer {
            get { return _SMTPServer; }
        }
        public mailSender(string Mail, string Clave, string ServidorSMTP , int puertoDefecto, bool SSL ) {
            DireccionMail = Mail;
            ClaveMail = Clave;
            _SMTPServer = ServidorSMTP;
            EnableSSl = SSL;
            Puerto = puertoDefecto;
        }
        public bool EnviarMensaje(string Destinatario, string mensaje, string Asunto, System.Net.Mail.Attachment adjunto = null) {
            List<string> res = new List<string>();
            res.Add(Destinatario);
            List<System.Net.Mail.Attachment> adj = new List<System.Net.Mail.Attachment>();
            if (adjunto != null) {
                adj.Add(adjunto);
            }
            return EnviarMensaje(res, mensaje, Asunto, adj);
        }
        public bool EnviarMensaje(List<string> ListaDestinatarios, string mensaje, string Asunto, List<System.Net.Mail.Attachment> adjuntos = null)
        {
            System.Net.Mail.MailMessage miCorreo = new System.Net.Mail.MailMessage();
            miCorreo.IsBodyHtml = true;
            miCorreo.From = new System.Net.Mail.MailAddress(DireccionMail);//mail desde donde se envía
            foreach (string mail in ListaDestinatarios) {
                miCorreo.To.Add(mail);//mail del destinatario
            }
            miCorreo.Subject = Asunto;//Asunto
            miCorreo.Body = mensaje;
            miCorreo.IsBodyHtml = true;
            miCorreo.Priority = System.Net.Mail.MailPriority.Normal;//Prioridad
            if (adjuntos != null) {
                foreach (System.Net.Mail.Attachment adj in adjuntos) {
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
            try {

                smtp.Send(miCorreo);
                // lineas para el registro de mail
                return true;
            }
            catch (Exception ex) {
                Exepccion = ex;
                return false;
            }
        }
        public bool EnviarMensaje(List<string> ListaDestinatarios, string Asunto, List<System.Net.Mail.AlternateView> ListAlternateView, List<System.Net.Mail.Attachment> adjuntos = null) {
            System.Net.Mail.MailMessage miCorreo = new System.Net.Mail.MailMessage();
            miCorreo.IsBodyHtml = true;
            miCorreo.From = new System.Net.Mail.MailAddress(DireccionMail);//mail desde donde se envía
            foreach (string mail in ListaDestinatarios)
            {
                miCorreo.To.Add(mail);//mail del destinatario
            }
            miCorreo.Subject = Asunto;//Asunto
            foreach (System.Net.Mail.AlternateView view in ListAlternateView) {
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
                Exepccion = ex;
                return false;
            }
        }
        public static bool IsValidEmail(string email) {
            if (String.IsNullOrEmpty(email)) { return false; }
            //Compruebo si el formato de la dirección es correcto.
            Regex re = new Regex(@"^(?("")("".+?(?<!\\)""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
                @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-\w]*[0-9a-z]*\.)+[a-z0-9][\-a-z0-9]{0,22}[a-z0-9]))$");
            Match m = re.Match(email);
            return m.Captures.Count != 0;
        }
    }
}

  
