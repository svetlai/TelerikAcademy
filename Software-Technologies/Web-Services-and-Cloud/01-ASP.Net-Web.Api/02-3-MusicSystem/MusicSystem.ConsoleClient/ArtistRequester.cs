namespace MusicSystem.ConsoleClient
{
    using System;
    using System.Collections.Generic;
    using System.Net.Http;

    using MusicSystem.Model;

    public class ArtistRequester
    {
        private readonly HttpClient Client;

        public ArtistRequester(HttpClient Client)
        {
            this.Client = Client;
        }
        public void AddNewArtist(Artist artist)
        {
            var response = Client.PostAsJsonAsync("api/Artists/Create", artist).Result;
            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine("Artist added!");
            }
            else
            {
                Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
            }
        }

        public void UpdateArtist(int id, Artist artist)
        {
            var response = Client.PutAsJsonAsync("api/Artists/Update/" + id, artist).Result;
            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine("Artist updated!");
            }
            else
            {
                Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
            }
        }

        public void DeleteArtist(int id)
        {
            var response = Client.DeleteAsync("api/Artists/Delete/" + id).Result;
            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine("Artist deleted!");
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
        public void GetAllArtists()
        {
            HttpResponseMessage response = Client.GetAsync("api/Artists/All").Result; // Blocking call!
            if (response.IsSuccessStatusCode)
            {
                var artists = response.Content.ReadAsAsync<IEnumerable<Artist>>().Result;
                foreach (var a in artists)
                {
                    Console.WriteLine("{0} {1} {2}", a.ArtistId, a.Name, a.DateOfBirth);
                }
            }
            else
            {
                Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
            }
        }

        public void GetArtistById(int id)
        {
            HttpResponseMessage response = Client.GetAsync("api/Artists/ById/" + id).Result; // Blocking call!
            if (response.IsSuccessStatusCode)
            {
                var artist = response.Content.ReadAsAsync<Artist>().Result;
                Console.WriteLine("{0} {1} {2}", artist.ArtistId, artist.Name, artist.DateOfBirth);
            }
            else
            {
                Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
            }
        }
    }
}
