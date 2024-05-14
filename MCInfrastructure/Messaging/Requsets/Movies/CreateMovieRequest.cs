namespace MCInfrastructure.Messaging.Requsets.Movies
{
    public class CreateMovieRequest : ServiceRequestBase
    {
        public MovieModel Movie { get; set; }
        public CreateMovieRequest(MovieModel movie)
        {
            Movie = movie;
        }
    }
}
