namespace Countries.Data
{
    using Countries.Data.Migrations;
    using Countries.Models;
    using Countries.Models.ToDo;
    using System.Data.Entity;

    public class CountriesDbContext : DbContext
    {
        public CountriesDbContext()
            : base("name=CountriesDbContext")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<CountriesDbContext, Configuration>());
        }

        public virtual IDbSet<Continent> Continents { get; set; }

        public virtual IDbSet<Country> Countries { get; set; }

        public virtual IDbSet<Town> Towns { get; set; }

        public virtual IDbSet<Image> Images { get; set; }

        public virtual IDbSet<ToDoTask> ToDos { get; set; }

        public virtual IDbSet<Category> Categories { get; set; }
    }
}
