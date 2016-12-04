using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _8._1.Browser_Type
{
    public partial class BrowserType : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.LiteralBorwserInfo.Text += "Browser Type: " + Request.Browser.Type + "<br/>";
            this.LiteralBorwserInfo.Text += "User Agent: " + Request.UserAgent + "<br/>";
            this.LiteralBorwserInfo.Text += "User IP Address: " + Request.UserHostAddress + "<br/>"; //TODO
        }
    }
}