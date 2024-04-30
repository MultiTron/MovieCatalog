using MCApplicationServices.Messaging.Requsets;
using MCApplicationServices.Messaging.Responses;

namespace MCApplicationServices.Interfaces
{
    public interface IGenreManagementService
    {
        public Task<GetGenreResponse> GetGenres();
        public Task<CreateGenreResponse> CreateGenre(CreateGenreRequest request);
        public Task<DeleteGenreResponse> DeleteGenre(DeleteGenreRequest request);
    }
}
