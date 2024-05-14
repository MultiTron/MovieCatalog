using MCInfrastructure.Messaging.Responses.Auth;
using MCInfrastructure.Messaging.Responses.Movies;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace MC.Website.Controllers
{
    public class MoviesController : Controller
    {
        private readonly Uri uri = new("http://localhost:5112/api/movies/");
        public async Task<IActionResult> Index()
        {
            var token = await Get();
            using (HttpClient client = new())
            {
                client.BaseAddress = uri;
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Add("Accept", "application/json");
                client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
                HttpResponseMessage response = await client.GetAsync("activeMovies?isActive=true");
                var jsonContent = await response.Content.ReadAsStreamAsync();
                var data = await JsonSerializer.DeserializeAsync<GetMoviesResponse>(jsonContent, new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase });
                return View(data);
            }
        }
        [HttpPost]
        public IActionResult Create()
        {
            return View();
        }
        private static async Task<string> Get()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new("http://localhost:5112/api/auth?clientId=fmi&secret=fmi");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Add("Accept", "application/json");
                HttpResponseMessage response = await client.GetAsync("");
                var jsonContent = await response.Content.ReadAsStreamAsync();
                var data = await JsonSerializer.DeserializeAsync<TokenResponse>(jsonContent, new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase });
                return data.Token;
            }
        }
    }
}
