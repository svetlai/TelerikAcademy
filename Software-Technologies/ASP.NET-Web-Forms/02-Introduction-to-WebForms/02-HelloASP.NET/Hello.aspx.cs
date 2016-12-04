using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _2.Hello_ASP.NET
{
    public partial class Hello : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.LabelHello.Text = "Hello, ASP.NET from C#!";
            var location = Assembly.GetExecutingAssembly().Location;
            this.LabelAssembly.Text = location;
        }
    }
}