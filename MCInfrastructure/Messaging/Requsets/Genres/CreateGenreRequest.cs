namespace MCInfrastructure.Messaging.Requsets.Genres
{
    public class CreateGenreRequest : ServiceRequestBase
    {
        public GenreModel Genre { get; set; }
        public CreateGenreRequest(GenreModel genre)
        {
            Genre = genre;
        }
    }
}
