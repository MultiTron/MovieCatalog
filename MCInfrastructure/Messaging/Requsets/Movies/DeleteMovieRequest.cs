namespace MCInfrastructure.Messaging.Requsets.Movies
{
    public class DeleteMovieRequest : IntegerServiceRequestBase
    {
        public DeleteMovieRequest(int id) : base(id)
        {
        }
    }
}
