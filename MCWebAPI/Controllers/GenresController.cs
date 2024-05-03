using MCApplicationServices.Interfaces;
using MCApplicationServices.Messaging.Requsets;
using Microsoft.AspNetCore.Mvc;

namespace MCWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenresController : ControllerBase
    {
        private readonly IGenreManagementService _genreService;
        public GenresController(IGenreManagementService genreService)
        {
            _genreService = genreService;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _genreService.GetGenres());
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] GenreModel genre)
        {
            return Ok(await _genreService.CreateGenre(new(genre)));
        }
        [HttpDelete]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            return Ok(await _genreService.DeleteGenre(new(id)));
        }
    }
}
