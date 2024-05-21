using MCWebWCF;
using Microsoft.AspNetCore.Mvc;

namespace MC.Website.Controllers
{
    public class GenresController : Controller
    {
        public async Task<IActionResult> Index()
        {
            using (GenresServiceClient client = new GenresServiceClient())
            {
                var result = await client.GetAllGenresAsync();
                return View(result.Genres);
            }
        }
    }
}
