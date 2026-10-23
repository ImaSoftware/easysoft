using System.IO;
using System.Security.Cryptography.X509Certificates;
using System.Xml;
using NUnit.Framework;
using XadesNetLib.XAdES;

namespace Testing
{
    [TestFixture]
    public class XadesBesSignTest :TestBase
    {
        private string _bugBasePath = BaseFilesPath + @"\xadesbes\";
        private string _bug38InputFilePath;

        public XadesBesSignTest()
        {
            _bug38InputFilePath = _bugBasePath + "Bug38Input.xml";
            _bug38InputFilePath = "C:\\TMPALP\\unsigned.xml";
        }

        #region Common to all tests

        private XmlDocument SignXadesBes(string inputPath, X509Certificate2 selectedCertificate)
        {
            return XadesHelper.Sign(inputPath).Using(selectedCertificate).
                IncludingCertificateInSignature().SignAndGetXml();
        }
              
        #endregion

        /// <summary>
        /// Tests that an output file path is not needed when using the
        /// .SignAndGetXml() method.
        /// More info in:
        /// http://xadesnet.codeplex.com/Thread/View.aspx?ThreadId=243659
        /// </summary>
        [Test]        
        public void TestBug38()
        {
            //X509Certificate2 certificate = GetTestCertificate();
            X509Certificate2 certificate = new X509Certificate2("C:\\TMPALP\\cert1.p12", "Nabecame166", X509KeyStorageFlags.DefaultKeySet);
            XmlDocument document = XadesHelper.Sign(_bug38InputFilePath).Using(certificate).IncludingCertificateInSignature().SignAndGetXml();
            Assert.IsNotNullOrEmpty(document.OuterXml);
        }
    }
}
