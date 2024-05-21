using MCInfrastructure.Messaging.Responses.Genres;

namespace MCWebWCF.Interfaces
{
    [ServiceContract]
    public interface IGenresService
    {
        [OperationContract]
        public Task<GetGenreResponse> GetAllGenres();
    }
}
