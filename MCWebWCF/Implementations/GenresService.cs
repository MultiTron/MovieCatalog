using MCApplicationServices.Interfaces;
using MCInfrastructure.Messaging.Responses.Genres;
using MCWebWCF.Interfaces;

namespace MCWebWCF.Implementations
{
    public class GenresService : IGenresService
    {
        private readonly IGenreManagementService _manager;
        public GenresService(IGenreManagementService manager)
        {
            _manager = manager;
        }
        public async Task<GetGenreResponse> GetAllGenres()
        {
            return await _manager.GetGenres();
        }
    }
}
