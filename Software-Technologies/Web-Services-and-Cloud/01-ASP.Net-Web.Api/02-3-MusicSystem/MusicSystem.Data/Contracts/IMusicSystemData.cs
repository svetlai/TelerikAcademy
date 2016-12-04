namespace MusicSystem.Data.Contracts
{
    using MusicSystem.Model;

    public interface IMusicSystemData
    {
        IRepository<Artist> Artists { get; }

        IRepository<Album> Albums { get; }

        IRepository<Song> Songs { get; }

        void SaveChanges();
    }
}
