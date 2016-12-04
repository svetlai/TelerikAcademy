using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _8._4.ViewState_less
{
    public partial class Index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (ViewState["values"] == null)
            {
                ViewState.Add("values", new List<string>());
            }
        }

        protected void ButtonSubmit_Click(object sender, EventArgs e)
        {
            var list = ViewState["values"] as List<string>;
            list.Add(TextBoxInput.Text);
            LabelOutput.Text = "";
            foreach (var item in list)
            {
                LabelOutput.Text += "<br/>" + item;
            }

            TextBoxInput.Text = "";
        }
    }
}