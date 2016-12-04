namespace MusicSystem.Data
{
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;

    using MusicSystem.Model;
    using MusicSystem.Data.Contracts;
    using MusicSystem.Data.Migrations;

    public class MusicSystemDbContext : DbContext, IMusicSystemDbContext
    {
        public MusicSystemDbContext()
            : base("MusicSystemConnection")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<MusicSystemDbContext, Configuration>());
        }
        public virtual IDbSet<Artist> Artists { get; set; }

        public virtual IDbSet<Album> Albums { get; set; }

        public virtual IDbSet<Song> Songs { get; set; }

        public new void SaveChanges()
        {
            base.SaveChanges();
        }

        public IDbSet<TEntity> Set<TEntity>() where TEntity : class
        {
            return base.Set<TEntity>();
        }

        //DbEntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;
    }
}
