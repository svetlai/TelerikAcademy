namespace BugLogger.Services.Tests.Fakes
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;

    using BugLogger.Data.Contracts;
    using BugLogger.Data.Repositories;
    using BugLogger.Model;
    using BugLogger.Services.Models;

    public class FakeUoW : IBugLoggerData
    {
        private DbContext db;
        private IDictionary<Type, object> repositories;

        public IRepository<Bug> Bugs
        {
            get
            {
                return this.GetRepository<Bug>();
            }
        }

        public IRepository<BugModel> BugModel
        {
            get 
            { 
                return this.GetRepository<BugModel>(); 
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
                var type = typeof(FakeRepository<T>);
                var newRepository = Activator.CreateInstance(type, this.db);

                this.repositories.Add(typeOfRepository, newRepository);
            }

            return (IRepository<T>)this.repositories[typeOfRepository];
        }
    }
}
