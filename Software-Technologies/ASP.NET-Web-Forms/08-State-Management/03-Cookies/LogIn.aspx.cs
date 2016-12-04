using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _8._3.Cookies
{
    public partial class LogIn : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ButtonLogIn_Click(object sender, EventArgs e)
        {
            HttpCookie cookie = new HttpCookie("UserName", "You are logged in!");
            cookie.Expires = DateTime.Now.AddMinutes(1);

            Response.Cookies.Add(cookie);

            Response.Redirect("AuthorizedOnly.aspx");
        }
    }
}