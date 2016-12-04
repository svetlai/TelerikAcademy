using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _3._1.Random_Number_Generator___HTML
{
    public partial class NumberGenerator : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ButtonSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                int min = int.Parse(this.TextMin.Value);
                int max = int.Parse(this.TextMax.Value);
                Random rand = new Random();
                int randomNumber = rand.Next(min, max);
                this.SpanResult.InnerText = randomNumber.ToString();
            }
            catch
            {
                throw new ArgumentException("Invalid input. Please enter two integer numbers.");
            }


        }
    }
}