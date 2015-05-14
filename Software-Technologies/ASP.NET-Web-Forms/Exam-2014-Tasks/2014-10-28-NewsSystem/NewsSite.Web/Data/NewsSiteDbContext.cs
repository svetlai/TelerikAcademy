namespace NewsSite.Web.Data
{
    using System.Data.Entity;

    using Microsoft.AspNet.Identity.EntityFramework;

    using NewsSite.Web.Migrations;
    using NewsSite.Web.Models;

    public class NewsSiteDbContext : IdentityDbContext<User>
    {
        public NewsSiteDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<NewsSiteDbContext, Configuration>());
        }

        public static NewsSiteDbContext Create()
        {
            return new NewsSiteDbContext();
        }

        public IDbSet<Article> Articles { get; set; }

        public IDbSet<Category> Categories { get; set; }

        public IDbSet<Like> Likes { get; set; }
    }
}