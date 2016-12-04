namespace MusicSystem.Data.Repositories
{
    using System.Data.Entity;

    using MusicSystem.Data.Contracts;

    public class Repository<T> : IRepository<T> where T : class
    {
        private IMusicSystemDbContext db;
        private IDbSet<T> set;

        public Repository()
            : this(new MusicSystemDbContext())
        {
        }

        public Repository(IMusicSystemDbContext context)
        {
            this.db = context;
            this.set = context.Set<T>();
        }

        public System.Linq.IQueryable<T> All()
        {
            return this.set;
        }

        public T Find(object id)
        {
            return this.set.Find(id);
        }

        public void Add(T entity)
        {
            this.ChangeEntityState(entity, EntityState.Added);
        }

        public void Update(T entity)
        {
            this.ChangeEntityState(entity, EntityState.Modified);
        }

        public void Delete(T entity)
        {
            this.ChangeEntityState(entity, EntityState.Deleted);
        }

        public void Detach(T entity)
        {
            this.ChangeEntityState(entity, EntityState.Detached);
        }

        public void SaveChanges()
        {
            this.db.SaveChanges();
        }

        private void ChangeEntityState(T entity, EntityState state)
        {
            var entry = this.db.Entry(entity);

            if (entry.State == EntityState.Detached)
            {
                this.set.Attach(entity);
            }

            entry.State = state;
        }
    }
}
