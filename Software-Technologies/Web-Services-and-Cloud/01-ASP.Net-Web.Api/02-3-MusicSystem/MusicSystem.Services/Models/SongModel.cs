namespace MusicSystem.Services.Models
{
    using System;
    using System.Linq.Expressions;

    using MusicSystem.Model;

    public class SongModel
    {
        public static Expression<Func<Song, SongModel>> FromSong
        {
            get
            {
                return s => new SongModel
                {
                    SongId = s.SongId,
                    Title = s.Title,
                    Year = s.Year,
                    Genre = s.Genre,
                    AlbumId = s.AlbumId,
                    ArtistId = s.ArtistId
                };
            }
        }
        public int SongId { get; set; }

        public string Title { get; set; }

        public int Year { get; set; }

        public string Genre { get; set; }

        public int? AlbumId { get; set; }

        public int? ArtistId { get; set; }
    }
}