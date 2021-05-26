using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net;
using System.Xml;
using System.Xml.Linq;


namespace attach.utils
{
    class PAttachment
    {
        public void XmlZaprosCreate ()
        {
            string fileName = "250200_11111.xml";
            XmlDocument xmlDoc = new XmlDocument();
            WebRequest request = WebRequest.Create("http://192.168.1.210:8080/mis/rest/queries?method=getQueryXmlResult&query=Select%20pa.personalData%20FROM%20PatientAttachment%20pa%20WHERE%20pa.id=181");
            WebResponse response = request.GetResponse();

            using (Stream stream = response.GetResponseStream())
            {
                xmlDoc.Load(stream);
            }
            xmlDoc.Save(fileName);
        }

        void GetElemValue (XDocument docName, string valElement) // вовод первого значение под тего valElement из docName
        {
            var v= docName.Descendants(valElement).FirstOrDefault().Value;
        }
    }
}
