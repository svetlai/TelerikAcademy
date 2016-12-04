namespace Chat.Migrations
{
    using Chat.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Chat.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
            ContextKey = "Chat.Models.ApplicationDbContext";
        }

        protected override void Seed(ApplicationDbContext context)
        {
            var db = new ApplicationDbContext();

            if (db.Messages.Any())
            {
                return;
            }
            
            ApplicationUser user = new ApplicationUser() 
            { 
                UserName = "Anonymous",
                FirstName = "Guest",
                LastName = "Guest"
            };

            db.Users.Add(user);
            db.SaveChanges();

            db.Messages.Add(new Message 
            {
                Text = "Hello",
                Author = user,
                AuthorName = user.FirstName + ' ' + user.LastName
            });

            db.SaveChanges();
        }
    }
}
