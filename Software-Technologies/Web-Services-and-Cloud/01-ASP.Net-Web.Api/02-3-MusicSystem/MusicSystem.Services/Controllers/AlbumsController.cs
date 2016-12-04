namespace MusicSystem.Services.Controllers
{
    using System.Linq;
    using System.Web.Http;

    using MusicSystem.Data;
    using MusicSystem.Data.Contracts;
    using MusicSystem.Model;
    using MusicSystem.Services.Models;
    using System;

    public class AlbumsController : ApiController
    {
        private const string NoSuchArtistId = "Invalid id. No artist with such id was found.";
        private const string NoSuchAlbumId = "Invalid id. No album with such id was found.";
        private const string NoSuchSongId = "Invalid id. No song with such id was found.";
        private IMusicSystemData data;

        public AlbumsController()
            : this(new MusicSystemData())
        {
        }

        public AlbumsController(IMusicSystemData data)
        {
            this.data = data;
        }

        [HttpGet]
        public IQueryable All()
        {
            var albums = this.data
                .Albums
                .All()
                .Select(AlbumModel.FromAlbum);

            return albums;
        }

        [HttpGet]
        public IHttpActionResult ById(int id)
        {
            var album = GetAlbumById(id);
            if (album == null)
            {
                return BadRequest(NoSuchAlbumId);
            }

            return Ok(album);
        }

        [HttpPost]
        public IHttpActionResult Create(AlbumModel album)
        {
            if (!this.ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var newAlbum = new Album
            {
                Title = album.Title,
                Year = album.Year,
                Producer = album.Producer
            };

            if (album.ArtistIds != null)
            {
                foreach (var id in album.ArtistIds)
                {
                    var artist = this.data.Artists.Find(id);
                    if (album != null)
                    {
                        newAlbum.Artists.Add(artist);
                    }
                    else
                    {
                        throw new ArgumentException(NoSuchArtistId);
                    }

                }
            }

            if (album.SongIds != null)
            {
                foreach (var id in album.SongIds)
                {
                    var song = this.data.Songs.Find(id);
                    if (song != null)
                    {
                        newAlbum.Songs.Add(song);
                    }
                    else
                    {
                        throw new ArgumentException(NoSuchSongId);
                    }

                }
            }

            this.data.Albums.Add(newAlbum);
            this.data.SaveChanges();

            album.AlbumId = newAlbum.AlbumId;

            return Ok(album);
        }

        [HttpPut]
        public IHttpActionResult Update(int id, AlbumModel album)
        {
            if (!this.ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var existingAlbum = this.data.Albums.Find(id);

            if (existingAlbum == null)
            {
                return BadRequest(NoSuchAlbumId);
            }

            existingAlbum.Title = album.Title;
            existingAlbum.Year = album.Year;
            existingAlbum.Producer = album.Producer;

            if (album.ArtistIds != null)
            {
                foreach (var albumId in album.ArtistIds)
                {
                    var artist = this.data.Artists.Find(albumId);
                    if (album != null)
                    {
                        existingAlbum.Artists.Add(artist);
                    }
                    else
                    {
                        throw new ArgumentException(NoSuchArtistId);
                    }

                }
            }

            if (album.SongIds != null)
            {
                foreach (var songId in album.SongIds)
                {
                    var song = this.data.Songs.Find(songId);
                    if (song != null)
                    {
                        existingAlbum.Songs.Add(song);
                    }
                    else
                    {
                        throw new ArgumentException(NoSuchSongId);
                    }
                }
            }

            this.data.SaveChanges();

            album.AlbumId = existingAlbum.AlbumId;

            return Ok(album);
        }

        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            var existingAlbum = this.data.Albums.Find(id);

            if (existingAlbum == null)
            {
                return BadRequest(NoSuchAlbumId);
            }

            this.data.Albums.Delete(existingAlbum);
            this.data.SaveChanges();

            return Ok();
        }

        [HttpPost]
        public IHttpActionResult AddArtist(int albumId, int artistId)
        {
            var album = this.data.Albums.Find(albumId);
            if (album == null)
            {
                return BadRequest(NoSuchAlbumId);
            }

            var artist = this.data.Artists.Find(artistId);
            if (artist == null)
            {
                return BadRequest(NoSuchArtistId);
            }

            album.Artists.Add(artist);
            this.data.SaveChanges();

            return Ok();
        }

        [HttpPost]
        public IHttpActionResult AddSong(int albumId, int songId)
        {
            var album = this.data.Albums.Find(albumId);
            if (album == null)
            {
                return BadRequest(NoSuchAlbumId);
            }

            var song = this.data.Songs.Find(songId);
            if (song == null)
            {
                return BadRequest(NoSuchSongId);
            }

            album.Songs.Add(song);
            this.data.SaveChanges();

            return Ok();
        }

        private AlbumModel GetAlbumById(int id)
        {
            return this.data
                .Albums
                .All()
                .Select(AlbumModel.FromAlbum)
                .FirstOrDefault(a => a.AlbumId == id);
        }
    }
}
