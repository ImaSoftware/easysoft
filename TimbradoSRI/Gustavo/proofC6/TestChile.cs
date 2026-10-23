using System;
using System.Diagnostics;
using System.Text;
using CryptoSysPKI;

namespace TestChile
{
    class TestChile
    {
        // $Id: TestChile.cs $
        // $Date: 2010-06-24 06:10 $
        // $Author: dai $

        // This module uses functions from the CryptoSys (tm) PKI Toolkit available from
        // <www.cryptosys.net/pki/>.

        // *************************** COPYRIGHT NOTICE ******************************
        // This code was originally written by David Ireland and is copyright
        // (C) 2008-10 DI Management Services Pty Ltd <www.di-mgt.com.au>.
        // Provided "as is". No warranties. Use at your own risk. You must make your
        // own assessment of its accuracy and suitability for your own purposes.
        // It is not to be altered or distributed, except as part of an application.
        // You are free to use it in any application, provided this copyright notice
        // is left unchanged.
        // ************************ END OF COPYRIGHT NOTICE **************************

        // NOTES: Some of these procedures are specific for the Chile SII examples.
        // Other procedures are more generic and could be used in more general PKI
        // programs, perhaps with minor amendments.
        // These are marked $GENERIC-FUNCTION$.

        // Ref: F60T33-ejemplo.xml

        public static void Read_SmallerKeys()
        {
            // From manual_certificacion.pdf, 2003-11-26, p25
            string strKeyPem = null;
            int nRet = 0;
            string strPrivateKey = null;
            string strPublicKey = null;
            string strXmlKey = null;
            string strSig64 = null;
            byte[] abData = null;
            int nDataLen = 0;
            int nKeyLen = 0;
            byte[] abDigest = null;

            // CAUTION: Your real Private Key should be kept SECRET and should never be hard-coded in code like, er, this...
            // Put PEM data into a string
            // (Note two critical vbCrLF's added before and after base64 data)
            strKeyPem = "-----BEGIN RSA PRIVATE KEY-----" + "\n" 
                + "MIIBOwIBAAJBANGuDuim8fEI9yuIlkj+MOyp3mWHifoP6a4oWLSBKJSrd3MpEsZd" 
                + "czvL0l7t/e0IU5rF+0gRLnU1Mfvtsw1wYWcCAQMCQQCLyV9FxKFLW09yWw7bVCCd" 
                + "xpRDr7FRX/EexZB4VhsNxm/vtJfDZyYle0Lfy42LlcsXxPm1w6Q6NnjuW+AeBy67" 
                + "AiEA7iMi5q5xjswqq+49RP55o//jqdZL/pC9rdnUKxsNRMMCIQDhaHdIctErN2hC" 
                + "IP9knS3+9zra4R+5jSXOvI+3xVhWjQIhAJ7CF0R0S7SIHHKe04NUURf/7RvkMqm1" 
                + "08k74sdnXi3XAiEAlkWk2vc2HM+a1sCqQxNz/098ketqe7NuidMKeoOQObMCIQCk" 
                + "FAMS9IcPcMjk7zI2r/4EEW63PSXyN7MFAX7TYe25mw==" 
                + "\n" + "-----END RSA PRIVATE KEY-----";

            // Read the PEM private key data into an internal key string we can use later on...
            // -- this example key is stored in a PKCS#8 PrivateKeyInfo without a password :-(
            strPrivateKey = Rsa.ReadPrivateKeyInfo(strKeyPem).ToString();
            // CAUTION: the above trick to read into a string is a big security risk
            // -- the point of using a StringBuilder is that it can be wiped later

            Console.WriteLine("Private key is " + Rsa.KeyBits(strPrivateKey) + " bits");

            // Now we compare this private key with the published public key in the XML file...

            // Form XML string of public key in proper XMLSIG format using <RSAPK> element from XML file
            // <RSAPK><M>0a4O6Kbx8Qj3K4iWSP4w7KneZYeJ+g/prihYtIEolKt3cykSxl1zO8vSXu397QhTmsX7SBEudTUx++2zDXBhZw==</M><E>Aw==</E></RSAPK>
            // NOTE: We have changed the element names to the required XMLSIG format:
            // <RSAPK> --> <RSAKeyValue>
            // <M>     --> <Modulus>
            // <E>     --> <Exponent>
            strXmlKey = "<RSAKeyValue>" 
                + "<Modulus>0a4O6Kbx8Qj3K4iWSP4w7KneZYeJ+g/prihYtIEolKt3cykSxl1zO8vSXu397QhTmsX7SBEudTUx++2zDXBhZw==</Modulus>" 
                + "<Exponent>Aw==</Exponent></RSAKeyValue>";
            // Convert XML form to our internal format
            strPublicKey = Rsa.FromXMLString(strXmlKey, false);
            Console.WriteLine("Public key is " + Rsa.KeyBits(strPublicKey) + " bits");

            // Check that key pairs match...
            nRet = Rsa.KeyMatch(strPrivateKey, strPublicKey);
            Console.WriteLine("RSA_KeyMatch returns " + nRet + " (expecting 0)");

            // Then use the PUBLIC key to extract the message digest from the signature value...

            // Extract digest from FRMT
            // <FRMT algoritmo="SHA1withRSA">GbmDcS9e/jVC2LsLIe1iRV12Bf6lxsILtbQiCkh6mbjckFCJ7fj/kakFTS06Jo8i
            // S4HXvJj3oYZuey53Krniew==</FRMT>
            strSig64 = "GbmDcS9e/jVC2LsLIe1iRV12Bf6lxsILtbQiCkh6mbjckFCJ7fj/kakFTS06Jo8iS4HXvJj3oYZuey53Krniew==";

            // Convert signatureValue to byte format
            abData = System.Convert.FromBase64String(strSig64);
            Console.WriteLine("SIGNATURE=" + Cnv.ToHex(abData));
            nDataLen = abData.Length;
            Console.WriteLine("Signature is " + nDataLen + " bytes long");
            // Check the length
            nKeyLen = Rsa.KeyBytes(strPublicKey);
            Console.WriteLine("Key is " + nKeyLen + " bytes long");
            if (nKeyLen != nDataLen)
            {
                Console.WriteLine("ERROR: Key is the wrong length!");
                return;
            }
            // Decrypt the signature
            abData = Rsa.RawPublic(abData, strPublicKey);
            if (nRet != 0)
            {
                Console.WriteLine("ERROR: " + General.ErrorLookup(nRet));
                return;
            }
            Console.WriteLine("EMSA BLOCK=" + Cnv.ToHex(abData));

            // Extract digest from block
            abDigest = Rsa.DecodeDigestForSignature(abData);

            // Display digest bytes as hex and base64
            Console.WriteLine("DIGEST=" + Cnv.ToHex(abDigest));
            Console.WriteLine("base64=" + System.Convert.ToBase64String(abDigest));

        }

        public static void MakeFRMTdigest()
        {
            // This should give the same digest value we obtained above.
            string strData = null;
            string strDigest = null;
            // Put <DD> data into a single string with no spaces between elements (and fix double-quotes for VB when hard-coded here!)
            strData = "<DD><RE>97975000-5</RE><TD>33</TD><F>60</F><FE>2003-10-13</FE><RR>77777777-7</RR><RSR>EMPRESA  LTDA</RSR><MNT>119000</MNT><IT1>Parlantes Multimedia 180W.</IT1><CAF version=\"1.0\"><DA><RE>97975000-5</RE><RS>RUT DE PRUEBA</RS><TD>33</TD><RNG><D>1</D><H>200</H></RNG><FA>2003-09-04</FA><RSAPK><M>0a4O6Kbx8Qj3K4iWSP4w7KneZYeJ+g/prihYtIEolKt3cykSxl1zO8vSXu397QhTmsX7SBEudTUx++2zDXBhZw==</M><E>Aw==</E></RSAPK><IDK>100</IDK></DA><FRMA algoritmo=\"SHA1withRSA\">g1AQX0sy8NJugX52k2hTJEZAE9Cuul6pqYBdFxj1N17umW7zG/hAavCALKByHzdYAfZ3LhGTXCai5zNxOo4lDQ==</FRMA></CAF><TSTED>2003-10-13T09:33:20</TSTED></DD>";
            // Create an SHA-1 digest value in hex format
            strDigest = Hash.HexFromString(strData, HashAlgorithm.Sha1);
            Console.WriteLine("SHA1(DD)=" + strDigest);
            // Display in base64
            Console.WriteLine("SHA1(DD)=" + System.Convert.ToBase64String(Cnv.FromHex(strDigest)));
        }

        public static void SignDDtoMakeFRMTsig()
        {
            // Use the RSA private key to sign the <DD> data.
            // INPUT:  RSA private key in PEM format
            //         Data-to-be signed
            // OUTPUT: SignatureValue in base64 form

            string strKeyPem = null;
            string strData = null;
            string strPrivateKey = null;
            int nKeyBytes = 0;
            byte[] abBlock = null;
            byte[] abData = null;
            int nDataLen = 0;
            string strSigVal64 = null;

            // Input data:
            strData = "<DD><RE>97975000-5</RE><TD>33</TD><F>60</F><FE>2003-10-13</FE><RR>77777777-7</RR><RSR>EMPRESA  LTDA</RSR><MNT>119000</MNT><IT1>Parlantes Multimedia 180W.</IT1><CAF version=\"1.0\"><DA><RE>97975000-5</RE><RS>RUT DE PRUEBA</RS><TD>33</TD><RNG><D>1</D><H>200</H></RNG><FA>2003-09-04</FA><RSAPK><M>0a4O6Kbx8Qj3K4iWSP4w7KneZYeJ+g/prihYtIEolKt3cykSxl1zO8vSXu397QhTmsX7SBEudTUx++2zDXBhZw==</M><E>Aw==</E></RSAPK><IDK>100</IDK></DA><FRMA algoritmo=\"SHA1withRSA\">g1AQX0sy8NJugX52k2hTJEZAE9Cuul6pqYBdFxj1N17umW7zG/hAavCALKByHzdYAfZ3LhGTXCai5zNxOo4lDQ==</FRMA></CAF><TSTED>2003-10-13T09:33:20</TSTED></DD>";
            strKeyPem = "-----BEGIN RSA PRIVATE KEY-----" + "\n" 
                + "MIIBOwIBAAJBANGuDuim8fEI9yuIlkj+MOyp3mWHifoP6a4oWLSBKJSrd3MpEsZd" 
                + "czvL0l7t/e0IU5rF+0gRLnU1Mfvtsw1wYWcCAQMCQQCLyV9FxKFLW09yWw7bVCCd" 
                + "xpRDr7FRX/EexZB4VhsNxm/vtJfDZyYle0Lfy42LlcsXxPm1w6Q6NnjuW+AeBy67" 
                + "AiEA7iMi5q5xjswqq+49RP55o//jqdZL/pC9rdnUKxsNRMMCIQDhaHdIctErN2hC" 
                + "IP9knS3+9zra4R+5jSXOvI+3xVhWjQIhAJ7CF0R0S7SIHHKe04NUURf/7RvkMqm1" 
                + "08k74sdnXi3XAiEAlkWk2vc2HM+a1sCqQxNz/098ketqe7NuidMKeoOQObMCIQCk" 
                + "FAMS9IcPcMjk7zI2r/4EEW63PSXyN7MFAX7TYe25mw==" 
                + "\n" + "-----END RSA PRIVATE KEY-----";

            // Read the PEM private key data into an internal key string
            strPrivateKey = Rsa.ReadPrivateKeyInfo(strKeyPem).ToString();
            // CAUTION: the above trick to read into a string is a big security risk
            // -- the point of using a StringBuilder is that it can be wiped later

            Console.WriteLine("Private key is " + Rsa.KeyBits(strPrivateKey) + " bits long");
            

            // Convert the input data string into a byte array
            abData = System.Text.Encoding.Default.GetBytes(strData);
            Console.WriteLine("Data=(0x)" + Cnv.ToHex(abData));
            nDataLen = abData.Length;
            Console.WriteLine("Input data is " + nDataLen + " bytes long");

            // Encode into a block the exact same length as the RSA key...

            // Get the length of the key in bytes -- we need an output block exactly this length
            nKeyBytes = Rsa.KeyBytes(strPrivateKey);
            Console.WriteLine("Private key is  " + nKeyBytes + " bytes long");

            // Encode the data -- this computes the message digest and then encodes into an EMSA block in one step
            abBlock = Rsa.EncodeMsgForSignature(nKeyBytes, abData, HashAlgorithm.Sha1);
            if (abBlock.Length == 0)
            {
                Console.WriteLine("ERROR: RSA_EncodeMsg failed. Error: " + General.LastError());
                return;
            }
            Console.WriteLine("EMSA BLOCK=" + Cnv.ToHex(abBlock));

            // Sign, i.e. encrypt, the encoded block with the RSA private key
            abBlock = Rsa.RawPrivate(abBlock, strPrivateKey);
            if (abBlock.Length == 0)
            {
                Console.WriteLine("ERROR: RSA_RawPrivate failed. Error: " + General.LastError());
                return;
            }
            Console.WriteLine("SIGNATURE= " + Cnv.ToHex(abBlock));

            // Convert byte array to base64
            strSigVal64 = System.Convert.ToBase64String(abBlock);
            Console.WriteLine("SignatureValue=" + strSigVal64);

        }

        public static string XmlHexFromInternalKey(string strKey)
        {
            string functionReturnValue = null;
            // $GENERIC-FUNCTION$
            // INPUT:  Public or private RSA key in internal format
            // OUTPUT: String containing RSAKeyValue in XML format
            string strXmlKey = null;
            Rsa.XmlOptions nOptions = default(Rsa.XmlOptions);

            nOptions = Rsa.XmlOptions.HexBinaryFormat | Rsa.XmlOptions.ExcludePrivateParams | Rsa.XmlOptions.ForceRSAKeyValue;
            strXmlKey = Rsa.ToXMLString(strKey, nOptions);
            if (strXmlKey.Length > 0)
            {
                functionReturnValue = strXmlKey;
            }
            else
            {
                functionReturnValue = "**Failed to create public key in XML";
            }
            return functionReturnValue;

        }

        public static bool IsCertAndKeyValueMatched(string strCert64, string strXmlKey)
        {
            // $GENERIC-FUNCTION$
            // Compare the public key values in <RSAKeyValue> and <X509Certificate> values
            // INPUT:  RSAKeyValue in base64 string INCLUDING <RSAKeyValue> tags;
            //         X509Certificate in base64 string EXCLUDING <X509Certificate> tags
            // OUTPUT: True if public key matches; otherwise False.
            // REMARKS: The X509Certificate contains the public key value plus other info.

            string strPublicKey = null;
            string strQuery = null;
            string strOutput = null;
            int nHashCode1 = 0;
            int nHashCode2 = 0;
            bool result = false;

            // Query the certificate for details...
            strQuery = "issuerName";
            strOutput = X509.QueryCert(strCert64, strQuery);
            if (strOutput.Length == 0)
            {
                Console.WriteLine("ERROR: Error reading certificate: " + General.LastError());
                return result;
                // ERROR
            }
            Console.WriteLine(strQuery + "=" + strOutput);

            strQuery = "serialNumber";
            strOutput = X509.QueryCert(strCert64, strQuery);
            if (strOutput.Length == 0)
            {
                Console.WriteLine("ERROR: Error reading certificate: " + General.LastError());
                return result;
                // ERROR
            }
            Console.WriteLine(strQuery + "=" + strOutput);

            strQuery = "subjectName";
            strOutput = X509.QueryCert(strCert64, strQuery);
            if (strOutput.Length == 0)
            {
                Console.WriteLine("ERROR: Error reading certificate: " + General.LastError());
                return result;
                // ERROR
            }
            Console.WriteLine(strQuery + "=" + strOutput);

            strQuery = "notBefore";
            strOutput = X509.QueryCert(strCert64, strQuery);
            if (strOutput.Length == 0)
            {
                Console.WriteLine("ERROR: Error reading certificate: " + General.LastError());
                return result;
                // ERROR
            }
            Console.WriteLine(strQuery + "=" + strOutput);

            strQuery = "signatureAlgorithm";
            strOutput = X509.QueryCert(strCert64, strQuery);
            if (strOutput.Length == 0)
            {
                Console.WriteLine("ERROR: Error reading certificate: " + General.LastError());
                return result;
                // ERROR
            }
            Console.WriteLine(strQuery + "=" + strOutput);

            // Extract public key from X.509 certificate
            strPublicKey = Rsa.GetPublicKeyFromCert(strCert64).ToString();
            if (strPublicKey.Length == 0)
            {
                Console.WriteLine("ERROR: Error reading certificate key: " + General.LastError());
                return result;
                // ERROR
            }
            Console.WriteLine("Public key extracted from <X509Certificate>:");
            Console.WriteLine("Public key is " + Rsa.KeyBits(strPublicKey) + " bits");
            nHashCode1 = Rsa.KeyHashCode(strPublicKey);
            Console.WriteLine("Public key hashcode = {0,8:X}", nHashCode1);

            // While we're here, display the public key in XML format
            Console.WriteLine(XmlHexFromInternalKey(strPublicKey));

            // Convert XML form to our internal format (this requires the <RSAKeyvalue> tags)
            strPublicKey = Rsa.FromXMLString(strXmlKey, true);
            if (strPublicKey.Length == 0)
            {
                Console.WriteLine("ERROR: Unable to read XML key string");
                return result;
            }
            Console.WriteLine("Public key given in <RSAKeyValue>:");
            Console.WriteLine("Public key is " + Rsa.KeyBits(strPublicKey) + " bits");
            nHashCode2 = Rsa.KeyHashCode(strPublicKey);
            Console.WriteLine("Public key hashcode = {0,8:X}", nHashCode2);
            Console.WriteLine(XmlHexFromInternalKey(strPublicKey));

            if (nHashCode1 == nHashCode2)
            {
                result = true;
                Console.WriteLine("OK, public keys match.");
            }
            else
            {
                result = false;
                Console.WriteLine("ERROR: public keys do not match.");
            }
            return result;

        }

        public static void CheckExampleCertAndRSAKey()
        {
            // Ref: F60T33-ejemplo.xml, 2003-10-13

            // THIS TEST FAILS BECAUSE THE RSAKeyValue IS WRONG

            // <RSAKeyValue>
            // <Modulus>
            // tNEknkb1kHiD1OOAWlLKkcH/UP5UGa6V6MYso++JB+vYMg2OXFROAF7G8BNFFPQx
            // iuS/7y1azZljN2xq+bW3bAou1bW2ij7fxSXWTJYFZMAyndbLyGHM1e3nVmwpgEpx
            // BHhZzPvwLb55st1wceuKjs2Ontb13J33sUb7bbJMWh0=
            // </Modulus>
            // <Exponent>
            // AQAB
            // </Exponent>
            // </RSAKeyValue>

            // <X509Certificate>MIIEgjCCA+ugAwIBAgIEAQAApzANBgkqhkiG9w0BAQUFADCBtTELMAkGA1UEBhMC
            // Q0wxHTAbBgNVBAgUFFJlZ2lvbiBNZXRyb3BvbGl0YW5hMREwDwYDVQQHFAhTYW50
            // aWFnbzEUMBIGA1UEChQLRS1DRVJUQ0hJTEUxIDAeBgNVBAsUF0F1dG9yaWRhZCBD
            // ZXJ0aWZpY2Fkb3JhMRcwFQYDVQQDFA5FLUNFUlRDSElMRSBDQTEjMCEGCSqGSIb3
            // DQEJARYUZW1haWxAZS1jZXJ0Y2hpbGUuY2wwHhcNMDMxMDAxMTg1ODE1WhcNMDQw
            // OTMwMDAwMDAwWjCBuDELMAkGA1UEBhMCQ0wxFjAUBgNVBAgUDU1ldHJvcG9saXRh
            // bmExETAPBgNVBAcUCFNhbnRpYWdvMScwJQYDVQQKFB5TZXJ2aWNpbyBkZSBJbXB1
            // ZXN0b3MgSW50ZXJub3MxDzANBgNVBAsUBlBpc28gNDEjMCEGA1UEAxQaV2lsaWJh
            // bGRvIEdvbnphbGV6IENhYnJlcmExHzAdBgkqhkiG9w0BCQEWEHdnb256YWxlekBz
            // aWkuY2wwgZ8wDQYJKoZIhvcNAQEBBQADgY0AMIGJAoGBALxZlVh1xr9sKQIBDF/6
            // Va+lsHQSG5AAmCWvtNTIOXN3E9EQCy7pOPHrDg6EusvoHyesZSKJbc0TnIFXZp78
            // q7mbdHijzKqvMmyvwbdP7KK8LQfwf84W4v9O8MJeUHlbJGlo5nFACrPAeTtONbHa
            // ReyzeMDv2EganNEDJc9c+UNfAgMBAAGjggGYMIIBlDAjBgNVHREEHDAaoBgGCCsG
            // AQQBwQEBoAwWCjA3ODgwNDQyLTQwCQYDVR0TBAIwADA8BgNVHR8ENTAzMDGgL6At
            // hitodHRwOi8vY3JsLmUtY2VydGNoaWxlLmNsL2UtY2VydGNoaWxlY2EuY3JsMCMG
            // A1UdEgQcMBqgGAYIKwYBBAHBAQKgDBYKOTY5MjgxODAtNTAfBgNVHSMEGDAWgBTg
            // KP3S4GBPs0brGsz1CJEHcjodCDCB0AYDVR0gBIHIMIHFMIHCBggrBgEEAcNSBTCB
            // tTAvBggrBgEFBQcCARYjaHR0cDovL3d3dy5lLWNlcnRjaGlsZS5jbC8yMDAwL0NQ
            // Uy8wgYEGCCsGAQUFBwICMHUac0VsIHRpdHVsYXIgaGEgc2lkbyB2YWxpZG8gZW4g
            // Zm9ybWEgcHJlc2VuY2lhbCwgcXVlZGFuZG8gZWwgQ2VydGlmaWNhZG8gcGFyYSB1
            // c28gdHJpYnV0YXJpbywgcGFnb3MsIGNvbWVyY2lvIHkgb3Ryb3MwCwYDVR0PBAQD
            // AgTwMA0GCSqGSIb3DQEBBQUAA4GBABMfCyJF0mNXcov8iEWvjGFyyPTsXwvsYbbk
            // OJ41wjaGOFMCInb4WY0ngM8BsDV22bGMs8oLyX7rVy16bGA8Z7WDUtYhoOM7mqXw
            // /Hrpqjh3JgAf8zqdzBdH/q6mAbdvq/yb04JHKWPC7fMFuBoeyVWAnhmuMZfReWQi
            // MUEHGGIW</X509Certificate>

            string strCert64 = null;
            string strXmlKey = null;

            strCert64 = "MIIEgjCCA+ugAwIBAgIEAQAApzANBgkqhkiG9w0BAQUFADCBtTELMAkGA1UEBhMCQ0wxHTAbBgNVBAgUFFJlZ2lvbiBNZXRyb3BvbGl0YW5hMREwDwYDVQQHFAhTYW50aWFnbzEUMBIGA1UEChQLRS1DRVJUQ0hJTEUxIDAeBgNVBAsUF0F1dG9yaWRhZCBDZXJ0aWZpY2Fkb3JhMRcwFQYDVQQDFA5FLUNFUlRDSElMRSBD" 
                + "QTEjMCEGCSqGSIb3DQEJARYUZW1haWxAZS1jZXJ0Y2hpbGUuY2wwHhcNMDMxMDAxMTg1ODE1WhcNMDQwOTMwMDAwMDAwWjCBuDELMAkGA1UEBhMCQ0wxFjAUBgNVBAgUDU1ldHJvcG9saXRhbmExETAPBgNVBAcUCFNhbnRpYWdvMScwJQYDVQQKFB5TZXJ2aWNpbyBkZSBJbXB1ZXN0b3MgSW50ZXJub3MxDzANBgNVBAsU" 
                + "BlBpc28gNDEjMCEGA1UEAxQaV2lsaWJhbGRvIEdvbnphbGV6IENhYnJlcmExHzAdBgkqhkiG9w0BCQEWEHdnb256YWxlekBzaWkuY2wwgZ8wDQYJKoZIhvcNAQEBBQADgY0AMIGJAoGBALxZlVh1xr9sKQIBDF/6Va+lsHQSG5AAmCWvtNTIOXN3E9EQCy7pOPHrDg6EusvoHyesZSKJbc0TnIFXZp78q7mbdHijzKqvMmyv" 
                + "wbdP7KK8LQfwf84W4v9O8MJeUHlbJGlo5nFACrPAeTtONbHaReyzeMDv2EganNEDJc9c+UNfAgMBAAGjggGYMIIBlDAjBgNVHREEHDAaoBgGCCsGAQQBwQEBoAwWCjA3ODgwNDQyLTQwCQYDVR0TBAIwADA8BgNVHR8ENTAzMDGgL6AthitodHRwOi8vY3JsLmUtY2VydGNoaWxlLmNsL2UtY2VydGNoaWxlY2EuY3JsMCMG" 
                + "A1UdEgQcMBqgGAYIKwYBBAHBAQKgDBYKOTY5MjgxODAtNTAfBgNVHSMEGDAWgBTgKP3S4GBPs0brGsz1CJEHcjodCDCB0AYDVR0gBIHIMIHFMIHCBggrBgEEAcNSBTCBtTAvBggrBgEFBQcCARYjaHR0cDovL3d3dy5lLWNlcnRjaGlsZS5jbC8yMDAwL0NQUy8wgYEGCCsGAQUFBwICMHUac0VsIHRpdHVsYXIgaGEgc2lk" 
                + "byB2YWxpZG8gZW4gZm9ybWEgcHJlc2VuY2lhbCwgcXVlZGFuZG8gZWwgQ2VydGlmaWNhZG8gcGFyYSB1c28gdHJpYnV0YXJpbywgcGFnb3MsIGNvbWVyY2lvIHkgb3Ryb3MwCwYDVR0PBAQDAgTwMA0GCSqGSIb3DQEBBQUAA4GBABMfCyJF0mNXcov8iEWvjGFyyPTsXwvsYbbkOJ41wjaGOFMCInb4WY0ngM8BsDV22bGM" 
                + "s8oLyX7rVy16bGA8Z7WDUtYhoOM7mqXw/Hrpqjh3JgAf8zqdzBdH/q6mAbdvq/yb04JHKWPC7fMFuBoeyVWAnhmuMZfReWQiMUEHGGIW";

            strXmlKey = "<RSAKeyValue><Modulus>" 
                + "tNEknkb1kHiD1OOAWlLKkcH/UP5UGa6V6MYso++JB+vYMg2OXFROAF7G8BNFFPQx" 
                + "iuS/7y1azZljN2xq+bW3bAou1bW2ij7fxSXWTJYFZMAyndbLyGHM1e3nVmwpgEpx" 
                + "BHhZzPvwLb55st1wceuKjs2Ontb13J33sUb7bbJMWh0=</Modulus>" 
                + "<Exponent>AQAB</Exponent></RSAKeyValue>";

            Console.WriteLine(IsCertAndKeyValueMatched(strCert64, strXmlKey));

        }

        public static void CheckManualCertAndRSAKey()
        {
            // Ref: manual_certificacion.pdf, 2003-11-26

            // THIS TEST FAILS BECAUSE THE RSAKeyValue IS WRONG

            // <RSAKeyValue>
            // <Modulus>
            // tNEknkb1kHiD1OOAWlLKkcH/UP5UGa6V6MYso++JB+vYMg2OXFROAF7G8BNFFPQx
            // iuS/7y1azZljN2xq+bW3bAou1bW2ij7fxSXWTJYFZMAyndbLyGHM1e3nVmwpgEpx
            // BHhZzPvwLb55st1wceuKjs2Ontb13J33sUb7bbJMWh0=
            // </Modulus>
            // <Exponent>
            // AQAB
            // </Exponent>
            // </RSAKeyValue>

            // <X509Certificate>MIIEPjCCA6mgAwIBAgIDAgGKMAsGCSqGSIb3DQEBBDCBsTEdMBsGA1UECBQUUmVn
            // aW9uIE1ldHJvcG9saXRhbmExETAPBgNVBAcUCFNhbnRpYWdvMSIwIAYDVQQDFBlF
            // LUNlcnRjaGlsZSBDQSBJbnRlcm1lZGlhMTYwNAYDVQQLFC1FbXByZXNhIE5hY2lv
            // bmFsIGRlIENlcnRpZmljYWNpb24gRWxlY3Ryb25pY2ExFDASBgNVBAoUC0UtQ0VS
            // VENISUxFMQswCQYDVQQGEwJDTDAeFw0wMjEwMDIxOTExNTlaFw0wMzEwMDIwMDAw
            // MDBaMIHXMR0wGwYDVQQIFBRSZWdpb24gTWV0cm9wb2xpdGFuYTEnMCUGA1UECxQe
            // U2VydmljaW8gZGUgSW1wdWVzdG9zIEludGVybm9zMScwJQYDVQQKFB5TZXJ2aWNp
            // byBkZSBJbXB1ZXN0b3MgSW50ZXJub3MxETAPBgNVBAcUCFNhbnRpYWdvMR8wHQYJ
            // KoZIhvcNAQkBFhB3Z29uemFsZXpAc2lpLmNsMSMwIQYDVQQDFBpXaWxpYmFsZG8g
            // R29uemFsZXogQ2FicmVyYTELMAkGA1UEBhMCQ0wwXDANBgkqhkiG9w0BAQEFAANL
            // ADBIAkEAvNQyaLPd3cQlBr0fQWooAKXSFan/WbaFtD5P7QDzcE1pBIvKY2Uv6uid
            // ur/mGVB9IS4Fq/1xRIXy13FFmxLwTQIDAQABo4IBgjCCAX4wIwYDVR0RBBwwGqAY
            // BggrBgEEAcNSAaAMFgowNzg4MDQ0Mi00MDwGA1UdHwQ1MDMwMaAvoC2GK2h0dHA6
            // Ly9jcmwuZS1jZXJ0Y2hpbGUuY2wvRWNlcnRjaGlsZUNBSS5jcmwwIwYDVR0SBBww
            // GqAYBggrBgEEAcEBAqAMFgo5NjkyODE4MC01MIHmBgNVHSAEgd4wgdswgdgGCCsG
            // AQQBw1IAMIHLMDYGCCsGAQUFBwIBFipodHRwOi8vd3d3LmUtY2VydGNoaWxlLmNs
            // L3BvbGl0aWNhL2Nwcy5odG0wgZAGCCsGAQUFBwICMIGDGoGARWwgdGl0dWxhciBo
            // YSBzaWRvIHZhbGlkYWRvIGVuIGZvcm1hIHByZXNlbmNpYWwsIHF1ZWRhbmRvIGhh
            // YmlsaXRhZG8gZWwgQ2VydGlmaWNhZG8gcGFyYSB1c28gdHJpYnV0YXJpbywgcGFn
            // b3MsIGNvbWVyY2lvIHUgb3Ryb3MwCwYDVR0PBAQDAgTwMAsGCSqGSIb3DQEBBAOB
            // gQB2V4cTj7jo1RawmsRQUSnnvJjMCrZstcHY+Ss3IghVPO9eGoYzu5Q63vzt0Pi8
            // CS91SBc7xo+LDoljaUyjOzj7zvU7TpWoFndiTQF3aCOtTkV+vjCMWW3sVHes4UCM
            // DkF3VYK+rDTAadiaeDArTwsx4eNEpxFuA/TJwcXpLQRCDg==</X509Certificate>

            string strCert64 = null;
            string strXmlKey = null;

            strCert64 = "MIIEPjCCA6mgAwIBAgIDAgGKMAsGCSqGSIb3DQEBBDCBsTEdMBsGA1UECBQUUmVnaW9uIE1ldHJvcG9saXRhbmExETAPBgNVBAcUCFNhbnRpYWdvMSIwIAYDVQQDFBlFLUNlcnRjaGlsZSBDQSBJbnRlcm1lZGlhMTYwNAYDVQQLFC1FbXByZXNhIE5hY2lvbmFsIGRlIENlcnRpZmljYWNpb24gRWx" 
                + "lY3Ryb25pY2ExFDASBgNVBAoUC0UtQ0VSVENISUxFMQswCQYDVQQGEwJDTDAeFw0wMjEwMDIxOTExNTlaFw0wMzEwMDIwMDAwMDBaMIHXMR0wGwYDVQQIFBRSZWdpb24gTWV0cm9wb2xpdGFuYTEnMCUGA1UECxQeU2VydmljaW8gZGUgSW1wdWVzdG9zIEludGVybm9zMScwJQYDVQQKFB5TZXJ2aWNpbyBkZSBJbXB1ZXN" 
                + "0b3MgSW50ZXJub3MxETAPBgNVBAcUCFNhbnRpYWdvMR8wHQYJKoZIhvcNAQkBFhB3Z29uemFsZXpAc2lpLmNsMSMwIQYDVQQDFBpXaWxpYmFsZG8gR29uemFsZXogQ2FicmVyYTELMAkGA1UEBhMCQ0wwXDANBgkqhkiG9w0BAQEFAANLADBIAkEAvNQyaLPd3cQlBr0fQWooAKXSFan/WbaFtD5P7QDzcE1pBIvKY2Uv6ui" 
                + "dur/mGVB9IS4Fq/1xRIXy13FFmxLwTQIDAQABo4IBgjCCAX4wIwYDVR0RBBwwGqAYBggrBgEEAcNSAaAMFgowNzg4MDQ0Mi00MDwGA1UdHwQ1MDMwMaAvoC2GK2h0dHA6Ly9jcmwuZS1jZXJ0Y2hpbGUuY2wvRWNlcnRjaGlsZUNBSS5jcmwwIwYDVR0SBBwwGqAYBggrBgEEAcEBAqAMFgo5NjkyODE4MC01MIHmBgNVHSA" 
                + "Egd4wgdswgdgGCCsGAQQBw1IAMIHLMDYGCCsGAQUFBwIBFipodHRwOi8vd3d3LmUtY2VydGNoaWxlLmNsL3BvbGl0aWNhL2Nwcy5odG0wgZAGCCsGAQUFBwICMIGDGoGARWwgdGl0dWxhciBoYSBzaWRvIHZhbGlkYWRvIGVuIGZvcm1hIHByZXNlbmNpYWwsIHF1ZWRhbmRvIGhhYmlsaXRhZG8gZWwgQ2VydGlmaWNhZG8" 
                + "gcGFyYSB1c28gdHJpYnV0YXJpbywgcGFnb3MsIGNvbWVyY2lvIHUgb3Ryb3MwCwYDVR0PBAQDAgTwMAsGCSqGSIb3DQEBBAOBgQB2V4cTj7jo1RawmsRQUSnnvJjMCrZstcHY+Ss3IghVPO9eGoYzu5Q63vzt0Pi8CS91SBc7xo+LDoljaUyjOzj7zvU7TpWoFndiTQF3aCOtTkV+vjCMWW3sVHes4UCMDkF3VYK+rDTAadi" 
                + "aeDArTwsx4eNEpxFuA/TJwcXpLQRCDg==";

            strXmlKey = "<RSAKeyValue><Modulus>" 
                + "tNEknkb1kHiD1OOAWlLKkcH/UP5UGa6V6MYso++JB+vYMg2OXFROAF7G8BNFFPQx" 
                + "iuS/7y1azZljN2xq+bW3bAou1bW2ij7fxSXWTJYFZMAyndbLyGHM1e3nVmwpgEpx" 
                + "BHhZzPvwLb55st1wceuKjs2Ontb13J33sUb7bbJMWh0=</Modulus>" 
                + "<Exponent>AQAB</Exponent></RSAKeyValue>";

            Console.WriteLine(IsCertAndKeyValueMatched(strCert64, strXmlKey));

        }

        public static string Hash_String_SHA1(string strMessage, bool ShowDebug)
        {
            // $GENERIC-FUNCTION$
            // INPUT:  Message as an ANSI string
            // OUTPUT: SHA-1 message digest in hex format
            byte[] abMessage = null;
            int nmLen = 0;
            string strDigest = null;

            // Convert ANSI text to bytes
            abMessage = System.Text.Encoding.Default.GetBytes(strMessage);
            nmLen = abMessage.Length;

            if (ShowDebug)
            {
                Console.WriteLine("M (ansi):" + "\n" + "'" + System.Text.Encoding.Default.GetString(abMessage) + "'");
                Console.WriteLine("M (hex):  " + Cnv.ToHex(abMessage));
                Console.WriteLine("Message is " + nmLen + " bytes long");
            }

            strDigest = Hash.HexFromBytes(abMessage, HashAlgorithm.Sha1);
            if (strDigest.Length == 0)
            {
                Console.WriteLine("FAILED to create message digest");
            }

            return strDigest;

        }

        public static string Hash_File_SHA1(string strFileName)
        {
            // $GENERIC-FUNCTION$
            // INPUT:  Full path to file
            // OUTPUT: SHA-1 message digest in hex format
            string strDigest = null;

            strDigest = Hash.HexFromFile(strFileName, HashAlgorithm.Sha1);
            if (strDigest.Length == 0)
            {
                Console.WriteLine("FAILED to create message digest");
            }

            return strDigest;

        }


        public static void Test_Make_Hash_of_File()
        {
            Console.WriteLine("DIGEST=" + Hash_File_SHA1("data.canon.ok.txt"));

        }

        public static string MakeDigestValueOfSignedInfo(string strDigestValue64, string strReference, bool fIncludeXMLSchema, bool ShowDebug)
        {
            // $GENERIC-FUNCTION$
            // INPUT:  DigestValue of data in base64 format
            //         Reference as in <Reference URI="#...">
            //         Flag to include XMLSchema-instance attribute
            // OUTPUT: SHA-1 digest of canonicalized <SignedInfo> element in HEX format
            // REMARKS: This is for the specific form with no whitespace before any element

            string strSignedInfoCanonic = null;
            string strDigest = null;
            string strFirstLine = null;
            string chLf = String.Format("\n");    // String with single LF char

            //SPECIFIC FORM (no whitespace before elements):
            // <SignedInfo>
            // <CanonicalizationMethod Algorithm="http://www.w3.org/TR/2001/REC-xml-c14n-20010315"/>
            // <SignatureMethod Algorithm="http://www.w3.org/2000/09/xmldsig#rsa-sha1"/>
            // <Reference URI="#...">
            // <Transforms>
            // <Transform Algorithm="http://www.w3.org/TR/2001/REC-xml-c14n-20010315"/>
            // </Transforms>
            // <DigestMethod Algorithm="http://www.w3.org/2000/09/xmldsig#sha1"/>
            // <DigestValue>...</DigestValue>
            // </Reference>
            // </SignedInfo>

            // To canonicalize the SignedInfo, do the following:-
            // 1. Replace any CR-LF pairs with single LF char
            // 2. Add the xmlns attributes to the SignedInfo tag
            // 3. Convert the empty 'Method' elements to start-end tag pairs
            // 4. Use double-quotes (") around attribute values
            // 5. Do NOT change any other whitespace chars outside the tags
            // -- assumes all other c14n aspects are dealt with in the hard-coding

            // We can hard-code all of the above directly; well, almost...
            if (fIncludeXMLSchema)
            {
                strFirstLine = "<SignedInfo xmlns=\"http://www.w3.org/2000/09/xmldsig#\" xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\">";
            }
            else
            {
                strFirstLine = "<SignedInfo xmlns=\"http://www.w3.org/2000/09/xmldsig#\">";
            }

            strSignedInfoCanonic = strFirstLine 
                + chLf + "<CanonicalizationMethod Algorithm=\"http://www.w3.org/TR/2001/REC-xml-c14n-20010315\"></CanonicalizationMethod>" 
                + chLf + "<SignatureMethod Algorithm=\"http://www.w3.org/2000/09/xmldsig#rsa-sha1\"></SignatureMethod>" 
                + chLf + "<Reference URI=\"#" + strReference + "\">" 
                + chLf + "<Transforms>" 
                + chLf + "<Transform Algorithm=\"http://www.w3.org/TR/2001/REC-xml-c14n-20010315\"></Transform>" 
                + chLf + "</Transforms>" 
                + chLf + "<DigestMethod Algorithm=\"http://www.w3.org/2000/09/xmldsig#sha1\"></DigestMethod>" 
                + chLf + "<DigestValue>" + strDigestValue64 + "</DigestValue>" 
                + chLf + "</Reference>" 
                + chLf + "</SignedInfo>";

            if (ShowDebug)
            {
                Console.WriteLine(strSignedInfoCanonic);
            }
            strDigest = Hash_String_SHA1(strSignedInfoCanonic, false);
            return strDigest;

        }

        public static void Test_DigestSignedInfo()
        {
            string strComputed = null;
            string strCorrect = null;

            Console.WriteLine();
            Console.WriteLine("F60T33 Outer XML-Dsig:");
            strCorrect = "98B466FFE6A5E73B85962BC7300841C5F1693D3A";
            strComputed = MakeDigestValueOfSignedInfo("4OTWXyRl5fw3htjTyZXQtYEsC3E=", "SetDoc", true, false);
            Console.WriteLine("COMPUTED=" + strComputed);
            Console.WriteLine("CORRECT= " + strCorrect);

            Console.WriteLine("F60T33 Inner XML-Dsig:");
            strCorrect = "353CABFE369AAD9BEA21F5FA06CB367960FFB7D4";
            strComputed = MakeDigestValueOfSignedInfo("hlmQtu/AyjUjTDhM3852wvRCr8w=", "F60T33", false, false);
            Console.WriteLine("COMPUTED=" + strComputed);
            Console.WriteLine("CORRECT= " + strCorrect);

        }

        public static string XMLDSIG_VerifySigUsingRSAKeyValue(string strSig64, string strXmlKey)
        {
            // $GENERIC-FUNCTION$
            // INPUT:  strSig64  = <SignatureValue> in base64 excluding XML tags
            //         strXmlKey = <RSAKeyValue> in XMLSIG format including XML tags
            // OUTPUT: DigestValue in hex format
            int nRet = 0;
            byte[] abData = null;
            int nDataLen = 0;
            string strPublicKey = null;
            int nKeyLen = 0;
            byte[] abDigest = null;
            int nDigLen = 0;
            string result = "";

            Console.WriteLine("SigBase64=" + strSig64);
            // Convert XML key form to our internal format
            strPublicKey = Rsa.FromXMLString(strXmlKey, false);
            if (strPublicKey.Length == 0)
            {
                Console.WriteLine("ERROR: Unable to read XML key string");
                return result;
            }
            Console.WriteLine("Key length is " + Rsa.KeyBits(strPublicKey) + " bits");

            // Convert signatureValue to byte format
            abData = System.Convert.FromBase64String(strSig64);
            Console.WriteLine("SIGNATURE=" + Cnv.ToHex(abData));
            nDataLen = abData.Length;
            Console.WriteLine("Signature is " + nDataLen + " bytes long");
            // Verify the key - this should return 1
            nRet = Rsa.CheckKey(strPublicKey);
            Console.WriteLine("RSA_CheckKey returns " + nRet + " (expecting 1)");
            // Check the length
            nKeyLen = Rsa.KeyBytes(strPublicKey);
            Console.WriteLine("Key is " + nKeyLen + " bytes long");
            if (nKeyLen != nDataLen)
            {
                Console.WriteLine("ERROR: Key is the wrong length!");
                return result;
            }
            // Decrypt the signature
            abData = Rsa.RawPublic(abData, strPublicKey);
            if (abData.Length == 0)
            {
                Console.WriteLine("ERROR: " + General.LastError());
                return result;
            }
            Console.WriteLine("EMSA BLOCK=" + Cnv.ToHex(abData));

            // Extract digest from block
            abDigest = Rsa.DecodeDigestForSignature(abData);
            nDigLen = abDigest.Length;
            Console.WriteLine("RSA_DecodeMsg returns " + nDigLen + " (expecting 20)");
            if (nDigLen <= 0)
            {
                Console.WriteLine("ERROR: Cannot extract digest");
                return result;
            }

            // Display bytes as hex and base64
            Console.WriteLine("digest=" + Cnv.ToHex(abDigest));
            Console.WriteLine("base64=" + System.Convert.ToBase64String(abDigest));
            Console.WriteLine();
            // Return result
            return Cnv.ToHex(abDigest);

        }

        public static string XMLDSIG_VerifySigUsingCert(string strSig64, string strCert64)
        {
            // $GENERIC-FUNCTION$
            // INPUT:  strSig64  = <SignatureValue> content in base64 excluding tags
            //         strCert64 = <X509Certificate> content in base64 excluding tags
            // OUTPUT: digestValue in hex format
            byte[] abData = null;
            string strPublicKey = null;
            int nCheck = 0;
            int nDataLen = 0;
            int nKeyLen = 0;
            byte[] abDigest = null;
            string strQuery = null;
            string strOutput = null;
            string strXmlKey = null;
            string result = "";

            // Query the certificate for details
            strQuery = "subjectName";
            strOutput = X509.QueryCert(strCert64, strQuery);
            if (strOutput.Length == 0)
            {
                Console.WriteLine("ERROR: Error reading certificate: " + General.LastError());
                return result;
                // ERROR
            }
            Console.WriteLine(strQuery + "=" + strOutput);

            // Extract public key from X.509 certificate in internal string form
            strPublicKey = Rsa.GetPublicKeyFromCert(strCert64).ToString();
            Console.WriteLine("Chars in internal key = " + strPublicKey.Length);
            if (strPublicKey.Length == 0)
            {
                Console.WriteLine("ERROR: Error reading certificate key");
                return result;
                // ERROR
            }
            //Console.WriteLine("PUBLIC KEY (internal)=" + strPublicKey);

            // While we're here, display the public key in XML format
            strXmlKey = Rsa.ToXMLString(strPublicKey, 0);
            if (strXmlKey.Length > 0)
            {
                Console.WriteLine(strXmlKey);
            }
            else
            {
                Console.WriteLine("**Failed to create public key in XML");
            }

            // Convert signatureValue to byte format
            abData = System.Convert.FromBase64String(strSig64);
            Console.WriteLine("SIGNATURE=" + Cnv.ToHex(abData));
            nDataLen = abData.Length;
            Console.WriteLine("Signature is " + nDataLen + " bytes long");
            // Verify the key - this should return 1
            nCheck = Rsa.CheckKey(strPublicKey);
            Console.WriteLine("RSA_CheckKey returns " + nCheck + " (expecting 1)");
            // Check the length
            nKeyLen = Rsa.KeyBytes(strPublicKey);
            Console.WriteLine("Key is " + nKeyLen + " bytes long");
            if (nKeyLen != nDataLen)
            {
                Console.WriteLine("ERROR: Key is the wrong length!");
                return result;
            }
            // Decrypt the signature
            abData = Rsa.RawPublic(abData, strPublicKey);
            Console.WriteLine("EMSA BLOCK=" + Cnv.ToHex(abData));

            // Extract digest from block
            abDigest = Rsa.DecodeDigestForSignature(abData);
            Console.WriteLine("RSA_DecodeMsg returns " + abDigest.Length + " (expecting 20)");
            if (abDigest.Length == 0)
            {
                Console.WriteLine("ERROR: Cannot extract digest");
                return result;
            }

            // Display bytes as hex and base64
            Console.WriteLine("digest=" + Cnv.ToHex(abDigest));
            Console.WriteLine("base64=" + System.Convert.ToBase64String(abDigest));
            // Return digest in hex
            return Cnv.ToHex(abDigest);
        }

        public static void TestReadFRMA()
        {
            string strCert64 = null;
            string strSig64 = null;
            string strDigestHex = null;

            //<FRMA algoritmo="SHA1withRSA">g1AQX0sy8NJugX52k2hTJEZAE9Cuul6pqYBdFxj1N17umW7zG/hAavCALKByHzdYAfZ3LhGTXCai5zNxOo4lDQ==</FRMA>
            strSig64 = "g1AQX0sy8NJugX52k2hTJEZAE9Cuul6pqYBdFxj1N17umW7zG/hAavCALKByHzdYAfZ3LhGTXCai5zNxOo4lDQ==";

            // [2009-05-07] We have the certificate for the signer of this now...
            strCert64 = "-----BEGIN CERTIFICATE-----" + "\n" 
                + "MIICTzCCAfmgAwIBAwIBZDANBgkqhkiG9w0BAQQFADCBrzELMAkGA1UEBhMCQ0wx" 
                + "CzAJBgNVBAgTAkNTMQswCQYDVQQHEwJDczEnMCUGA1UEChMeU2VydmljaW8gZGUg" 
                + "SW1wdWVzdG9zIEludGVybm9zMRkwFwYDVQQLExBPZmljaW5hIEludGVybmV0MScw" 
                + "JQYDVQQDEx5TZXJ2aWNpbyBkZSBJbXB1ZXN0b3MgSW50ZXJub3MxGTAXBgkqhkiG" 
                + "9w0BCQEWCnNpaUBzaWkuY2wwHhcNMDMwNDI5MjAxNDA1WhcNMDQwNDIzMjAxNDA1" 
                + "WjCBrzELMAkGA1UEBhMCQ0wxCzAJBgNVBAgTAkNTMQswCQYDVQQHEwJDczEnMCUG" 
                + "A1UEChMeU2VydmljaW8gZGUgSW1wdWVzdG9zIEludGVybm9zMRkwFwYDVQQLExBP" 
                + "ZmljaW5hIEludGVybmV0MScwJQYDVQQDEx5TZXJ2aWNpbyBkZSBJbXB1ZXN0b3Mg" 
                + "SW50ZXJub3MxGTAXBgkqhkiG9w0BCQEWCnNpaUBzaWkuY2wwXDANBgkqhkiG9w0B" 
                + "AQEFAANLADBIAkEAyPvwDcshpVAApYVSLF3lKKc+DOFswDqx5ep95LKigRHjUvrv" 
                + "jct9UeNJq9SxBdzU9nz54TEVBYyfAVQpG4xxUwIDAQABMA0GCSqGSIb3DQEBBAUA" 
                + "A0EADvJX1C7hUFD2Eq9jNZpeJ/YBOZx1SBmAHSeXud6fTw98+AR4X3YDmzO9D4Kd" 
                + "hEFi3NK4anpjiPOKbA8fBWyyBA==" 
                + "-----END CERTIFICATE-----";

            strDigestHex = XMLDSIG_VerifySigUsingCert(strSig64, strCert64);

        }

        public static void MakeFRMAdigest()
        {
            // This should give the same digest value we obtained above.
            string strData = null;
            string strDigest = null;
            // Put <DA> data into a single string with no spaces between elements
            strData = "<DA><RE>97975000-5</RE><RS>RUT DE PRUEBA</RS><TD>33</TD><RNG><D>1</D><H>200</H></RNG><FA>2003-09-04</FA><RSAPK><M>0a4O6Kbx8Qj3K4iWSP4w7KneZYeJ+g/prihYtIEolKt3cykSxl1zO8vSXu397QhTmsX7SBEudTUx++2zDXBhZw==</M><E>Aw==</E></RSAPK><IDK>100</IDK></DA>";
            // Create an SHA-1 digest value in hex format
            //'strDigest = String(PKI_SHA1_CHARS, " ")
            strDigest = Hash.HexFromString(strData, HashAlgorithm.Sha1);
            Console.WriteLine("SHA1(DA)=" + strDigest);
            // Display in base64
            Console.WriteLine("SHA1(DA)=" + System.Convert.ToBase64String(Cnv.FromHex(strDigest)));
        }

        public static void TestReadFRMT()
        {
            string strXmlKey = null;
            string strSig64 = null;

            // <FRMT algoritmo="SHA1withRSA">GbmDcS9e/jVC2LsLIe1iRV12Bf6lxsILtbQiCkh6mbjckFCJ7fj/kakFTS06Jo8iS4HXvJj3oYZuey53Krniew==</FRMT>
            strSig64 = "GbmDcS9e/jVC2LsLIe1iRV12Bf6lxsILtbQiCkh6mbjckFCJ7fj/kakFTS06Jo8iS4HXvJj3oYZuey53Krniew==";

            // Form XML string of public key in proper XMLSIG format using <RSAPK> element in XML file
            // <RSAPK><M>0a4O6Kbx8Qj3K4iWSP4w7KneZYeJ+g/prihYtIEolKt3cykSxl1zO8vSXu397QhTmsX7SBEudTUx++2zDXBhZw==</M><E>Aw==</E></RSAPK>
            strXmlKey = "<RSAKeyValue><Modulus>0a4O6Kbx8Qj3K4iWSP4w7KneZYeJ+g/prihYtIEolKt3cykSxl1zO8vSXu397QhTmsX7SBEudTUx++2zDXBhZw==</Modulus>" 
                + "<Exponent>Aw==</Exponent></RSAKeyValue>";

            XMLDSIG_VerifySigUsingRSAKeyValue(strSig64, strXmlKey);

        }

        public static void TestF60T33OuterXmlSigByCert()
        {
            // THIS DOES NOT WORK! Because the X509 Certificate provided does not correspond to the key used to make the signature.
            string strSig64 = null;
            string strCert64 = null;

            strCert64 = "MIIEgjCCA+ugAwIBAgIEAQAApzANBgkqhkiG9w0BAQUFADCBtTELMAkGA1UEBhMCQ0wxHTAbBgNVBAgUFFJlZ2lvbiBNZXRyb3BvbGl0YW5hMREwDwYDVQQHFAhTYW50aWFnbzEUMBIGA1UEChQLRS1DRVJUQ0hJTEUxIDAeBgNVBAsUF0F1dG9yaWRhZCBDZXJ0aWZpY2Fkb3JhMRcwFQYDVQQDFA5FLUNFUlRDSElMRSBD" 
                + "QTEjMCEGCSqGSIb3DQEJARYUZW1haWxAZS1jZXJ0Y2hpbGUuY2wwHhcNMDMxMDAxMTg1ODE1WhcNMDQwOTMwMDAwMDAwWjCBuDELMAkGA1UEBhMCQ0wxFjAUBgNVBAgUDU1ldHJvcG9saXRhbmExETAPBgNVBAcUCFNhbnRpYWdvMScwJQYDVQQKFB5TZXJ2aWNpbyBkZSBJbXB1ZXN0b3MgSW50ZXJub3MxDzANBgNVBAsU" 
                + "BlBpc28gNDEjMCEGA1UEAxQaV2lsaWJhbGRvIEdvbnphbGV6IENhYnJlcmExHzAdBgkqhkiG9w0BCQEWEHdnb256YWxlekBzaWkuY2wwgZ8wDQYJKoZIhvcNAQEBBQADgY0AMIGJAoGBALxZlVh1xr9sKQIBDF/6Va+lsHQSG5AAmCWvtNTIOXN3E9EQCy7pOPHrDg6EusvoHyesZSKJbc0TnIFXZp78q7mbdHijzKqvMmyv" 
                + "wbdP7KK8LQfwf84W4v9O8MJeUHlbJGlo5nFACrPAeTtONbHaReyzeMDv2EganNEDJc9c+UNfAgMBAAGjggGYMIIBlDAjBgNVHREEHDAaoBgGCCsGAQQBwQEBoAwWCjA3ODgwNDQyLTQwCQYDVR0TBAIwADA8BgNVHR8ENTAzMDGgL6AthitodHRwOi8vY3JsLmUtY2VydGNoaWxlLmNsL2UtY2VydGNoaWxlY2EuY3JsMCMG" 
                + "A1UdEgQcMBqgGAYIKwYBBAHBAQKgDBYKOTY5MjgxODAtNTAfBgNVHSMEGDAWgBTgKP3S4GBPs0brGsz1CJEHcjodCDCB0AYDVR0gBIHIMIHFMIHCBggrBgEEAcNSBTCBtTAvBggrBgEFBQcCARYjaHR0cDovL3d3dy5lLWNlcnRjaGlsZS5jbC8yMDAwL0NQUy8wgYEGCCsGAQUFBwICMHUac0VsIHRpdHVsYXIgaGEgc2lk" 
                + "byB2YWxpZG8gZW4gZm9ybWEgcHJlc2VuY2lhbCwgcXVlZGFuZG8gZWwgQ2VydGlmaWNhZG8gcGFyYSB1c28gdHJpYnV0YXJpbywgcGFnb3MsIGNvbWVyY2lvIHkgb3Ryb3MwCwYDVR0PBAQDAgTwMA0GCSqGSIb3DQEBBQUAA4GBABMfCyJF0mNXcov8iEWvjGFyyPTsXwvsYbbkOJ41wjaGOFMCInb4WY0ngM8BsDV22bGM" 
                + "s8oLyX7rVy16bGA8Z7WDUtYhoOM7mqXw/Hrpqjh3JgAf8zqdzBdH/q6mAbdvq/yb04JHKWPC7fMFuBoeyVWAnhmuMZfReWQiMUEHGGIW";
            strSig64 = "sBnr8Yq14vVAcrN/pKLD/BrqUFczKMW3y1t3JOrdsxhhq6IxvS13SgyMXbIN/T9ciRaFgNabs3pi732XhcpeiSmD1ktzbRctEbSIszYkFJY49k0eB+TVzq3eVaQr4INrymfuOnWj78BZcwKuXvDy4iAcx6/TBbAAkPFwMP9ql2s=";

            XMLDSIG_VerifySigUsingCert(strSig64, strCert64);

        }

        public static void TestF60T33OuterXmlSigByRSA()
        {
            // THIS WORKS...
            string strSig64 = null;
            string strXmlKey = null;

            strXmlKey = "<RSAKeyValue><Modulus>" 
                + "tNEknkb1kHiD1OOAWlLKkcH/UP5UGa6V6MYso++JB+vYMg2OXFROAF7G8BNFFPQx" 
                + "iuS/7y1azZljN2xq+bW3bAou1bW2ij7fxSXWTJYFZMAyndbLyGHM1e3nVmwpgEpx" 
                + "BHhZzPvwLb55st1wceuKjs2Ontb13J33sUb7bbJMWh0=</Modulus>" 
                + "<Exponent>AQAB</Exponent></RSAKeyValue>";
            strSig64 = "sBnr8Yq14vVAcrN/pKLD/BrqUFczKMW3y1t3JOrdsxhhq6IxvS13SgyMXbIN/T9ciRaFgNabs3pi732XhcpeiSmD1ktzbRctEbSIszYkFJY49k0eB+TVzq3eVaQr4INrymfuOnWj78BZcwKuXvDy4iAcx6/TBbAAkPFwMP9ql2s=";

            XMLDSIG_VerifySigUsingRSAKeyValue(strSig64, strXmlKey);

        }

        public static void TestF60T33InnerXmlSigByRSA()
        {
            // THIS WORKS...
            string strSig64 = null;
            string strXmlKey = null;

            strXmlKey = "<RSAKeyValue><Modulus>" 
                + "tNEknkb1kHiD1OOAWlLKkcH/UP5UGa6V6MYso++JB+vYMg2OXFROAF7G8BNFFPQx" 
                + "iuS/7y1azZljN2xq+bW3bAou1bW2ij7fxSXWTJYFZMAyndbLyGHM1e3nVmwpgEpx" 
                + "BHhZzPvwLb55st1wceuKjs2Ontb13J33sUb7bbJMWh0=</Modulus>" 
                + "<Exponent>AQAB</Exponent></RSAKeyValue>";
            strSig64 = "JG1Ig0pvSIH85kIKGRZUjkyX6CNaY08Y94j4UegTgDe8+wl61GzqjdR1rfOK9BGn93AMOo6aiAgolW0k/XklNVtM/ZzpNNS3d/fYVa1q509mAMSXbelxSM3bjoa7H6Wzd/mV1PpQ8zK5gw7mgMMP4IKxHyS92G81GEguSmzcQmA=";

            XMLDSIG_VerifySigUsingRSAKeyValue(strSig64, strXmlKey);

        }

        public static void TestF60T33FRMTSigByRSA()
        {
            string strSig64 = null;
            string strXmlKey = null;

            strXmlKey = "<RSAKeyValue><Modulus>" 
                + "0a4O6Kbx8Qj3K4iWSP4w7KneZYeJ+g/prihYtIEolKt3cykSxl1zO8vSXu397QhTmsX7SBEudTUx++2zDXBhZw==</Modulus>" 
                + "<Exponent>Aw==</Exponent></RSAKeyValue>";
            strSig64 = "GbmDcS9e/jVC2LsLIe1iRV12Bf6lxsILtbQiCkh6mbjckFCJ7fj/kakFTS06Jo8iS4HXvJj3oYZuey53Krniew==";

            XMLDSIG_VerifySigUsingRSAKeyValue(strSig64, strXmlKey);

        }


        public static void Main()
        {
            Console.WriteLine("DOING ALL TESTS...");

            Console.WriteLine("\n Read_SmallerKeys() \n");
            Read_SmallerKeys();

            Console.WriteLine("\n MakeFRMTdigest() \n");
            MakeFRMTdigest();

            Console.WriteLine("\n SignDDtoMakeFRMTsig() \n");
            SignDDtoMakeFRMTsig();

            Console.WriteLine("\n CheckExampleCertAndRSAKey() \n");
            CheckExampleCertAndRSAKey();

            Console.WriteLine("\n CheckManualCertAndRSAKey() \n");
            CheckManualCertAndRSAKey();

            Console.WriteLine("\n Test_Make_Hash_of_File() \n");
            Test_Make_Hash_of_File();

            Console.WriteLine("\n Test_DigestSignedInfo() \n");
            Test_DigestSignedInfo();

            Console.WriteLine("\n TestReadFRMA() \n");
            TestReadFRMA();

            Console.WriteLine("\n MakeFRMAdigest() \n");
            MakeFRMAdigest();

            Console.WriteLine("\n TestReadFRMT() \n");
            TestReadFRMT();

            Console.WriteLine("\n TestF60T33OuterXmlSigByCert() \n");
            TestF60T33OuterXmlSigByCert();

            Console.WriteLine("\n TestF60T33OuterXmlSigByRSA() \n");
            TestF60T33OuterXmlSigByRSA();

            Console.WriteLine("\n TestF60T33InnerXmlSigByRSA() \n");
            TestF60T33InnerXmlSigByRSA();

            Console.WriteLine("\n TestF60T33FRMTSigByRSA() \n");
            TestF60T33FRMTSigByRSA();

        }
    }
}
