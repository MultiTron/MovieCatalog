using MCApplicationServices.Interfaces;
using MCApplicationServices.Messaging.Requsets;
using Microsoft.AspNetCore.Mvc;

namespace MCWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly IMovieManagementService _movieManagement;
        public MoviesController(IMovieManagementService movieManagement)
        {
            _movieManagement = movieManagement;
        }
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] int currentPage, int elementsPerPage)
        {
            return Ok(await _movieManagement.GetMovies(new(currentPage, elementsPerPage)));
        }
        [HttpGet("SearchByTitle/{title}")]
        public async Task<IActionResult> SearchByTitle([FromRoute] string title)
        {
            return Ok(await _movieManagement.GetMoviesByTitle(title));
        }
        [HttpGet("SearchByGenre/{genre}")]
        public async Task<IActionResult> SearchByGenre([FromRoute] string genre)
        {
            return Ok(await _movieManagement.GetMoviesByGenre(genre));
        }
        [HttpGet("SearchByRating/{rating}")]
        public async Task<IActionResult> SearchByRating([FromRoute] string rating)
        {
            return Ok(await _movieManagement.GetMoviesByRating(rating));
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] MovieModel movie)
        {
            return Ok(await _movieManagement.CreateMovie(new(movie)));
        }
    }
}
