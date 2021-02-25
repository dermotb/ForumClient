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
            PostAPost().Wait();
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
            else
            {
                Console.WriteLine(response.StatusCode +" ReasonPhrase: "+response.ReasonPhrase);
            }
        }

        private static async Task PostAPost()
        {
            HttpClient client = new HttpClient();

            client.BaseAddress = new Uri("http://localhost:53368/");
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

            userPost post = new userPost() { ID = 0, TimeStamp = DateTime.Now, Subject = "Client DB Post", Message = "This is from the client to the database" };

            HttpResponseMessage response = await client.PostAsJsonAsync("api/Forum", post);

            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine("Post was added!");
            }
            else
            {
                Console.WriteLine(response.StatusCode + " ReasonPhrase: " + response.ReasonPhrase);
            }
        }
    }
}
