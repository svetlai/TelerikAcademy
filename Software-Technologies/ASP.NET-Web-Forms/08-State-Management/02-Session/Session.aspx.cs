using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _8._2.Session
{
    public partial class Session : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["AllInputs"] == null)
            {
                Session.Add("AllInputs", new List<string>());
            }
        }

        protected void ButtonSession_Click(object sender, EventArgs e)
        {           
            var currentTextLine = this.TextBoxSession.Text;
            var allInputs = Session["AllInputs"] as List<string>;
            allInputs.Add(currentTextLine);

            foreach (var input in allInputs)
            {
                this.LabelSessionOutput.Text += input + "<br />";
            }
        }
    }
}