namespace MusicSystem.Model
{
    using System.Collections.Generic;

    public class Song
    {
        public Song()
        {
        }

        public int SongId { get; set; }

        public string Title { get; set; }

        public int Year { get; set; }

        public string Genre { get; set; }

        public int? AlbumId { get; set; }

        public virtual Album Album { get; set; }

        public int? ArtistId { get; set; }

        public virtual Album Artist { get; set; }
    }
}
