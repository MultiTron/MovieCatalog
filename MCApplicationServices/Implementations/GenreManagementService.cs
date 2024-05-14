using MCApplicationServices.Interfaces;
using MCData.Entities;
using MCInfrastructure.Messaging.Requsets.Genres;
using MCInfrastructure.Messaging.Responses.Genres;
using MCRepositories.Interfaces;
using Microsoft.Extensions.Logging;

namespace MCApplicationServices.Implementations
{
    public class GenreManagementService : BaseManagementService, IGenreManagementService
    {
        private readonly IUnitOfWork _unit;
        public GenreManagementService(ILogger<GenreManagementService> logger, IUnitOfWork unit) : base(logger)
        {
            _unit = unit;
        }

        public async Task<CreateGenreResponse> CreateGenre(CreateGenreRequest request)
        {
            var entity = new Genre()
            {
                Name = request.Genre.Name,
                CreatedBy = "Me",
                CreatedOn = DateTime.UtcNow,
            };
            _unit.Genre.Insert(entity);
            _unit.Genre.ActivateDeactivate(entity);
            try
            {
                await _unit.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw;
            }
            return new();
        }

        public async Task<DeleteGenreResponse> DeleteGenre(DeleteGenreRequest request)
        {
            _unit.Genre.Delete(request.Id);
            await _unit.SaveChangesAsync();
            return new();
        }

        public async Task<GetGenreResponse> GetGenres()
        {
            GetGenreResponse response = new() { Genres = new() };
            var genres = await _unit.Genre.GetAll(true);

            foreach (var genre in genres)
            {
                response.Genres.Add(new() { Name = genre.Name });
            }
            return response;
        }
    }
}
