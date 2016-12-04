using Countries.Data;
using Countries.Models.ToDo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Countries.Web
{
    public partial class ToDo : System.Web.UI.Page
    {
        private ICountriesData data;

        protected void Page_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        protected void ListViewToDos_ItemEditing(object sender, ListViewEditEventArgs e)
        {
            this.ListViewToDos.EditIndex = e.NewEditIndex;
            LoadData();
        }

        protected void ListViewToDos_ItemDeleting(object sender, ListViewDeleteEventArgs e)
        {
            var listView = (ListView)sender;
            int toDoId = int.Parse(listView.DataKeys[e.ItemIndex].Value.ToString());

            var editedRow = listView.Items[e.ItemIndex];

            var dbContext = new CountriesDbContext();
            data = new CountriesData(dbContext);

            var currentToDo = this.data.ToDos.Delete(toDoId);

            data.SaveChanges();

            listView.EditIndex = -1;
            LoadData();
            Response.Redirect("~/ToDo");
        }

        protected void ListViewToDos_ItemCanceling(object sender, ListViewCancelEventArgs e)
        {
            this.ListViewToDos.EditIndex = -1;
            LoadData();
        }

        protected void ListViewToDos_ItemUpdating(object sender, ListViewUpdateEventArgs e)
        {
            var listView = (ListView)sender;
            int toDoId = int.Parse(listView.DataKeys[e.ItemIndex].Value.ToString());

            var editedRow = listView.Items[e.ItemIndex];
            var tbToDoTitle = editedRow.FindControl("ToDoTitleTextBox") as TextBox;
            var tbToDoBody = editedRow.FindControl("ToDoBodyTextBox") as TextBox;
            var tbToDoCategory = editedRow.FindControl("ToDoCategoryTextBox") as TextBox;
           
            var dbContext = new CountriesDbContext();
            data = new CountriesData(dbContext);

            var currentToDo = this.data.ToDos.Find(toDoId);
            currentToDo.Title = tbToDoTitle.Text;
            currentToDo.Body = tbToDoBody.Text;
            currentToDo.DateModified = DateTime.Now;
            currentToDo.Category.Name = tbToDoCategory.Text;

            data.SaveChanges();

            listView.EditIndex = -1;
            LoadData();
        }

        private void LoadData()
        {
            if (!IsPostBack)
            {
                var dbContext = new CountriesDbContext();
                data = new CountriesData(dbContext);

                var allToDos = this.data.ToDos.All().ToList();

                this.ListViewToDos.DataSource = allToDos;
                this.ListViewToDos.DataBind();
            }
        }

        protected void ListViewToDos_ItemInserting(object sender, ListViewInsertEventArgs e)
        {
            var title = e.Values["Title"].ToString();
            var body = e.Values["Body"].ToString();
            var category = e.Values["Category"].ToString();

            var listView = (ListView)sender;

            var dbContext = new CountriesDbContext();
            data = new CountriesData(dbContext);

            var catExists = this.data.Categories.All().FirstOrDefault(c => c.Name == category);

            if(catExists == null)
            {
                var newCat = new Category
                {
                    Name = category
                };

            this.data.Categories.Add(newCat);
            this.data.SaveChanges();
            }

            var newToDo = new ToDoTask
            {
                Title = title,
                Body = body,
                DateModified = DateTime.Now,
                CategoryId = this.data.Categories.All().FirstOrDefault(c => c.Name == category).Id
            };

            this.data.ToDos.Add(newToDo);
            this.data.SaveChanges();

            listView.EditIndex = -1;
            LoadData();
        }

        protected void ButtonInsertToDo_Click(object sender, EventArgs e)
        {
            this.ListViewToDos.InsertItemPosition = InsertItemPosition.FirstItem;
            LoadData();
        }
    }
}