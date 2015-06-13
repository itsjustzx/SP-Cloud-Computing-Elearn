using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ElearningActivity2
{
    public partial class ServerTime : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Cache.SetExpires(DateTime.Now.AddSeconds(10));
            Response.Cache.SetCacheability(HttpCacheability.Public);
            Response.Cache.SetValidUntilExpires(true);

            //The next few lines change the content type to plain text, get current time, and...
            Response.ContentType = "text/plain";
            Response.Write("The time on the server is: " + DateTime.Now.ToString());
            Response.Write("<br>");
            Response.Write("Hi " + Request.QueryString["myName"]);
        }
    }
}