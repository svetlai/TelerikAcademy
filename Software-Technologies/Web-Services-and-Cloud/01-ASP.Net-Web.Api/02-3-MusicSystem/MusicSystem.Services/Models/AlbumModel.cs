namespace MusicSystem.Services.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Linq.Expressions;

    using MusicSystem.Model;
    using System.Collections.Generic;

    public class AlbumModel
    {
        public static Expression<Func<Album, AlbumModel>> FromAlbum
        {
            get
            {
                return a => new AlbumModel
                {
                    AlbumId = a.AlbumId,
                    Title = a.Title,
                    Year = a.Year,
                    Producer = a.Producer,
                    ArtistIds = a.Artists.Select(x => x.ArtistId).ToList(),
                    SongIds = a.Songs.Select(x => x.SongId).ToList()
                };
            }
        }

        public int AlbumId { get; set; }

        [Required]
        [MinLength(3)]
        [MaxLength(20)]
        public string Title { get; set; }

        public int Year { get; set; }

        public string Producer { get; set; }

        public IList<int> ArtistIds { get; set; }

        public IList<int> SongIds { get; set; }
    }
}