﻿using MCApplicationServices.Interfaces;
using MCInfrastructure.Messaging.Requsets.Genres;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MCWebAPI.Controllers
{
    /// <summary>
    /// Genre conroller
    /// </summary>
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class GenresController : ControllerBase
    {
        private readonly IGenreManagementService _genreService;
        /// <summary>
        /// The genres constructor
        /// </summary>
        /// <param name="genreService"></param>
        public GenresController(IGenreManagementService genreService)
        {
            _genreService = genreService;
        }
        /// <summary>
        /// Get genres
        /// </summary>
        /// <returns>Returns a list of all movie genres</returns>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _genreService.GetGenres());
        }
        /// <summary>
        /// Creates a movie genre
        /// </summary>
        /// <param name="genre">Genre model</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] GenreModel genre)
        {
            return Ok(await _genreService.CreateGenre(new(genre)));
        }
        /// <summary>
        /// Deletes a movie genre
        /// </summary>
        /// <param name="id">Id of genre to be deleted</param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            return Ok(await _genreService.DeleteGenre(new(id)));
        }
    }
}
