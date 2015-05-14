namespace NewsSite.Web
{
    using System;
    using System.Linq;
    using System.Web.UI.WebControls;

    using NewsSite.Web.Data;
    using NewsSite.Web.Models;

    public partial class News : System.Web.UI.Page
    {
        private NewsSiteDbContext db;

        public News()
        {
            this.db = new NewsSiteDbContext();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        public IQueryable<Article> ListViewNews_GetData()
        {
            return this.db.Articles
                .OrderByDescending(a => a.Likes.Count)
                .Take(3);
        }

        // OnItemDataBound - used to apply custom display logic
        public void ListViewNews_DisplayNews(object sender, ListViewItemEventArgs e)
        {
            if (e.Item.ItemType == ListViewItemType.DataItem)
            {
                var label = e.Item.FindControl("LabelContent") as Label;
                var content = label.Text;

                if (!string.IsNullOrEmpty(content) && content.Length > 300)
                {
                    content = content.Substring(0, 300) + "...";
                }

                label.Text = content;
            }
        }

        public IQueryable<Category> ListViewCategories_GetData()
        {
            return this.db.Categories
                .OrderBy(c => c.Name);
        }
    }
}