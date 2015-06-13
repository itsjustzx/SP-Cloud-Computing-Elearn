using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;

namespace ElearningActivity1
{
    public partial class bongTranslator : System.Web.UI.Page
    {
        public class AdmAccessToken
        {

            public string access_token { get; set; }

            public string token_type { get; set; }

            public string expires_in { get; set; }

            public string scope { get; set; }
        }
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            //retrieve the clientId and clientsecret from web.config
            string clientId = ConfigurationManager.AppSettings["ClientId"].ToString();
            string clientSecret = ConfigurationManager.AppSettings["ClientSecret"].ToString();

            String strTranslatorAccessURI = "https://datamarket.accesscontrol.windows.net/v2/OAuth2-13";

            String strRequestDetails = string.Format("grant_type=client_credentials&client_id={0}&client_secret={1}&scope=http://api.microsofttranslator.com", HttpUtility.UrlEncode(clientId), HttpUtility.UrlEncode(clientSecret));

            WebRequest webRequest = WebRequest.Create(strTranslatorAccessURI);
            webRequest.ContentType = "application/x-www-form-urlencoded";
            webRequest.Method = "POST";
            byte[] bytes = System.Text.Encoding.ASCII.GetBytes(strRequestDetails);

            webRequest.ContentLength = bytes.Length;

            using (System.IO.Stream outputStream = webRequest.GetRequestStream())
            {
                outputStream.Write(bytes, 0, bytes.Length);
            }

            //send request to get authentication token
            WebResponse webResponse = webRequest.GetResponse();
            DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(AdmAccessToken));

            //get deserialized obj from JSON stream
            AdmAccessToken token = (AdmAccessToken)serializer.ReadObject(webResponse.GetResponseStream());

            //send request to translation service
            string headerValue = "Bearer " + token.access_token;

            string txtToTranslate = TextBox1.Text;

            string uri = "http://api.microsofttranslator.com/v2/Http.svc/Translate?text=" + System.Web.HttpUtility.UrlEncode(txtToTranslate) + "&from=en&to=zh-CHS";

            WebRequest translationWebRequest = WebRequest.Create(uri);

            translationWebRequest.Headers.Add("Authorization", headerValue);
            WebResponse response = null;

            //get the response from bing
            response = translationWebRequest.GetResponse();

            Stream stream = response.GetResponseStream();

            Encoding encode = Encoding.GetEncoding("utf-8");

            StreamReader translatedStream = new StreamReader(stream, encode);

            XmlDocument xTranslation = new XmlDocument();

            xTranslation.LoadXml(translatedStream.ReadToEnd());

            //display it
            lbl1.Text = "Your Translation is: " + xTranslation.InnerText;

        }

    }
}