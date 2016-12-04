namespace _3._3.Display_Text
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;

    public partial class DisplayText : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ButtonSubmit_Click(object sender, EventArgs e)
        {
            string originalText = this.TextBoxOriginal.Text;
            this.TextBoxCopy.Text = originalText;
            this.LabelCopy.Text = Server.HtmlEncode(originalText);
        }
    }
}