namespace MusicSystem.Services.Controllers
{
    using System.Linq;
    using System.Web.Http;

    using MusicSystem.Data;
    using MusicSystem.Data.Contracts;
    using MusicSystem.Model;
    using MusicSystem.Services.Models;

    public class SongsController : ApiController
    {
        private const string NoSuchArtistId = "Invalid id. No artist with such id was found.";
        private const string NoSuchAlbumId = "Invalid id. No album with such id was found.";
        private const string NoSuchSongId = "Invalid id. No song with such id was found.";
        private IMusicSystemData data;

        public SongsController()
            : this(new MusicSystemData())
        {
        }

        public SongsController(IMusicSystemData data)
        {
            this.data = data;
        }

        [HttpGet]
        public IQueryable All()
        {
            var songs = this.data
                .Songs
                .All()
                .Select(SongModel.FromSong);

            return songs;
        }

        [HttpGet]
        public IHttpActionResult ById(int id)
        {
            var song = GetSongById(id);
            if (song == null)
            {
                return BadRequest(NoSuchSongId);
            }

            return Ok(song);
        }

        [HttpPost]
        public IHttpActionResult Create(SongModel song)
        {
            if (!this.ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var newSong = new Song
            {
                Title = song.Title,
                Year = song.Year,
                Genre = song.Genre,
                AlbumId = song.AlbumId,
                ArtistId = song.ArtistId
            };

            this.data.Songs.Add(newSong);
            this.data.SaveChanges();

            song.SongId = newSong.SongId;

            return Ok(song);
        }

        [HttpPut]
        public IHttpActionResult Update(int id, SongModel song)
        {
            if (!this.ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var existingSong = this.data.Songs.Find(id);

            if (existingSong == null)
            {
                return BadRequest(NoSuchSongId);
            }

            existingSong.Title = song.Title;
            existingSong.Year = song.Year;
            existingSong.Genre = song.Genre;
            existingSong.AlbumId = song.AlbumId;
            existingSong.ArtistId = song.ArtistId;
            this.data.SaveChanges();

            song.SongId = existingSong.SongId;

            return Ok(song);
        }

        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            var existingSong = this.data.Songs.Find(id);

            if (existingSong == null)
            {
                return BadRequest(NoSuchSongId);
            }

            this.data.Songs.Delete(existingSong);
            this.data.SaveChanges();

            return Ok();
        }

        [HttpPost]
        public IHttpActionResult AddArtist(int songId, int artistId)
        {
            var song = this.data.Songs.Find(songId);
            if (song == null)
            {
                return BadRequest(NoSuchSongId);
            }

            var artist = this.data.Artists.Find(artistId);
            if (artist == null)
            {
                return BadRequest(NoSuchArtistId);
            }

            song.ArtistId = artistId;
            this.data.SaveChanges();

            return Ok();
        }

        public IHttpActionResult AddAlbum(int songId, int albumId)
        {
            var song = this.data.Songs.Find(songId);
            if (song == null)
            {
                return BadRequest(NoSuchSongId);
            }

            var album = this.data.Albums.Find(albumId);
            if (album == null)
            {
                return BadRequest(NoSuchArtistId);
            }

            song.AlbumId = albumId;
            this.data.SaveChanges();

            return Ok();
        }

        private SongModel GetSongById(int id)
        {
            return this.data
                .Songs
                .All()
                .Select(SongModel.FromSong)
                .FirstOrDefault(a => a.SongId == id);
        }
    }
}
