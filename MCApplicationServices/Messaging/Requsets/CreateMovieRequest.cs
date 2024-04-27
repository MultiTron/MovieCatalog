namespace MCApplicationServices.Messaging.Requsets
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
