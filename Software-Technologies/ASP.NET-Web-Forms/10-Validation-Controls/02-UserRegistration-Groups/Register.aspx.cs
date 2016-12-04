using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _10._1.User_Registration
{
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ButtonSubmit_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                this.LiteralSuccess.Text = "The form is valid.";
            }
        }

        protected void ButtonSubmitLogon_Click(object sender, EventArgs e)
        {
            this.Page.Validate("ValidationGroupLogon");
            if (Page.IsValid)
            {
                this.LiteralSuccess.Text = "Login info is valid.";
            }
        }

        protected void ButtonSubmitPersonal_Click(object sender, EventArgs e)
        {
            this.Page.Validate("ValidationGroupPersonal");
            if (Page.IsValid)
            {
                this.LiteralSuccess.Text = "Personal info is valid.";
            }

        }

        protected void ButtonSubmitAddress_Click(object sender, EventArgs e)
        {
            this.Page.Validate("ValidationGroupAddress");
            if (Page.IsValid)
            {
                this.LiteralSuccess.Text = "Address info is valid.";
            }
        }

        protected void CheckBoxRequired_ServerValidate(object sender, ServerValidateEventArgs e)
        {
            e.IsValid = CheckBoxAccept.Checked;
        }

        protected void ButtonLogon_Click(object sender, EventArgs e)
        {

        }
    }
}