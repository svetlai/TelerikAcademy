using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _2._1.WebForms_Sumator
{
    public partial class Sumator : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ButtonSum_Click(object sender, EventArgs e)
        {
            double firstNumber = double.Parse(this.TextBoxFirstNumber.Text);
            double secondNumber = double.Parse(this.TextBoxSecondNumber.Text);
            double result = firstNumber + secondNumber;
            this.LiteralResult.Text = result.ToString();
        }
    }
}