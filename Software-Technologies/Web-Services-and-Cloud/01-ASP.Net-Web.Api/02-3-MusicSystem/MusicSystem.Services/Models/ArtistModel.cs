namespace MusicSystem.Services.Models
{
    using System;
    using System.Linq;
    using System.Linq.Expressions;

    using MusicSystem.Model;
    using System.ComponentModel.DataAnnotations;
    using System.Collections.Generic;

    public class ArtistModel
    {
        public static Expression<Func<Artist, ArtistModel>> FromArtist
        {
            get
            {
                return a => new ArtistModel
                {
                    ArtistId = a.ArtistId,
                    Name = a.Name,
                    DateOfBirth = a.DateOfBirth,
                    AlbumIds = a.Albums.Select(x => x.AlbumId).ToList(),
                    SongIds = a.Songs.Select(x => x.SongId).ToList()
                };
            }
        }

        public int ArtistId { get; set; }

        [Required]
        [MinLength(3)]
        [MaxLength(10)]
        public string Name { get; set; }

        public DateTime DateOfBirth { get; set; }

        public IList<int> AlbumIds { get; set; }

        public IList<int> SongIds { get; set; }

    }
}