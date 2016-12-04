namespace Countries.Data
{
    using Countries.Data.Repositories;
    using Countries.Models;
    using Countries.Models.ToDo;

    public interface ICountriesData
    {
        IRepository<Continent> Continents { get; }

        IRepository<Country> Countries { get; }

        IRepository<Town> Towns { get; }

        IRepository<Image> Images { get; }

        IRepository<ToDoTask> ToDos { get; }

        IRepository<Category> Categories { get; }

        void SaveChanges();
    }
}
