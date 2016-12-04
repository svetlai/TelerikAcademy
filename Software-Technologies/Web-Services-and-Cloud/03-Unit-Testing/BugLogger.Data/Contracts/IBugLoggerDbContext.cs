namespace BugLogger.Data.Contracts
{
    using BugLogger.Model;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;

    public interface IBugLoggerDbContext
    {
        IDbSet<Bug> Bugs { get; set; }

        void SaveChanges();

        IDbSet<TEntity> Set<TEntity>() where TEntity : class;

        DbEntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;
    }
}
