namespace BugLogger.Services.Tests.Fakes
{
    using BugLogger.Data.Repositories;
    using BugLogger.Model;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class FakeRepository<T> : IRepository<T> where T : class
    {
        public IList<T> Entities { get; set; }
        
        public IQueryable<T> All()
        {
            return this.Entities.AsQueryable();
        }

        public void Add(T entity)
        {
            this.Entities.Add(entity);
        }

        public T Find(object id)
        {
            throw new NotImplementedException();
        }

        public void Update(T entity)
        {
            throw new NotImplementedException();
        }

        public T Delete(T entity)
        {
            throw new NotImplementedException();
        }

        public T Delete(object id)
        {
            throw new NotImplementedException();
        }

        public void SaveChanges()
        {
            this.IsSaveCalled = true;
        }

        public bool IsSaveCalled { get; set; }
    }
}
