using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Threading.Tasks;
using System.Text.Json;
using PlaceholderPosts.Infrastructure;

namespace HTTPbin.Infrastructure
{
    public static class JSONPlaceholderAPI
    {
        private const string MediaTypeJSON = "application/json";

        private static readonly HttpClient HttpClient;

        static JSONPlaceholderAPI()
        {
            HttpClient = new HttpClient()
            {
                BaseAddress = new Uri(
                    "https://jsonplaceholder.typicode.com"
                )
            };
            var media = new MediaTypeWithQualityHeaderValue(
                MediaTypeJSON
            );
            HttpClient.DefaultRequestHeaders.Accept.Add(media);
        }

        public static async Task<List<Post>?> ReadAllPosts() =>
            await HttpClient.GetFromJsonAsync<List<Post>>("posts");

        public static async Task<Post?> ReadPost(long id) =>
            await HttpClient.GetFromJsonAsync<Post>($"posts/{id}");

        public static async Task<Post?> CreatePost(Post post)
        {
            var response = await HttpClient.PostAsJsonAsync(
                "posts",
                post
            );
            response.EnsureSuccessStatusCode();
            var content =
                await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<Post>(content);
        }
    }
}
