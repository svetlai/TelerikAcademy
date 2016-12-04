namespace MusicSystem.Data.Contracts
{
    using MusicSystem.Model;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;

    public interface IMusicSystemDbContext
    {
        IDbSet<Artist> Artists { get; set; }

        IDbSet<Album> Albums { get; set; }

        IDbSet<Song> Songs { get; set; }

        void SaveChanges();

        IDbSet<TEntity> Set<TEntity>() where TEntity : class;

        DbEntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;
    }
}
