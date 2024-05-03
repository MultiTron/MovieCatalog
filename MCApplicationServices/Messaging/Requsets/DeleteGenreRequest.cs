namespace MCApplicationServices.Messaging.Requsets
{
    public class DeleteGenreRequest : IntegerServiceRequestBase
    {
        public GenreModel Genre { get; set; }
        public DeleteGenreRequest(int id) : base(id)
        {
            Genre = new GenreModel();
        }
    }
}
