using MCInfrastructure.Messaging.Requsets.Genres;
using MCInfrastructure.Messaging.Responses.Genres;

namespace MCApplicationServices.Interfaces
{
    public interface IGenreManagementService
    {
        public Task<GetGenreResponse> GetGenres();
        public Task<CreateGenreResponse> CreateGenre(CreateGenreRequest request);
        public Task<DeleteGenreResponse> DeleteGenre(DeleteGenreRequest request);
    }
}
