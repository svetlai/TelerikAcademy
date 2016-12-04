namespace MusicSystem.ConsoleClient
{
    using System;
    using System.Net.Http;
    using System.Net.Http.Headers;

    using MusicSystem.Model;

    public class MusicSystemEntryPoint
    {
        private static readonly HttpClient Client = new HttpClient { BaseAddress = new Uri("http://localhost:6538/") };
        public static void Main()
        {
            // Add an Accept header for JSON format.
            Client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            AlbumRequester albumRequester = new AlbumRequester(Client);
            SongRequester songRequester = new SongRequester(Client);
            ArtistRequester artistRequetser = new ArtistRequester(Client);

            var album = new Album
            {
                Title = "Album Title",
                Year = 2014,
                Producer = "Album Producer"               
            };

            var updateAlbum = new Album
            {
                Title = "New Title",
                Year = 2014,
                Producer = "Album Producer"
            };

            albumRequester.AddNewAlbum(album);
            albumRequester.GetAllAlbums();
            albumRequester.UpdateAlbum(1, updateAlbum);
            albumRequester.GetAllAlbums();
            albumRequester.GetAlbumById(1);
            albumRequester.DeleteAlbum(1);
            albumRequester.GetAllAlbums();

            var artist = new Artist
            {
                Name = "Pesho",
                DateOfBirth = DateTime.Now
            };

            var updateArtist = new Artist
            {
                Name = "Gosho",
                DateOfBirth = DateTime.Now
            };

            artistRequetser.AddNewArtist(artist);
            artistRequetser.GetAllArtists();
            artistRequetser.UpdateArtist(1, updateArtist);
            artistRequetser.GetAllArtists();
            artistRequetser.GetArtistById(1);
            artistRequetser.DeleteArtist(1);
            artistRequetser.GetAllArtists();

            var song = new Song
            {
                Title = "Song Title",
                Year = 2014,
                Genre = "Hip-hop",
                ArtistId = 2,
                AlbumId = 2
            };

            var updateSong = new Song
            {
                Title = "New Song Title",
                Year = 2014,
                Genre = "Hip-hop"
            };

            songRequester.AddNewSong(song);
            songRequester.GetAllSongs();
            songRequester.UpdateSong(1, updateSong);
            songRequester.GetAllSongs();
            songRequester.GetSongById(1);
            songRequester.DeleteSong(1);
            songRequester.GetAllSongs();

        }
    }
}
