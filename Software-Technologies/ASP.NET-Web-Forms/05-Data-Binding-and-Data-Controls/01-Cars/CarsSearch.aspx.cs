namespace _5._1.Cars
{
    using _5._1.Cars.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

    public partial class CarsSearch : System.Web.UI.Page
    {
        private List<Producer> producers;
        private List<Extra> extras;
        private string[] engines;

        protected void Page_Load(object sender, EventArgs e)
        {
            this.FillCarData();

            if (!Page.IsPostBack)
            {
                
                this.DropDownListProducers.DataSource = producers;
                this.DropDownListProducers.DataBind();

                this.CheckBoxListExtras.DataSource = extras;
                this.CheckBoxListExtras.DataBind();

                this.RadioButtonListEngines.DataSource = engines;
                this.RadioButtonListEngines.DataBind();
                
                Page.DataBind();
            }
        }

        protected void DropDownListProducers_SelectedIndexChanged(object sender, EventArgs e)
        {
            var carIndex = this.DropDownListProducers.SelectedIndex;
            this.DropDownListModels.DataSource = producers[carIndex].CarModels;
            this.DropDownListModels.DataBind();
        }

        protected void ButtonSubmit_Click(object sender, EventArgs e)
        {
            var sb = new StringBuilder();
            sb.Append(this.DropDownListProducers.SelectedItem.Text + "<br />");
            sb.Append(this.DropDownListModels.SelectedItem.Text + "<br />");
            for (int i = 0; i < this.CheckBoxListExtras.Items.Count; i++)
			{
			    if (this.CheckBoxListExtras.Items[i].Selected == true)
                {
                    sb.Append(this.CheckBoxListExtras.Items[i] + ";");
                }
			}
            sb.Append("<br />");
            sb.Append(this.RadioButtonListEngines.SelectedItem.Text);
            this.LiteralSearchInfo.Text = sb.ToString();
        }

        private void FillCarData()
        {
            var bmwModels = new HashSet<CarModel>()
            {
                new CarModel("M3"),
                new CarModel("M5")
            };

            var mazdaModels = new HashSet<CarModel>()
            {
                new CarModel("Versia"),
                new CarModel("Axela")
            };

            var renaultModels = new HashSet<CarModel>()
            {
                new CarModel("Twingo")
            };

            this.producers = new List<Producer>()
            {
                new Producer("BMW", bmwModels),
                new Producer("Mazda", mazdaModels),
                new Producer("Renault", renaultModels)
            };

            this.extras = new List<Extra>()
            {
                new Extra("ABS"),
                new Extra("Power Windows"),
                new Extra("A/C")
            };

            this.engines = new string[] 
            {
                "diesel",
                "gasoline"
            };

        }
    }
}