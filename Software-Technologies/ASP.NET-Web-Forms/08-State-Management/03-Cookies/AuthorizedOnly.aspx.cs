using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _8._3.Cookies
{
    public partial class AuthorizedOnly : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            HttpCookie cookie = Request.Cookies["UserName"];
            if (cookie != null)
            {
                string text = "Cookie was sent by the Web browser.";
                Response.Write(text);

                LabelLoggedIn.Text = cookie.Value;
            }
            else
            {
                Response.Redirect("Login.aspx");
            }
        }
    }
}