namespace NewsSite.Web
{
    using System;
    using System.Linq;
    using System.Web.ModelBinding;

    using NewsSite.Web.Data;
    using NewsSite.Web.Models;

    public partial class ArticleDetails : System.Web.UI.Page
    {
        private NewsSiteDbContext db;

        public ArticleDetails()
        {
            this.db = new NewsSiteDbContext();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Context.User.Identity.IsAuthenticated)
            {
                var likesPanel = this.PanelLikeControl;
                likesPanel.Visible = true;
            }
        }

        // TODO: add ViewModels
        public Article FormViewArticleDetails_GetData([QueryString("Id")]int? id)
        {
            if (id == null)
            {
                Response.Redirect("~/");
            }

            return this.db.Articles.FirstOrDefault(a => a.Id == id);
        }
    }
}