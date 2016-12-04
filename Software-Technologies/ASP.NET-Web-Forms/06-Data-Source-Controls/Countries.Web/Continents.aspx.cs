using Countries.Data;
using Countries.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Countries.Web
{
    public partial class Continents : System.Web.UI.Page
    {
        private const int MAX_FILE_SIZE = 10485760;

        private string[] imageFormats = new string[3] { "image/jpeg", "image/jpg", "image/png" };

        private ICountriesData data;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var dbContext = new CountriesDbContext();
                data = new CountriesData(dbContext);

                var allContinents = this.data.Continents.All().ToList();

                this.ListBoxContinents.DataSource = allContinents;
                this.ListBoxContinents.DataBind();
            }
        }

        protected void ListBoxContinents_SelectedIndexChanged(object sender, EventArgs e)
        {
            var dbContext = new CountriesDbContext();
            data = new CountriesData(dbContext);

            var continentIndex = int.Parse(this.ListBoxContinents.SelectedValue);

            var countries = this.data.Countries
                .All()
                .Where(c => c.ContinentId == continentIndex)
                .ToList();

            this.GridViewCountries.DataSource = countries;
            this.GridViewCountries.DataBind();
        }

        protected void GridViewCountries_SelectedIndexChanged(object sender, EventArgs e)
        {
            var dbContext = new CountriesDbContext();
            data = new CountriesData(dbContext);

            int countryIndex = int.Parse(this.GridViewCountries.SelectedDataKey.Value.ToString());

            var towns = this.data.Towns
                .All()
                .Where(t => t.CountryId == countryIndex)
                .ToList();

            this.PanelFileUpload.Visible = true;
            this.ListViewTowns.DataSource = towns;
            this.ListViewTowns.DataBind();
        }

        protected void GridViewCountries_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            this.GridViewCountries.PageIndex = e.NewPageIndex;
            ListBoxContinents_SelectedIndexChanged(null, null);
        }

        protected void ListViewTowns_ItemEditing(object sender, ListViewEditEventArgs e)
        {
            this.ListViewTowns.EditIndex = e.NewEditIndex;
            GridViewCountries_SelectedIndexChanged(null, null);
        }

        protected void ListViewTowns_ItemCanceling(object sender, ListViewCancelEventArgs e)
        {
            this.ListViewTowns.EditIndex = -1;
            GridViewCountries_SelectedIndexChanged(null, null);
        }

        protected void ListViewTowns_ItemUpdating(object sender, ListViewUpdateEventArgs e)
        {
            var listView = (ListView)sender;
            int townId = int.Parse(listView.DataKeys[e.ItemIndex].Value.ToString());

            var editedRow = listView.Items[e.ItemIndex];
            var tbTownName = editedRow.FindControl("TownNameTextBox") as TextBox;
            var tbTownPopulation = editedRow.FindControl("TownPopulationTextBox") as TextBox;

            var dbContext = new CountriesDbContext();
            data = new CountriesData(dbContext);

            var currentTown = this.data.Towns.Find(townId);
            currentTown.Name = tbTownName.Text;
            currentTown.Population = long.Parse(tbTownPopulation.Text);

            data.SaveChanges();

            listView.EditIndex = -1;
            GridViewCountries_SelectedIndexChanged(null, null);
        }

        protected void ListViewTowns_ItemDeleting(object sender, ListViewDeleteEventArgs e)
        {
            var listView = (ListView)sender;
            int townId = int.Parse(listView.DataKeys[e.ItemIndex].Value.ToString());

            var editedRow = listView.Items[e.ItemIndex];

            var dbContext = new CountriesDbContext();
            data = new CountriesData(dbContext);

            var currentTown = this.data.Towns.Delete(townId);

            data.SaveChanges();

            listView.EditIndex = -1;
            GridViewCountries_SelectedIndexChanged(null, null);
        }

        protected void GridViewCountries_RowEditing(object sender, GridViewEditEventArgs e)
        {
            this.GridViewCountries.EditIndex = e.NewEditIndex;
            ListBoxContinents_SelectedIndexChanged(null, null);
        }

        protected void GridViewCountries_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            var gridView = (GridView)sender;
            int countryId = int.Parse(gridView.DataKeys[e.RowIndex].Value.ToString());

            var editedRow = gridView.Rows[e.RowIndex];
            var tbCountryName = editedRow.FindControl("TextBoxCountryName") as TextBox;
            var tbCountryLanguage = editedRow.FindControl("TextBoxCountryLanguage") as TextBox;
            var tbCountryPopulation = editedRow.FindControl("TextBoxCountryPopulation") as TextBox;

            var dbContext = new CountriesDbContext();
            data = new CountriesData(dbContext);

            var currentCountry = this.data.Countries.Find(countryId);
            currentCountry.Name = tbCountryName.Text;
            currentCountry.Language = tbCountryLanguage.Text;
            currentCountry.Population = long.Parse(tbCountryPopulation.Text);

            data.SaveChanges();

            gridView.EditIndex = -1;
            ListBoxContinents_SelectedIndexChanged(null, null);
        }

        protected void GridViewCountries_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            var gridView = (GridView)sender;
            int countryId = int.Parse(gridView.DataKeys[e.RowIndex].Value.ToString());

            var editedRow = gridView.Rows[e.RowIndex];

            var dbContext = new CountriesDbContext();
            data = new CountriesData(dbContext);

            var currentCountry = this.data.Countries.Delete(countryId);

            data.SaveChanges();

            gridView.EditIndex = -1;
            ListBoxContinents_SelectedIndexChanged(null, null);
        }

        protected void GridViewCountries_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            this.GridViewCountries.EditIndex = -1;
            ListBoxContinents_SelectedIndexChanged(null, null);
        }

        protected void ListViewTowns_PagePropertiesChanging(object sender, PagePropertiesChangingEventArgs e)
        {
            var townsPager = this.ListViewTowns.FindControl("DataPagerTowns") as DataPager;
            townsPager.SetPageProperties(e.StartRowIndex, e.MaximumRows, false);
            GridViewCountries_SelectedIndexChanged(null, null);
        }

        protected void ListViewTowns_ItemInserting(object sender, ListViewInsertEventArgs e)
        {
            var name = e.Values["Name"].ToString();
            var population = e.Values["Population"].ToString();

            var listView = (ListView)sender;

            var dbContext = new CountriesDbContext();
            data = new CountriesData(dbContext);

            var newTown = new Town
            {
                Name = name,
                Population = long.Parse(population),
                CountryId = int.Parse(this.GridViewCountries.SelectedValue.ToString())
            };

            this.data.Towns.Add(newTown);
            data.SaveChanges();

            listView.EditIndex = -1;
            GridViewCountries_SelectedIndexChanged(null, null);
        }

        protected void ButtonInsertTown_Click(object sender, EventArgs e)
        {
            this.ListViewTowns.InsertItemPosition = InsertItemPosition.FirstItem;
            GridViewCountries_SelectedIndexChanged(null, null);
        }

        protected void SubmitFileUpload_Click(object sender, EventArgs e)
        {
            string filePathAndName = string.Empty;

            try
            {
                filePathAndName = FileUploadControl.Upload();
            }
            catch (InvalidOperationException ex)
            {
                throw new InvalidOperationException("Invalid operation.");
            }

            if (!string.IsNullOrEmpty(filePathAndName))
            {
                var countryId = int.Parse(this.GridViewCountries.SelectedValue.ToString());

                var newImage = new Countries.Models.Image
                {
                    Path = filePathAndName
                };

                var dbContext = new CountriesDbContext();
                data = new CountriesData(dbContext);

                this.data.Countries.All().FirstOrDefault(c => c.Id == countryId).Images.Add(newImage);
                this.data.SaveChanges();

                this.GridViewCountries.EditIndex = -1;
                ListBoxContinents_SelectedIndexChanged(null, null);
            }
        }

        protected void GridViewCountries_RowCreated(object sender, GridViewRowEventArgs e)
        {
            //this.GridViewCountries.ShowFooter = true;
            //ListBoxContinents_SelectedIndexChanged(null, null);
        }

        protected void GridViewCountries_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Insert")
            {
                var gridView = (GridView)sender;

                var dbContext = new CountriesDbContext();
                data = new CountriesData(dbContext);

                var tbCountryName = this.GridViewCountries.FindControl("TextBoxInsertCountryName") as TextBox;
                var tbCountryLanguage = this.GridViewCountries.FindControl("TextBoxInsertCountryLanguage") as TextBox;
                var tbCountryPopulation = this.GridViewCountries.FindControl("TextBoxCountryPopulation") as TextBox;

                var newCountry = new Country
                {
                    Name = tbCountryName.Text,
                    Language = tbCountryLanguage.Text,
                    Population = long.Parse(tbCountryPopulation.Text),
                    ContinentId = int.Parse(this.ListBoxContinents.SelectedValue.ToString())
                };

                this.data.Countries.Add(newCountry);
                data.SaveChanges();

                gridView.EditIndex = -1;
                ListBoxContinents_SelectedIndexChanged(null, null);
            }
        }
    }
}