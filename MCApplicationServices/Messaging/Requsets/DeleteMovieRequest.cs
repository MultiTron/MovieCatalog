namespace MCApplicationServices.Messaging.Requsets
{
    public class DeleteMovieRequest : IntegerServiceRequestBase
    {
        public DeleteMovieRequest(int id) : base(id)
        {
        }
    }
}
