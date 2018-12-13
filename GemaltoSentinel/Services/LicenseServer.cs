using GemaltoSentinel.Entities;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Xml;

namespace GemaltoSentinel.Services
{
    public static class LicenseServer
    {
        public static List<LicenseDetails> GetLicenses(string serverName, string serverPort, string keyIndex, string keySerial)
        {
            List<LicenseDetails> licenseDetailsList = new List<LicenseDetails>();

            //request this url to generate the XML file
            string urlHTML = string.Format("http://{0}:{1}/licenseinfo.html?{2}?{3}", serverName, serverPort, keyIndex, keySerial);
            //The XML will contain the used licenses for the specified key
            string urlXML = string.Format("http://{0}:{1}/licenseinfo.xml", serverName, serverPort);

            GetResult(urlHTML);

            string result = GetResult(urlXML);
            int start = result.IndexOf("<LicenseInfo>");
            if (start != -1)
            {
                XmlDocument xmlDocument = new XmlDocument();
                xmlDocument.LoadXml(result.Substring(start, result.Length - start));
                foreach (XmlNode xmlNode in xmlDocument.SelectNodes(@"LicenseInfo / LicenseDetails"))
                {
                    LicenseDetails licenseDetails = new LicenseDetails();
                    licenseDetails.ClientIPAddress = xmlNode["ClientIPAddress"].InnerText;
                    licenseDetails.ClientUserName = xmlNode["ClientUserName"].InnerText;
                    licenseDetails.LicenseID = xmlNode["LicenseID"].InnerText;
                    licenseDetails.ClientLogTime = xmlNode["ClientLogTime"].InnerText;
                    licenseDetails.ClientProcessID = xmlNode["ClientProcessID"].InnerText;
                    licenseDetailsList.Add(licenseDetails);
                }
            }
            return licenseDetailsList;
        }

        private static string GetResult(string url)
        {
            string result = "";
            WebRequest webRequest = WebRequest.Create(url);
            if (webRequest != null)
            {
                WebResponse webResponse = webRequest.GetResponse();
                if (webResponse != null)
                {
                    using (Stream stream = webResponse.GetResponseStream())
                    {
                        using (StreamReader streamReader = new StreamReader(stream))
                        {
                            result = streamReader.ReadToEnd();
                        }
                    }
                }
            }
            return result;
        }
    }
}
