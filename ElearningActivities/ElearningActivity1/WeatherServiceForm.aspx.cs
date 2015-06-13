using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using System.Net;

namespace GlobalWeatherService2._0
{
    public partial class WeatherServiceForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            XmlDocument wsResponseXmlDoc = new XmlDocument();

            //http://api.worldweatheronline.com/free/v2/weather.ashx?q=china&format=xml&num_of_days=5&key=x35ahuadjhmdp
            //id=jipx(spacetime0)
            UriBuilder url = new UriBuilder();
            url.Scheme = "http";// Same as "http://"

            url.Host = "api.worldweatheronline.com";
            url.Path = "free/v2/weather.ashx";
            url.Query = "q=china&format=xml&num_of_days=5&key=4723d12aeedb03cc80eb0bbfa2dde";

            //Make a HTTP request to the global weather web service
            wsResponseXmlDoc = MakeRequest(url.ToString());
            //display the XML response 
            String xmlString = wsResponseXmlDoc.InnerXml;
            Response.ContentType = "text/xml";
            Response.Write(xmlString);

            // Save the document to a file and auto-indent the output.
            XmlTextWriter writer = new XmlTextWriter(Server.MapPath("xmlweather.xml"), null);
            writer.Formatting = Formatting.Indented;
            wsResponseXmlDoc.Save(writer);

        }
        public static XmlDocument MakeRequest(string requestUrl)
        {
            try
            {
                HttpWebRequest request = WebRequest.Create(requestUrl) as HttpWebRequest;
                //set timeout to 15s
                request.Timeout = 15 * 1000;
                request.KeepAlive = false;
                HttpWebResponse response = request.GetResponse() as HttpWebResponse;
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load(response.GetResponseStream());
                return (xmlDoc);
            }
            catch (Exception e)
            {
                return null;
            }
        }
    }
}