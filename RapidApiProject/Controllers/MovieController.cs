using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RapidApiProject.Models;

namespace RapidApiProject.Controllers
{
    public class MovieController : Controller
    {
        public async Task<IActionResult> MovieList()
        {
            List<ApiMovieViewModel> model = new List<ApiMovieViewModel>();
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://imdb236.p.rapidapi.com/imdb/top250-movies"),
                Headers =
    {
        { "x-rapidapi-key", "3db79cb1e3mshfa9b8dd84816013p1e663fjsn48c308702bf9" },
        { "x-rapidapi-host", "imdb236.p.rapidapi.com" },
    },
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                model=JsonConvert.DeserializeObject<List<ApiMovieViewModel>>(body);
                return View(model);
            }
        }   
    }
}
