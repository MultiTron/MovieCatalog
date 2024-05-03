using MCApplicationServices.Interfaces;
using MCApplicationServices.Messaging.Requsets;
using MCApplicationServices.Messaging.Responses;
using MCData.Context;
using MCData.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace MCApplicationServices.Implementations
{
    public class GenreManagementService : BaseManagementService, IGenreManagementService
    {
        private readonly MovieCatalogDbContext _context;
        public GenreManagementService(ILogger<GenreManagementService> logger, MovieCatalogDbContext context) : base(logger)
        {
            _context = context;
        }

        public async Task<CreateGenreResponse> CreateGenre(CreateGenreRequest request)
        {
            _context.Genres.Add(new()
            {
                Name = request.Genre.Name,
                Movies = new List<Movie>(),
                CreatedBy = "Me",
                CreatedOn = DateTime.UtcNow,
            });
            await _context.SaveChangesAsync();
            return new();
        }

        public async Task<DeleteGenreResponse> DeleteGenre(DeleteGenreRequest request)
        {
            var toRemoved = await _context.Genres.FirstOrDefaultAsync(x => x.Id == request.Id);
            _context.Genres.Remove(toRemoved);
            await _context.SaveChangesAsync();
            return new();
        }

        public async Task<GetGenreResponse> GetGenres()
        {
            GetGenreResponse response = new() { Genres = new() };
            var genres = await _context.Genres.ToListAsync();

            foreach (var genre in genres)
            {
                response.Genres.Add(new() { Name = genre.Name });
            }
            return response;
        }
    }
}
