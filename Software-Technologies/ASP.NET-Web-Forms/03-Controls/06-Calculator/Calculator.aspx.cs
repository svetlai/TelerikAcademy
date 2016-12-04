using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _3._6.Calculator
{
    public partial class Calculator : System.Web.UI.Page
    {
        private const string ErrorMessage = "Error!";

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void ButtonNumber_Click(object sender, EventArgs e)
        {
            if (this.Operator.Value != string.Empty)
            {
                this.TextBoxResult.Text = string.Empty;
            }

            this.TextBoxResult.Text += (sender as Button).Text;
        }

        protected void ButtonClear_Click(object sender, EventArgs e)
        {
            this.TextBoxResult.Text = string.Empty;
            this.NumberStorage.Value = string.Empty;
        }

        protected void ButtonOperator_Click(object sender, EventArgs e)
        {
            this.Operator.Value = (sender as Button).Text;
            this.NumberStorage.Value = this.TextBoxResult.Text;
            //this.TextBoxResult.Text = (sender as Button).Text;
        }

        protected void ButtonSqrt_Click(object sender, EventArgs e)
        {
            this.Operator.Value = "sqrt";
            this.NumberStorage.Value = this.TextBoxResult.Text;
            //this.TextBoxResult.Text = (sender as Button).Text;
        }

        protected void ButtonEquals_Click(object sender, EventArgs e)
        {
            this.Calculate();
            this.Operator.Value = "";
        }

        private void Calculate()
        {
            decimal display = 0;
            decimal storage = 0;

            if (this.TextBoxResult.Text != string.Empty && this.TextBoxResult.Text != ErrorMessage)
            {
                display = decimal.Parse(this.TextBoxResult.Text);
            }

            if (this.NumberStorage.Value != string.Empty)
            {
                storage = decimal.Parse(this.NumberStorage.Value);
            }

            try
            {
                decimal result = GetResult(display, storage);
                this.NumberStorage.Value = result.ToString();
                this.TextBoxResult.Text = Math.Round(result, 14).ToString();
            }
            catch (Exception)
            {
                this.TextBoxResult.Text = ErrorMessage;
                this.NumberStorage.Value = string.Empty;
            }
        }

        private decimal GetResult(decimal display, decimal storage)
        {
            switch (this.Operator.Value)
            {
                case "":
                    return display;
                case "+":
                    return storage + display;
                case "-":
                    return storage - display;
                case "*":
                    return storage * display;
                case "/":
                    return storage / display;
                case "sqrt":
                    return (decimal)Math.Sqrt((double)display);
                default:
                    throw new InvalidOperationException();
            }
        }
    }
}