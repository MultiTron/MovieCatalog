using MCApplicationServices.Interfaces;
using MCApplicationServices.Messaging;
using MCApplicationServices.Messaging.Requsets;
using MCApplicationServices.Messaging.Responses;
using Microsoft.AspNetCore.Mvc;

namespace MCWebAPI.Controllers
{
    /// <summary>
    /// Movie Catalog
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class MoviesController : ControllerBase
    {
        private readonly IMovieManagementService _movieService;
        /// <summary>
        /// Initializes instance of the <see cref="MoviesController"/> class.
        /// </summary>
        /// <param name="movieService"></param>
        public MoviesController(IMovieManagementService movieService)
        {
            _movieService = movieService;
        }
        /// <summary>
        /// Get Movies if they are active
        /// </summary>
        /// <param name="isActive">Determins wheter to show active or inactive movies</param>
        /// <returns>List of active movies.</returns>
        [HttpGet("ActiveMovies")]
        [ProducesResponseType(typeof(GetMoviesResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ServiceResponseError), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Get([FromQuery] bool isActive)
        {
            return Ok(await _movieService.GetActiveMovies(new IsActiveRequest(isActive)));
        }

        /// <summary>
        /// Get Movies in pages
        /// </summary>
        /// <param name="currentPage">The current page</param>
        /// <param name="elementsPerPage">Number of elements per page</param>
        /// <returns>List of active movies by paging.</returns>
        [HttpGet]
        [ProducesResponseType(typeof(GetMoviesResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ServiceResponseError), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Get([FromQuery] int currentPage, int elementsPerPage)
        {
            return Ok(await _movieService.GetMovies(new PagingRequest(currentPage, elementsPerPage)));
        }
        /// <summary>
        /// Gets the movies by Title
        /// </summary>
        /// <param name="title">Search by movie title</param>
        /// <returns>List of movies.</returns>
        [HttpGet("SearchByTitle/{title}")]
        [ProducesResponseType(typeof(GetMoviesResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ServiceResponseError), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> SearchByTitle([FromRoute] string title)
        {
            return Ok(await _movieService.GetMoviesByTitle(title));
        }
        /// <summary>
        /// Gets the movies by Genre
        /// </summary>
        /// <param name="genre">Search by movie genre</param>
        /// <returns>List of movies.</returns>
        [HttpGet("SearchByGenre/{genre}")]
        [ProducesResponseType(typeof(GetMoviesResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ServiceResponseError), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> SearchByGenre([FromRoute] string genre)
        {
            return Ok(await _movieService.GetMoviesByGenre(genre));
        }
        /// <summary>
        /// Gets the movies by Genre
        /// </summary>
        /// <param name="rating">Search by movie rating</param>
        /// <returns>List of movies.</returns>
        [HttpGet("SearchByRating/{rating}")]
        [ProducesResponseType(typeof(GetMoviesResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ServiceResponseError), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> SearchByRating([FromRoute] string rating)
        {
            return Ok(await _movieService.GetMoviesByRating(rating));
        }
        /// <summary>
        /// Create new movie.
        /// </summary>
        /// <param name="movie">Movie model object</param>
        /// <returns>Returns create empty response</returns>
        [HttpPost]
        [ProducesResponseType(typeof(CreateMovieResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ServiceResponseError), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Create([FromBody] MovieModel movie)
        {
            return Ok(await _movieService.CreateMovie(new(movie)));
        }

        /// <summary>
        /// Delete new movie.
        /// </summary>
        /// <param name="id">Id of movie</param>
        /// <returns>Returns create empty response</returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(CreateMovieResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ServiceResponseError), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            return Ok(await _movieService.DeleteMovie(new(id)));
        }
    }
}
