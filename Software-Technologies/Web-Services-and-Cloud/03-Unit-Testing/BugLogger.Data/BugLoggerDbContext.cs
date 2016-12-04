namespace BugLogger.Data
{
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;

    using BugLogger.Model;
    using BugLogger.Data.Contracts;
    using BugLogger.Data.Migrations;

    public class BugLoggerDbContext : DbContext, IBugLoggerDbContext
    {
        public BugLoggerDbContext()
            : base("BugLoggerConnection")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<BugLoggerDbContext, Configuration>());
        }

        public virtual IDbSet<Bug> Bugs { get; set; }

        public new void SaveChanges()
        {
            base.SaveChanges();
        }

        public IDbSet<TEntity> Set<TEntity>() where TEntity : class
        {
            return base.Set<TEntity>();
        }

        //DbEntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class
        //{
        //    return 
        //}
    }
}
