namespace MusicSystem.Services.Controllers
{
    using System.Linq;
    using System.Web.Http;

    using MusicSystem.Data;
    using MusicSystem.Data.Contracts;
    using MusicSystem.Model;
    using MusicSystem.Services.Models;
    using System;

    public class ArtistsController : ApiController
    {
        private const string NoSuchArtistId = "Invalid id. No artist with such id was found.";
        private const string NoSuchAlbumId = "Invalid id. No album with such id was found.";
        private const string NoSuchSongId = "Invalid id. No song with such id was found.";
        private IMusicSystemData data;

        public ArtistsController()
            : this(new MusicSystemData())
        {
        }

        public ArtistsController(IMusicSystemData data)
        {
            this.data = data;
        }

        [HttpGet]
        public IQueryable All()
        {
            var artists = this.data
                .Artists
                .All()
                .Select(ArtistModel.FromArtist);

            return artists;
        }

        [HttpGet]
        public IHttpActionResult ById(int id)
        {
            var artist = GetArtistById(id);
            if (artist == null)
            {
                return BadRequest(NoSuchArtistId);
            }

            return Ok(artist);
        }

        [HttpPost]
        public IHttpActionResult Create(ArtistModel artist)
        {
            if (!this.ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var newArtist = new Artist
            {
                Name = artist.Name,
                DateOfBirth = artist.DateOfBirth
            };

            if (artist.AlbumIds != null)
            {
                foreach (var id in artist.AlbumIds)
                {
                    var album = this.data.Albums.Find(id);
                    if (album != null)
                    {
                        newArtist.Albums.Add(album);
                    }
                    else
                    {
                        throw new ArgumentException(NoSuchAlbumId);
                    }

                }
            }

            if (artist.SongIds != null)
            {
                foreach (var id in artist.SongIds)
                {
                    var song = this.data.Songs.Find(id);
                    if (song != null)
                    {
                        newArtist.Songs.Add(song);
                    }
                    else
                    {
                        throw new ArgumentException(NoSuchSongId);
                    }

                }
            }

            this.data.Artists.Add(newArtist);
            this.data.SaveChanges();

            artist.ArtistId = newArtist.ArtistId;

            return Ok(artist);
        }

        [HttpPut]
        public IHttpActionResult Update(int id, ArtistModel artist)
        {
            if (!this.ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var existingArtist = this.data.Artists.Find(id);

            if (existingArtist == null)
            {
                return BadRequest(NoSuchArtistId);
            }

            existingArtist.Name = artist.Name;
            existingArtist.DateOfBirth = artist.DateOfBirth;

            //if (artist.AlbumIds != null)
            //{
            //    foreach (var albumId in artist.AlbumIds)
            //    {
            //        var album = this.data.Albums.Find(albumId);
            //        if (album != null)
            //        {
            //            existingArtist.Albums.Add(album);
            //        }
            //        else
            //        {
            //            throw new ArgumentException(NoSuchAlbumId);
            //        }
            //    }
            //}

            //if (artist.SongIds != null)
            //{
            //    foreach (var songId in artist.SongIds)
            //    {
            //        var song = this.data.Songs.Find(songId);
            //        if (song != null)
            //        {
            //            existingArtist.Songs.Add(song);
            //        }
            //        else
            //        {
            //            throw new ArgumentException(NoSuchSongId);
            //        }

            //    }
            //}

            this.data.SaveChanges();

            artist.ArtistId = existingArtist.ArtistId;
            return Ok(artist);
        }

        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            var existingArtist = this.data.Artists.Find(id);

            if (existingArtist == null)
            {
                return BadRequest(NoSuchArtistId);
            }

            this.data.Artists.Delete(existingArtist);
            this.data.SaveChanges();

            return Ok();
        }

        [HttpPost]
        public IHttpActionResult AddAlbum(int artistId, int albumId)
        {
            var artist = this.data.Artists.Find(artistId);
            if (artist == null)
            {
                return BadRequest(NoSuchArtistId);
            }

            var album = this.data.Albums.Find(albumId);
            if (album == null)
            {
                return BadRequest(NoSuchAlbumId);
            }

            artist.Albums.Add(album);
            this.data.SaveChanges();

            return Ok();
        }

        [HttpPost]
        public IHttpActionResult AddSong(int artistId, int songId)
        {
            var artist = this.data.Artists.Find(artistId);
            if (artist == null)
            {
                return BadRequest(NoSuchArtistId);
            }

            var song = this.data.Songs.Find(songId);
            if (song == null)
            {
                return BadRequest(NoSuchSongId);
            }

            artist.Songs.Add(song);
            this.data.SaveChanges();

            return Ok();
        }

        private ArtistModel GetArtistById(int id)
        {
            return this.data
                .Artists
                .All()
                .Select(ArtistModel.FromArtist)
                .FirstOrDefault(a => a.ArtistId == id);
        }
    }
}