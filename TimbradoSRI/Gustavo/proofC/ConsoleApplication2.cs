using System;
using System.Xml;
using System.Security.Cryptography.X509Certificates;
using System.Security.Cryptography;
using System.Security.Cryptography.Xml;

namespace ConsoleApplication2
{
    class SriFirma
    {
        Random rnd = new Random(DateTime.Now.
Millisecond);

        public const string XmlDsigRSASHA1Url = "http://www.w3.org/2000/09/xmldsig#rsa-sha1";

        public void Xml(String pathXml, String pathSignature, String passFirma)
        {
            //Declaro variable XMLDocument
            XmlDocument xmlDoc = new XmlDocument();
            // Cargo el documento en el xmlDoc
            xmlDoc.PreserveWhitespace = true;
            pathXml = "C:\\TMPALP\\signed2.xml";
            xmlDoc.Load(new XmlTextReader("C:\\TMPALP\\unsigned.xml"));

            //Obtengo la firma en el Certificado X509
            X509Certificate2 uidCert = new X509Certificate2("C:\\TMPALP\\cert1.p12", Environment.GetEnvironmentVariable("SRI_CERT_PASSWORD"), X509KeyStorageFlags.DefaultKeySet);
            
            //Inicializo el RSA
            RSACryptoServiceProvider rsaKey = (RSACryptoServiceProvider)uidCert.PrivateKey;

            //Agrego el SgnedXml que permite firmar el xml
            SignedXml signedXml = new SignedXml(xmlDoc);

            // Add the key to the SignedXml document.
            signedXml.SigningKey = rsaKey;

            //signedXml.Signature.Id = newID("Signature");


            //Agregamos el metodo de firmado
            signedXml.SignedInfo.SignatureMethod = XmlDsigRSASHA1Url;

            //signedXml.SignedInfo.Id = newID("Signature-SignedInfo");

            // Create a reference to be signed.
            Reference reference = new Reference();
            //reference.Id = newID("SignedPropertiesID");
            reference.Uri = "";

            // Add an enveloped transformation to the reference.
            XmlDsigEnvelopedSignatureTransform env = new XmlDsigEnvelopedSignatureTransform();
            reference.AddTransform(env);

            // Add the reference to the SignedXml object.
            signedXml.AddReference(reference);


            // Add an RSAKeyValue KeyInfo (optional; helps recipient find key to validate).
            KeyInfo keyInfo = new KeyInfo();

            KeyInfoX509Data clause = new KeyInfoX509Data();
            clause.AddSubjectName(uidCert.Subject);
            clause.AddCertificate(uidCert);
            keyInfo.AddClause(clause);

            //keyInfo.Id = newID("Certificate1");

            signedXml.KeyInfo = keyInfo;

            // Compute the signature.
            signedXml.ComputeSignature();


            Boolean respuesta = signedXml.CheckSignature();
            System.Console.WriteLine(respuesta);

            // Get the XML representation of the signature and save
            // it to an XmlElement object.
            XmlElement xmlDigitalSignature = signedXml.GetXml();


            //XmlElement signature = signedXml.GetXml();
            foreach (XmlNode node in xmlDigitalSignature.SelectNodes(
                "descendant-or-self::*[namespace-uri()='http://www.w3.org/2000/09/xmldsig#']"))
            {
                node.Prefix = "ds";
            }


            System.Console.WriteLine(signedXml.GetXml().InnerXml);
            // Append the element to the XML document.
            xmlDoc.DocumentElement.AppendChild(xmlDoc.ImportNode(xmlDigitalSignature, true));
            XmlTextWriter xmltw = new XmlTextWriter(pathXml, new System.Text.UTF8Encoding(false));
            xmlDoc.PreserveWhitespace = true;
            xmlDoc.Save(xmltw);
            xmltw.Close();
            //xmlDoc.Save(pathXml);

        }


        private String newID(String prefix)
        {
            String newID = prefix + rnd.Next(1048576);
            newID = prefix + rnd.Next(1048576);
            return newID;
        }
    }
}