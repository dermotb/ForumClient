using Forum.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace ForumClient
{
    class Program
    {
        static void Main(string[] args)
        {
            GetAllPosts().Wait();
        }

        private static async Task GetAllPosts()
        {
            HttpClient client = new HttpClient();

            client.BaseAddress = new Uri("http://localhost:53368/");
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = await client.GetAsync("api/Forum");

            if(response.IsSuccessStatusCode)
            {
                IEnumerable<userPost> posts = await response.Content.ReadAsAsync<IEnumerable<userPost>>();

                foreach (userPost usp in posts)
                {
                    Console.WriteLine(usp.ToString());
                }
            }




        }
    }
}
