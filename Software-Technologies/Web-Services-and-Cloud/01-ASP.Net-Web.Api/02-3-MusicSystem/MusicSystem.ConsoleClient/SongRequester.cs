namespace MusicSystem.ConsoleClient
{
    using System;
    using System.Collections.Generic;
    using System.Net.Http;

    using MusicSystem.Model;

    public class SongRequester
    {
        private readonly HttpClient Client; 
        public SongRequester(HttpClient Client)
        {
            this.Client = Client;
        }

        public void AddNewSong(Song song)
        {
            var response = Client.PostAsJsonAsync("api/Songs/Create", song).Result;
            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine("Song added!");
            }
            else
            {
                Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
            }
        }

        public void UpdateSong(int id, Song song)
        {
            var response = Client.PutAsJsonAsync("api/Songs/Update/" + id, song).Result;
            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine("Song updated!");
            }
            else
            {
                Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
            }
        }

        public void DeleteSong(int id)
        {
            var response = Client.DeleteAsync("api/Songs/Delete/" + id).Result;
            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine("Song deleted!");
            }
            else
            {
                Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
            }
        }

        /*
         * The GetAsync method sends an HTTP GET request. As the name implies, GetAsyc is asynchronous.
         * It returns immediately, without waiting for a response from the server.
         * The return value is a Task object that represents the asynchronous operation.
         * When the operation completes, the Task.Result property contains the HTTP response.
         */
        public void GetAllSongs()
        {
            HttpResponseMessage response = Client.GetAsync("api/Songs/All").Result; // Blocking call!
            if (response.IsSuccessStatusCode)
            {
                var songs = response.Content.ReadAsAsync<IEnumerable<Song>>().Result;
                foreach (var s in songs)
                {
                    Console.WriteLine("{0} {1} {2} {3} {4} {5}", s.SongId, s.Title, s.Year, s.Genre, s.AlbumId, s.ArtistId);
                }
            }
            else
            {
                Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
            }
        }

        public void GetSongById(int id)
        {
            HttpResponseMessage response = Client.GetAsync("api/Songs/ById/" + id).Result; // Blocking call!
            if (response.IsSuccessStatusCode)
            {
                var song = response.Content.ReadAsAsync<Song>().Result;
                Console.WriteLine("{0} {1} {2} {3}", song.AlbumId, song.Title, song.Year, song.Genre);
            }
            else
            {
                Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
            }
        }
    }
}
