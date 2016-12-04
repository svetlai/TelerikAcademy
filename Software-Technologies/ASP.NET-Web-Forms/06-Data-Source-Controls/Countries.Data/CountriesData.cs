namespace Countries.Data
{
    using Countries.Data.Repositories;
    using Countries.Models;
    using Countries.Models.ToDo;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;

    public class CountriesData : ICountriesData
    {
        private DbContext db;
        private IDictionary<Type, object> repositories;

        public CountriesData()
            : this(new CountriesDbContext())
        {
        }

        public CountriesData(DbContext db)
        {
            this.db = db;
            this.repositories = new Dictionary<Type, object>();
        }

        public IRepository<Continent> Continents
        {
            get
            {
                return this.GetRepository<Continent>();
            }
        }

        public IRepository<Country> Countries
        {
            get
            {
                return this.GetRepository<Country>();
            }
        }

        public IRepository<Town> Towns
        {
            get
            {
                return this.GetRepository<Town>();
            }
        }

        public IRepository<Image> Images
        {
            get
            {
                return this.GetRepository<Image>();
            }
        }

        public IRepository<ToDoTask> ToDos
        {
            get
            {
                return this.GetRepository<ToDoTask>();
            }
        }

        public IRepository<Category> Categories
        {
            get
            {
                return this.GetRepository<Category>();
            }
        }

        public void SaveChanges()
        {
            this.db.SaveChanges();
        }

        private IRepository<T> GetRepository<T>() where T : class
        {
            var typeOfRepository = typeof(T);
            if (!this.repositories.ContainsKey(typeOfRepository))
            {
                var type = typeof(Repository<T>);
                var newRepository = Activator.CreateInstance(type, this.db);
                
                this.repositories.Add(typeOfRepository, newRepository);
            }

            return (IRepository<T>)this.repositories[typeOfRepository];
        }
    }
}
