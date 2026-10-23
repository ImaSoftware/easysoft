using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Schema;

namespace Net_A
{
    [ComVisible(true)]
    [ClassInterface(ClassInterfaceType.AutoDual)]
    [ProgId("Net_A.Net_XML")]
    public class Net_XML
    {
        public class ResError {
            public string Severity = "";
           public  string Message = "";
        }
        public bool validateResult = false;
        public ResError[] Errores= new ResError[0];
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
                if (Errores.Length == 0) {
                    validateResult = true;
                }
               
            }
            catch (Exception ex) {
                validateResult = false;
            }
            return validateResult;
         }
        private  void ValidationHandler(object sender, ValidationEventArgs args)
        {
            ResError err = new ResError();
            err.Severity = args.Severity.ToString();
            err.Message = args.Message.ToString();
            Array.Resize<ResError>(ref Errores, Errores.Length + 1);
            Errores[Errores.Length-1] = err;
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
    [ProgId("Net_A.cons_Server")]
    public class cons_Server
    {
       private bool hayErr = false;
        private string sErr = "";
        public string ErrMsg
        {
            get { return ErrMsg; }
        }
        public  bool Error
        {
            get { return hayErr; }
        }
        public  string consumirServicio(string nomMethod, string contenido, bool ambientePrueba = false )
        {
            try
            {
                XmlNode[] resNode = new XmlNode[0];
                switch (nomMethod)
                {
                    case "autorizacionComprobante":
                        if (ambientePrueba){
                            utilWs.OfflineAutorizaPrueba.AutorizacionComprobantesOfflineClient wsAutorizaP = new utilWs.OfflineAutorizaPrueba.AutorizacionComprobantesOfflineClient();
                            object resAutP = new utilWs.OfflineAutorizaPrueba.respuestaComprobante();
                            resAutP = wsAutorizaP.autorizacionComprobante(contenido);
                            resNode = (XmlNode[])resAutP;
                        }
                        else {
                            utilWs.OfflineAutoriza.AutorizacionComprobantesOfflineClient wsAutoriza = new utilWs.OfflineAutoriza.AutorizacionComprobantesOfflineClient();
                            object resAut = new utilWs.OfflineAutoriza.respuestaComprobante();
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
                        if (ambientePrueba) {
                            utilWs.OfflineRecepcion_Prueba.RecepcionComprobantesOfflineClient wsClientP = new utilWs.OfflineRecepcion_Prueba.RecepcionComprobantesOfflineClient();
                            object resReceP = new utilWs.OfflineRecepcion_Prueba.respuestaSolicitud();
                            resReceP = wsClientP.validarComprobante(buff);
                            resNode = (XmlNode[])resReceP;
                        }
                        else{
                            utilWs.OfflineRecepcion.RecepcionComprobantesOfflineClient wsClient = new utilWs.OfflineRecepcion.RecepcionComprobantesOfflineClient();
                            object resRece = new utilWs.OfflineRecepcion.respuestaSolicitud();
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
            } catch(Exception ex)  {
                hayErr = true;
                sErr = ex.Message;
                return "" ;
            }
          
        }
    }
    //Estos metodos se dan de baja para realizar solamente llamadas a servicios a traves de SOAP armando el request 
    //Request
    #region SOAP_REQUEST
    class serviceExecuter
    {
        static string sRes = "";
        static string parUrl = "2";
        static string contenido;
        static string nomMethod = "autorizacionComprobante";
        public string start(string _nomMethod, string _contenido)
        {
            //Si algun dia quieren probar con esto desactivar las lineas
            //Servicio()
            return "";
        }

        static public HttpWebRequest CreateWebRequest()
        {
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3;
            ServicePointManager.ServerCertificateValidationCallback += (sender, cert, chain, sslPolicyErrors) => true;
            HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(parUrl);
            webRequest.Headers.Add(@"SOAP:Action:""""");
            webRequest.ContentType = "text/xml;charset=\"utf-8\"";
            webRequest.Accept = "text/xml";
            webRequest.Method = "POST";
            
            string certificateName = "name of certificate";
            X509Store store = new X509Store(StoreName.My, StoreLocation.CurrentUser);
            store.Open(OpenFlags.ReadOnly);
            X509Certificate2Collection certificates = store.Certificates.Find(X509FindType.FindBySubjectName, certificateName, true);
            foreach (X509Certificate certificate in certificates)
            {
                webRequest.ClientCertificates.Add(certificate);
            }
            certificateName = "name of certificate";
            certificates = store.Certificates.Find(X509FindType.FindBySubjectName, certificateName, true);
            foreach (X509Certificate certificate in certificates)
            {
                webRequest.ClientCertificates.Add(certificate);
            }
            return webRequest;
        }
        static public HttpWebRequest CreateWebRequestINI()
        {
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3;
            ServicePointManager.ServerCertificateValidationCallback += (sender, cert, chain, sslPolicyErrors) => true;
            String url = parUrl;
            HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(url);
            webRequest.ContentType = "text/xml;charset=\"utf-8\"";
            webRequest.Accept = "text/xml";
            // webRequest.Method = "POST";

            string certificateName = "name of certificate";
            X509Store store = new X509Store(StoreName.My, StoreLocation.CurrentUser);
            store.Open(OpenFlags.ReadOnly);
            X509Certificate2Collection certificates = store.Certificates.Find(X509FindType.FindBySubjectName, certificateName, true);
            foreach (X509Certificate certificate in certificates)
            {
                webRequest.ClientCertificates.Add(certificate);
            }
            certificateName = "name of certificate";
            certificates = store.Certificates.Find(X509FindType.FindBySubjectName, certificateName, true);
            foreach (X509Certificate certificate in certificates)
            {
                webRequest.ClientCertificates.Add(certificate);
            }
            return webRequest;
        }

        public static void Servicio()
        {
            /*txtRes.Text = "";
            //HVA:Intento de holger por hacer las cosas con el referenciado de servicios. 
            //Recomiendo solo hacer esas cosas con los servicios MS

            Serv_AutSRI.AutorizacionComprobantesOfflineService client = new Serv_AutSRI.AutorizacionComprobantesOfflineService();
            Serv_AutSRI.respuestaComprobante res1 = new Serv_AutSRI.respuestaComprobante();
            res1 = client.autorizacionComprobante("1209201701179125611500120013270386069163419908919");
            Boolean n = true;   
            */
            //Realizar la peticion para la definicion del servicio
            XmlDocument defMeth = new XmlDocument();
            HttpWebRequest req_Ini = CreateWebRequestINI();
            WebResponse response = req_Ini.GetResponse();
            try
            {
                StreamReader rd = new StreamReader(response.GetResponseStream());
                //var sRe = rd.ReadToEnd();
                //sRe = System.Web.HttpUtility.HtmlDecode(sRe);
                var outp = new WsdlToSoap(rd.ReadToEnd());
                var d_Sopa = outp.SoapMethodDictionary;
                defMeth = new XmlDocument();
                foreach (var dd in d_Sopa)
                {
                    if (dd.Key.Equals(nomMethod))
                    {
                        defMeth.LoadXml(dd.Value);
                        break;
                    }
                }
                if (defMeth == null) { return; }//CONSOLA
                XmlNode nodoMeth = defMeth.GetElementsByTagName("soapenv:Body").Item(0).FirstChild;//En Body Solo hay un methodo
                                                                                                   //Recorriendo  Parametros                                                                                                          
                string[] cont = new string[1];//SOLO UN PARAMETRO ULTRA QUE QUEMADO
                cont[0] = contenido;
                if (cont.Length != nodoMeth.ChildNodes.Count)
                {
                    //aqui tengo que devolver un log 
                    return;
                }
                for (int i = 0; i < nodoMeth.ChildNodes.Count; i++)
                {
                    //es un xml o es contenido??
                    if (cont[i].IndexOf(".xml") > 0)
                    {
                        XmlDocument content = new XmlDocument();
                        content.Load(cont[i]);
                        nodoMeth.FirstChild.InnerXml = content.InnerXml;
                    }
                    else
                    {
                        nodoMeth.FirstChild.InnerText = cont[i];
                    }

                }
            }
            catch (Exception xx) { return; }
            HttpWebRequest request = CreateWebRequest();
            /*
                * //HVA OTRA MANERA DE HACER EL ENVELOPE PERO SABIENDOLO Y NO CARGANDOLO
            var soapEnvelopeXml = new XmlDocument();
            var root = soapEnvelopeXml.CreateElement("soapenv", "Envelope", "http://schemas.xmlsoap.org/soap/envelope/");
            root.SetAttribute("xmlns:ec", "http://ec.gob.sri.ws.autorizacion");
            soapEnvelopeXml.AppendChild(root);
            var Header = soapEnvelopeXml.CreateElement("soapenv", "Header", "http://schemas.xmlsoap.org/soap/envelope/");
            root.AppendChild(Header);

            var body = soapEnvelopeXml.CreateElement("soapenv", "Body", "http://schemas.xmlsoap.org/soap/envelope/");
            root.AppendChild(body);

            var auto = soapEnvelopeXml.CreateElement("ec","autorizacionComprobante", "http://ec.gob.sri.ws.autorizacion");
            body.AppendChild(auto);
            var al = soapEnvelopeXml.CreateElement("claveAccesoComprobante");
            auto.AppendChild(al);
            al.InnerText = txtIn.Text;

            //var replacedString = GetPayloadString(soapEnvelopeXml);
            */
            /*
            soapEnvelopeXml.LoadXml(String.Format(@"<?xml version=""1.0"" encoding=""utf-8""?>
            <soapenv:Envelope xmlns:soapenv=""http://schemas.xmlsoap.org/soap/envelope/"" xmlns:ec=""http://ec.gob.sri.ws.autorizacion"">
            <soapenv:Header/>
            <soapenv:Body>
                <ec:autorizacionComprobante>
                    <!--Optional:-->
                    <claveAccesoComprobante>{0}</claveAccesoComprobante>
                </ec:autorizacionComprobante>
            </soapenv:Body>
            </soapenv:Envelope>", txtIn.Text));
            */
            Stream stream = request.GetRequestStream();
            try
            {
                defMeth.Save(stream);
                string nombreGuarda = grabaSeguro(Directory.GetCurrentDirectory() + "\\ultimoRequest.xml");
                defMeth.Save(nombreGuarda);
            }
            catch (Exception xx2) { return; }

            try
            {
                response = request.GetResponse();
                StreamReader rd = new StreamReader(response.GetResponseStream());
                //AQUI TOCA VALIDAR SI ESTA MAL O BIEN
                sRes = rd.ReadToEnd();
                //sRes = System.Web.HttpUtility.HtmlDecode(sRes); //arriba si quieres sin caracteres feos
                //XmlDocument varDoc;
                //varDoc = new XmlDocument();
               // varDoc.LoadXml(sRes);
                //string fullfilename = Directory.GetCurrentDirectory() + "\\ultimoResultado.xml";
                //fullfilename = grabaSeguro(fullfilename);
                //varDoc.Save(fullfilename);
               // sRes=System.IO.File.ReadAllText(fullfilename);
               // Clipboard.SetText(sRes);
                //File.WriteAllText(fullfilename, sRes); 
                //Process.Start(fullfilename);

            }
            catch (Exception xx3) { return; }

        }
        static public string grabaSeguro(string elFile)
        {
            if (System.IO.File.Exists(elFile))
            {
                //Intento Borrar 
                try { System.IO.File.Delete(elFile); }
                catch (System.IO.IOException ee)
                {
                    //No se puede Borrar -> cambie el nombre
                    var path = Path.GetTempPath();
                    var fileName = Guid.NewGuid().ToString() + ".xml";
                    return Path.Combine(path, fileName);
                }
                return elFile;

            }
            else
            {
                //No existe siga nomas
                return elFile;
            }
        }
    }

}
public class WsdlToSoap
{
    public XmlDocument _wsdlXDoc = new XmlDocument();
    private Dictionary<string, string> _soapMethodDic = new Dictionary<string, string>();
    private XmlNamespaceManager _wsdlNSM = null;

    public WsdlToSoap(string wsdlContent)
    {
        this._wsdlXDoc.LoadXml(wsdlContent);

        // set name space
        this._wsdlNSM = new XmlNamespaceManager(this._wsdlXDoc.NameTable);
        this._wsdlNSM.AddNamespace("wsdl", "http://schemas.xmlsoap.org/wsdl/");
        this._wsdlNSM.AddNamespace("xs", "http://www.w3.org/2001/XMLSchema");
    }
    public Dictionary<string, string> SoapMethodDictionary
    {
        get
        {
            this.AllMethods.ForEach((methodName) => {
                var soapContent = this.BuildSkeleton();
                soapContent = this.BuildSoapMethodElements(soapContent, methodName);
                this._soapMethodDic.Add(methodName, soapContent);
            });
            return this._soapMethodDic;
        }
    }

    #region common const
    private const string NSPrefix = "ns1";
    private const string NSPlaceHolder = "#ns";
    #endregion common const

    private static string _soapSkeleton
    {
        get
        {
            return $@"<?xml version='1.0' encoding='UTF-8'?>
                        <soapenv:Envelope xmlns:soapenv='http://schemas.xmlsoap.org/soap/envelope/' xmlns:xsi='http://www.w3.org/2001/XMLSchema-instance' xmlns:{WsdlToSoap.NSPrefix}='{WsdlToSoap.NSPlaceHolder}'>
                            <soapenv:Body>
                            </soapenv:Body>
                        </soapenv:Envelope>";
        }
    }

    /// <summary>
    /// return one of "0 true Array ?"
    /// </summary>
    /// <param name="typeName"></param>
    /// <returns></returns>
    private string _defaultValue(string typeName)
    {
        if (!typeName.Contains(":"))
        {
            throw new Exception($"Invalid typeName: {typeName}");
        }

        if (!typeName.StartsWith("xs:"))
        {
            if (this._isArray(typeName))
            {
                return "Array";
            }
            else
            {
                return string.Empty;
            }
        }

        typeName = typeName.Remove(0, 3); // remove prefix xs:

        switch (typeName)
        {
            case "boolean":
                return "true";
            case "string":
                return "?";
            case "decimal":
            case "double":
                return "0.0";
            default:
                return "0";
        }
    }

    private bool _isArray(string typeName)
    {
        if (typeName.Contains(":"))
        {
            typeName = typeName.Remove(0, typeName.IndexOf(':') + 1);
        }
        else
        {
            throw new Exception($"Invalid typeName: {typeName}");
        }

        var simpleTypeNode = this._wsdlXDoc.SelectSingleNode($"./wsdl:definitions/wsdl:types//xs:simpleType[@name='{typeName}']", _wsdlNSM);
        if (simpleTypeNode != null)
        {
            if (simpleTypeNode.SelectSingleNode(".//xs:enumeration", _wsdlNSM) != null)
            {
                return true;
            }
        }
        return false;
    }

    private string _nameSpace
    {
        get
        {
            return this._wsdlXDoc.LastChild.Attributes["targetNamespace"].Value;
        }
    }

    private XmlNode _getSoapTypeNodeFromWsdlXml(XmlDocument soapXmlDoc, XmlNode wsdlTypeNode, string typeName, string paramName)
    {

        if (!typeName.Contains(":"))
        {
            throw new Exception($"Invalid typeName: {typeName}");
        }

        var typeNameWithoutPrefix = typeName.Remove(0, typeName.IndexOf(':') + 1);
        var typeNode = soapXmlDoc.CreateElement(WsdlToSoap.NSPrefix, paramName, this._nameSpace);

        // primitive type and simple type
        var defaultValue = this._defaultValue(typeName);
        if (!string.IsNullOrWhiteSpace(defaultValue))
        {
            typeNode = soapXmlDoc.CreateElement("", paramName, "");
            typeNode.AppendChild(soapXmlDoc.CreateTextNode(defaultValue));
            return typeNode;
        }

        // if has base type, get it
        var baseTypeNodes = this._getBaseTypeFromWsdlXml(soapXmlDoc, wsdlTypeNode, typeName, paramName);
        baseTypeNodes.ForEach((subTypeNode) => {
            typeNode.AppendChild(subTypeNode);
        });

        // complex type, execute recursive
        var compositeTypeNodes = wsdlTypeNode.SelectNodes($".//xs:complexType[@name='{typeNameWithoutPrefix}']//xs:sequence/xs:element[@name][@type]", _wsdlNSM);
        if (0 == compositeTypeNodes.Count)
        {
            return null;
        }

        for (var i = 0; i < compositeTypeNodes.Count; ++i)
        {
            var compositeParamName = compositeTypeNodes.Item(i).Attributes["name"].Value;
            var compositeTypeName = compositeTypeNodes.Item(i).Attributes["type"].Value;
            var compsiteTypeNode = this._getSoapTypeNodeFromWsdlXml(soapXmlDoc, wsdlTypeNode, compositeTypeName, compositeParamName);
            if (null != compsiteTypeNode)
            {
                typeNode.AppendChild(compsiteTypeNode);
            }
        }

        return typeNode;
    }

    private List<XmlNode> _getBaseTypeFromWsdlXml(XmlDocument soapXmlDoc, XmlNode wsdlTypeNode, string typeName, string paramName)
    {
        List<XmlNode> baseNodes = new List<XmlNode>();

        if (!typeName.Contains(":"))
        {
            throw new Exception($"Invalid typeName: {typeName}");
        }

        var typeNameWithoutPrefix = typeName.Remove(0, typeName.IndexOf(':') + 1);
        var typeNodeDef = wsdlTypeNode.SelectSingleNode($".//xs:complexType[@name='{typeNameWithoutPrefix}']", _wsdlNSM);
        if (null == typeNodeDef)
        {
            return baseNodes;
        }

        var baseNode = typeNodeDef.SelectSingleNode(".//xs:extension[@base]", _wsdlNSM);
        if (null == baseNode)
        {
            return baseNodes;
        }

        var baseTypeName = baseNode.Attributes["base"].Value;
        var baseTypeNameWithoutPrefix = baseTypeName.Contains(":") ? baseTypeName.Remove(0, baseTypeName.IndexOf(':') + 1) : baseTypeName;

        var baseTypeCompositeTypes = wsdlTypeNode.SelectNodes($".//xs:complexType[@name='{baseTypeNameWithoutPrefix}']//xs:sequence/xs:element[@name][@type]", _wsdlNSM);
        for (var i = 0; i < baseTypeCompositeTypes.Count; ++i)
        {
            var baseTypeCompositeTypeNode = baseTypeCompositeTypes.Item(i);
            var baseTypeCompositeTypeName = baseTypeCompositeTypeNode.Attributes["type"].Value;
            var baseTypeCompositeParamName = baseTypeCompositeTypeNode.Attributes["name"].Value;

            var baseTypeCompositeTypeSoapNode = this._getSoapTypeNodeFromWsdlXml(soapXmlDoc, wsdlTypeNode, baseTypeCompositeTypeName, baseTypeCompositeParamName);
            if (null != baseTypeCompositeTypeSoapNode)
            {
                baseNodes.Add(baseTypeCompositeTypeSoapNode);
            }
        }

        return baseNodes;
    }

    #region operation
    private List<string> AllMethods
    {
        get
        {
            var methodList = new List<string>();
            var nodeList = this._wsdlXDoc.SelectNodes("./wsdl:definitions/wsdl:portType/wsdl:operation[@name]", this._wsdlNSM);
            for (int i = 0; i < nodeList.Count; ++i)
            {
                methodList.Add(nodeList.Item(i).Attributes["name"].Value);
            }
            return methodList;
        }
    }

    private string BuildSkeleton()
    {
        return WsdlToSoap._soapSkeleton.Replace(WsdlToSoap.NSPlaceHolder, this._nameSpace);
    }

    private string BuildSoapMethodElements(string soapContent, string methodName)
    {
        XmlDocument doc = new XmlDocument();
        doc.LoadXml(soapContent);
        var targetNode = doc.LastChild.FirstChild; //"SOAP-ENV:Body" node
        var sourceNode = this._wsdlXDoc.SelectSingleNode($"./wsdl:definitions/wsdl:types//xs:element[@name='{methodName}']", _wsdlNSM);
        var sourceH = this._wsdlXDoc.SelectSingleNode($"./wsdl:definitions/wsdl:types//xs:complexType[@name='{methodName}']", _wsdlNSM);
        if (null == sourceNode)
        {
            return doc.OuterXml;
        }

        var wsdlTypeNode = this._wsdlXDoc.SelectSingleNode("./wsdl:definitions/wsdl:types", _wsdlNSM);

        // insert method name
        var methodNode = doc.CreateElement(WsdlToSoap.NSPrefix, methodName, this._nameSpace);
        targetNode = targetNode.AppendChild(methodNode);

        // insert parameter
        //HVA: He cambiado aqui para que lea los parámetros
        var paramNodes = sourceH.SelectNodes("./xs:sequence/xs:element[@name][@type]", _wsdlNSM);
        for (var i = 0; i < paramNodes.Count; ++i)
        {
            var paramNode = paramNodes.Item(i);
            var paramType = paramNode.Attributes["type"].Value;
            var paramName = paramNode.Attributes["name"].Value;
            var paramSoapNode = this._getSoapTypeNodeFromWsdlXml(doc, wsdlTypeNode, paramType, paramName);
            //var paramSoapNode = this._getSoapTypeNodeFromWsdlXml(doc, wsdlTypeNode, paramType, paramName);
            if (paramSoapNode != null)
            {
                targetNode.AppendChild(paramSoapNode);
            }
        }

        return doc.OuterXml;
    }
    #endregion operation
    #endregion
}
