namespace BugLogger.Data
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;

    using BugLogger.Data.Contracts;
    using BugLogger.Data.Repositories;
    using BugLogger.Model;

    public class BugLoggerData : IBugLoggerData
    {
        private DbContext db;
        private IDictionary<Type, object> repositories;

        public BugLoggerData()
            : this(new BugLoggerDbContext())
        {
        }

        public BugLoggerData(DbContext db)
        {
            this.db = db;
            this.repositories = new Dictionary<Type, object>();
        }

        public IRepository<Bug> Bugs
        {
            get
            {
                return this.GetRepository<Bug>();
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
