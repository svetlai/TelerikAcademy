using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _3.Life_Cycle
{
    public partial class Life_Cycle : System.Web.UI.Page
    {
        protected void Page_PreInit(object sender, EventArgs e)
        {
            //Response.Write("Page_PreInit invoked" + "<br/>");
            this.LabelEvents.Text += "Page_PreInit invoked" + "<br/>";
        }

        protected void Page_Init(object sender, EventArgs e)
        {
            //Response.Write("Page_Init invoked" + "<br/>");
            this.LabelEvents.Text += "Page_Init invoked" + "<br/>";
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            //Response.Write("Page_Load invoked" + "<br/>");
            this.LabelEvents.Text += "Page_Load invoked" + "<br/>";
        }

        protected void Page_PreRender(object sender, EventArgs e)
        {
            //Response.Write("Page_PreRender invoked" + "<br/>");
            this.LabelEvents.Text += "Page_PreRender invoked" + "<br/>";
        }

        protected void Page_Unload(object sender, EventArgs e)
        {
            // Response is unavailable at page unload
            // Response.Write("Page_Unload invoked" + "<br/>");
            //this.LabelEvents.Text += "Page_Unload invoked" + "<br/>";
        }

        protected void ButtonOK_Init(object sender, EventArgs e)
        {
            //Response.Write("ButtonOK_Init invoked" + "<br/>");
            this.LabelEvents.Text += "ButtonOK_Init invoked" + "<br/>";
        }

        protected void ButtonOK_Load(object sender, EventArgs e)
        {
            //Response.Write("ButtonOK_Load invoked" + "<br/>");
            this.LabelEvents.Text += "ButtonOK_Load invoked" + "<br/>";
        }

        protected void ButtonOK_Click(object sender, EventArgs e)
        {
            //Response.Write("ButtonOK_Click invoked" + "<br/>");
            this.LabelEvents.Text += "ButtonOK_Click invoked" + "<br/>";
        }

        protected void ButtonOK_PreRender(object sender, EventArgs e)
        {
            //Response.Write("ButtonOK_PreRender invoked" + "<br/>");
            this.LabelEvents.Text += "ButtonOK_PreRender invoked" + "<br/>";
        }
        protected void ButtonOK_Unload(object sender, EventArgs e)
        {
            // Response is unavailable at control unload
            // Response.Write("ButtonOK_Unload invoked" + "<br/>");
            this.LabelEvents.Text += "ButtonOK_Unload invoked" + "<br/>";
        }

    }
}