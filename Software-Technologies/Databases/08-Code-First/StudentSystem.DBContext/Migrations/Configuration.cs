namespace StudentSystem.DBContext.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    using StudentSystem.Model;

    //NOTE: Enabling migrations: Tools>Library Packaage Manager>Package Manager Console
    //Enable-Migrations for project StudentSystem.DBCotext
    //Set AutomaticMigrationsEnabled to true
    //Database.SetInitializer(new MigrateDatabaseToLatestVersion<StudentSystemDBContext, Configuration>());
    public sealed class Configuration : DbMigrationsConfiguration<StudentSystemDBContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
            this.ContextKey = "StudentSystem.DBContext.StudentSystemDBContext";
        }

        /// <summary>
        ///  This method will be called after migrating to the latest version.
        /// </summary>
        /// <param name="context"></param>

        protected override void Seed(StudentSystemDBContext context)
        {
            //context.Students.AddOrUpdate(
            //    s => s.FirstName,
            //    new Student
            //    {
            //        FirstName = "Pesho",
            //        LastName = "Peshov"
            //    });

            //context.SaveChanges();
        }
    }
}
