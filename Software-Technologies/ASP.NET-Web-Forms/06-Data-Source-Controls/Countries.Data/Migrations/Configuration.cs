namespace Countries.Data.Migrations
{
    using Countries.Models;
    using Countries.Models.ToDo;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    public sealed class Configuration : DbMigrationsConfiguration<Countries.Data.CountriesDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(CountriesDbContext db)
        {
            if (db.Continents.Count() <= 0)
            {
                db.Continents.Add(new Continent
                {
                    Name = "Europe"
                });

                db.Continents.Add(new Continent
                {
                    Name = "North America"
                });

                db.SaveChanges();

                db.Countries.Add(new Country
                {
                    Name = "Bulgaria",
                    Language = "Bulgarian",
                    Population = 7500000,
                    ContinentId = db.Continents.FirstOrDefault(c => c.Name == "Europe").Id
                });

                db.Countries.Add(new Country
                {
                    Name = "France",
                    Language = "French",
                    Population = 80000000,
                    ContinentId = db.Continents.FirstOrDefault(c => c.Name == "Europe").Id
                });

                db.Countries.Add(new Country
                {
                    Name = "Italy",
                    Language = "Italian",
                    Population = 8500000,
                    ContinentId = db.Continents.FirstOrDefault(c => c.Name == "Europe").Id
                });

                db.Countries.Add(new Country
                {
                    Name = "USA",
                    Language = "English",
                    Population = 31800000,
                    ContinentId = db.Continents.FirstOrDefault(c => c.Name == "North America").Id
                });

                db.Countries.Add(new Country
                {
                    Name = "Mexico",
                    Language = "Mexican",
                    Population = 14000000,
                    ContinentId = db.Continents.FirstOrDefault(c => c.Name == "North America").Id
                });

                db.Countries.Add(new Country
                {
                    Name = "Canada",
                    Language = "Canadian",
                    Population = 14000000,
                    ContinentId = db.Continents.FirstOrDefault(c => c.Name == "North America").Id
                });

                db.SaveChanges();

                db.Towns.Add(new Town
                {
                    Name = "Sofia",
                    Population = 2000000,
                    CountryId = db.Countries.FirstOrDefault(c => c.Name == "Bulgaria").Id
                });

                db.Towns.Add(new Town
                {
                    Name = "Plovdiv",
                    Population = 500000,
                    CountryId = db.Countries.FirstOrDefault(c => c.Name == "Bulgaria").Id
                });

                db.Towns.Add(new Town
                {
                    Name = "Varna",
                    Population = 500000,
                    CountryId = db.Countries.FirstOrDefault(c => c.Name == "Bulgaria").Id
                });

                db.Towns.Add(new Town
                {
                    Name = "New York",
                    Population = 12500000,
                    CountryId = db.Countries.FirstOrDefault(c => c.Name == "USA").Id
                });

                db.Towns.Add(new Town
                {
                    Name = "Las Vegas",
                    Population = 12500000,
                    CountryId = db.Countries.FirstOrDefault(c => c.Name == "USA").Id
                });

                db.Towns.Add(new Town
                {
                    Name = "Los Angeles",
                    Population = 15000000,
                    CountryId = db.Countries.FirstOrDefault(c => c.Name == "USA").Id
                });

                db.SaveChanges();

                db.Categories.Add(new Category
                    {
                        Name = "School"
                    });

                db.Categories.Add(new Category
                {
                    Name = "Fun"
                });

                db.SaveChanges();

                db.ToDos.Add(new ToDoTask
                    {
                        Title = "Homework",
                        Body = "Do homework",
                        DateModified = DateTime.Now,
                        Category = db.Categories.FirstOrDefault(c => c.Name == "School")
                    });

                db.ToDos.Add(new ToDoTask
                {
                    Title = "More Homework",
                    Body = "Do more homework",
                    DateModified = DateTime.Now,
                    Category = db.Categories.FirstOrDefault(c => c.Name == "School")
                });

                db.ToDos.Add(new ToDoTask
                {
                    Title = "Party",
                    Body = "Party like a rockstar",
                    DateModified = DateTime.Now,
                    Category = db.Categories.FirstOrDefault(c => c.Name == "Fun")
                });

                db.SaveChanges();
            }
        }
    }
}
