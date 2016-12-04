namespace MusicSystem.ConsoleClient
{
    using System;
    using System.Collections.Generic;
    using System.Net.Http;

    using MusicSystem.Model;

    public class AlbumRequester
    {
        private readonly HttpClient Client;

        public AlbumRequester(HttpClient Client)
        {
            this.Client = Client;
        }
        public void AddNewAlbum(Album album)
        {
            var response = Client.PostAsJsonAsync("api/Albums/Create", album).Result;
            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine("Album added!");
            }
            else
            {
                Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
            }
        }

        public void UpdateAlbum(int id, Album album)
        {
            var response = Client.PutAsJsonAsync("api/Albums/Update/" + id, album).Result;
            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine("Album updated!");
            }
            else
            {
                Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
            }
        }

        public void DeleteAlbum(int id)
        {
            var response = Client.DeleteAsync("api/Albums/Delete/" + id).Result;
            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine("Album deleted!");
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
        public void GetAllAlbums()
        {
            HttpResponseMessage response = Client.GetAsync("api/Albums/All").Result; // Blocking call!
            if (response.IsSuccessStatusCode)
            {
                var albums = response.Content.ReadAsAsync<IEnumerable<Album>>().Result;
                foreach (var a in albums)
                {
                    Console.WriteLine("{0} {1} {2} {3}", a.AlbumId, a.Title, a.Producer, a.Year);
                }
            }
            else
            {
                Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
            }
        }

        public void GetAlbumById(int id)
        {
            HttpResponseMessage response = Client.GetAsync("api/Albums/ById/" + id).Result; // Blocking call!
            if (response.IsSuccessStatusCode)
            {
                var album = response.Content.ReadAsAsync<Album>().Result;
                Console.WriteLine("{0} {1} {2} {3}", album.AlbumId, album.Title, album.Producer, album.Year);
            }
            else
            {
                Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
            }
        }

        //public void AddSongToAlbum(int albumId, int songId)
        //{
        //    HttpResponseMessage response = Client.PostAsJsonAsync("api/AddSong?albumId=" + albumId + "&songId=" + songId, "").Result; // Blocking call!
        //    if (response.IsSuccessStatusCode)
        //    {
        //        var album = response.Content.ReadAsAsync<Album>().Result;
        //        Console.WriteLine("{0} {1}", album.AlbumId, album.Songs);
        //    }
        //    else
        //    {
        //        Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
        //    }
        //}
    }
}
