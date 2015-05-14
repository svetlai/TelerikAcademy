namespace NewsSite.Web.Admin
{
    using System;
    using System.Linq;
    using System.Linq.Dynamic;
    using System.Web.ModelBinding;
    using System.Web.UI.WebControls;

    using Error_Handler_Control;

    using NewsSite.Web.Data;
    using NewsSite.Web.Models;

    public partial class Articles : System.Web.UI.Page
    {
        private NewsSiteDbContext db;

        public Articles()
        {
            this.db = new NewsSiteDbContext();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        // The return type can be changed to IEnumerable, however to support
        // paging and sorting, the following parameters must be added:
        //     int maximumRows
        //     int startRowIndex
        //     out int totalRowCount
        //     string sortByExpression
        public IQueryable<Article> ListViewNews_GetData(string sortByExpression)
        {
            var articles = this.db.Articles;

            // using System.Linq.Dynamic
            if (!string.IsNullOrEmpty(sortByExpression))
            {
                return articles.OrderBy(sortByExpression);
            }
            else
            {
                return articles
                .OrderByDescending(a => a.DateCreated);
            }
        }

        // OnItemDataBound - used to apply custom display logic
        public void ListViewNews_DisplayNews(object sender, ListViewItemEventArgs e)
        {
            var listView = sender as ListView;

            if (e.Item.ItemType == ListViewItemType.DataItem && listView.EditIndex < 0)
            {
                var label = e.Item.FindControl("LabelContent") as Label;
                var content = label.Text;

                if (!string.IsNullOrEmpty(content) && content.Length > 300)
                {
                    label.Text = content.Substring(0, 300) + "...";
                }
            }
        }

        // The id parameter name should match the DataKeyNames value set on the control
        public void ListViewNews_UpdateItem(int id)
        {
            Article item = db.Articles.FirstOrDefault(a => a.Id == id);
            
            // Load the item here, e.g. item = MyDataLayer.Find(id);
            if (item == null)
            {
                // The item wasn't found
                ModelState.AddModelError("", String.Format("Item with id {0} was not found", id));
                ErrorSuccessNotifier.AddErrorMessage("Cannot find article with such id.");
                return;
            }

            TryUpdateModel(item);

            if (ModelState.IsValid)
            {
                // Save changes here, e.g. MyDataLayer.SaveChanges();
                ErrorSuccessNotifier.AddSuccessMessage("Article updated successfully.");
                this.db.SaveChanges();
                Response.Redirect("~/Admin/Articles");
            }
            else
            {
                ErrorSuccessNotifier.AddErrorMessage("Cannot update article. Make sure all data is valid.");
            }
        }

        // The id parameter name should match the DataKeyNames value set on the control
        public void ListViewNews_DeleteItem(int id)
        {
            var article = this.db.Articles.FirstOrDefault(c => c.Id == id);
            if (article == null)
            {
                // The item wasn't found
                ModelState.AddModelError("", String.Format("Item with id {0} was not found", id));
                return;
            }

            this.db.Articles.Remove(article);
            this.db.SaveChanges();

            ErrorSuccessNotifier.AddSuccessMessage("Article deleted successfully.");
            Response.Redirect("~/Admin/Articles");
        }

        protected void LinkButtonInsert_Click(object sender, EventArgs e)
        {
            this.ListViewNews.InsertItemPosition = InsertItemPosition.FirstItem;
        }

        public void ListViewNews_InsertItem()
        {
            var article = new Article();
            string authorName = this.Context.User.Identity.Name;

            article.Author = this.db.Users.FirstOrDefault(u => u.UserName == authorName);
            article.DateCreated = DateTime.Now;

            TryUpdateModel(article);

            if (ModelState.IsValid)
            {
                // Save changes here
                this.db.Articles.Add(article);
                this.db.SaveChanges();

                ErrorSuccessNotifier.AddSuccessMessage("Article added successfully.");
                Response.Redirect("~/Admin/Articles");
            }
            else
            {
                ErrorSuccessNotifier.AddErrorMessage("Cannot update article. Make sure all data is valid.");
            }
        }

        protected void CustomValidatorEditTitleLength_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (args.Value.Length <= 100)
            {
                args.IsValid = true;
            }
            else
            {
                args.IsValid = false;
            }
        }

        // The return type can be changed to IEnumerable, however to support
        // paging and sorting, the following parameters must be added:
        //     int maximumRows
        //     int startRowIndex
        //     out int totalRowCount
        //     string sortByExpression
        public IQueryable<Category> DropDownListCategory_GetData()
        {
            return this.db.Categories;
        }
    }
}