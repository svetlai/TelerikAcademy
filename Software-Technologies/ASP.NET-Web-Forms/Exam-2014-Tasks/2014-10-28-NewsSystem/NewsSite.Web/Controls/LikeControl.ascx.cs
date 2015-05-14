namespace NewsSite.Web.Controls
{
    using System;
    using System.Linq;

    using Error_Handler_Control;

    using NewsSite.Web.Data;
    using NewsSite.Web.Models;

    public partial class Like : System.Web.UI.UserControl
    {
        private NewsSiteDbContext db;

        public Like()
        {
            this.db = new NewsSiteDbContext();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            var currentArticle = this.GetCurrentArticle();
            this.CalculateLikeValue(currentArticle);
        }

        protected void ButtonVoteUp_Click(object sender, EventArgs e)
        {
            if (this.Context.User.Identity.IsAuthenticated)
            {
                string currentUserId = this.GetCurrentUserId();
                var currentArticle = this.GetCurrentArticle();

                if (currentArticle != null)
                {
                    bool hasVoted = this.HasVoted(currentArticle, currentUserId);

                    if (hasVoted)
                    {
                        ErrorSuccessNotifier.AddWarningMessage("You cannot vote twice on one article.");
                    }
                    else
                    {
                        var like = new NewsSite.Web.Models.Like
                        {
                            Value = 1,
                            UserId = currentUserId
                        };

                        currentArticle.Likes.Add(like);
                        this.db.SaveChanges();
                        this.CalculateLikeValue(currentArticle);
                    }
                }
                else
                {
                    Response.Redirect("~/");
                }
            }
        }

        protected void ButtonVoteDown_Click(object sender, EventArgs e)
        {
            if (this.Context.User.Identity.IsAuthenticated)
            {
                string currentUserId = this.GetCurrentUserId();
                var currentArticle = this.GetCurrentArticle();

                if (currentArticle != null)
                {
                    bool hasVoted = this.HasVoted(currentArticle, currentUserId);

                    if (hasVoted)
                    {
                        ErrorSuccessNotifier.AddWarningMessage("You cannot vote twice on one article.");
                    }
                    else
                    {
                        var like = new NewsSite.Web.Models.Like
                        {
                            Value = -1,
                            UserId = currentUserId
                        };

                        currentArticle.Likes.Add(like);
                        this.db.SaveChanges();
                        this.CalculateLikeValue(currentArticle);
                    }
                }
                else
                {
                    Response.Redirect("~/");
                }
            }
        }

        private Article GetCurrentArticle()
        {
            // get id from url
            var idStr = Request.QueryString["id"];

            if (idStr == null)
            {
                Response.Redirect("~/");
            }

            int id = int.Parse(idStr);

            var currentArticle = this.db.Articles
                .FirstOrDefault(a => a.Id == id);

            return currentArticle;
        }

        private string GetCurrentUserId()
        {
            var currentUserName = this.Context.User.Identity.Name;
            return this.db.Users.FirstOrDefault(u => u.UserName == currentUserName).Id;
        }

        private bool HasVoted(Article article, string userId)
        {
            return article.Likes.FirstOrDefault(l => l.UserId == userId) != null;
        }

        private void CalculateLikeValue(Article article)
        {
            var totalValue = 0;

            foreach (var like in article.Likes)
            {
                totalValue += like.Value;
            }

            this.LabelLike.Text = totalValue.ToString();
        }
    }
}