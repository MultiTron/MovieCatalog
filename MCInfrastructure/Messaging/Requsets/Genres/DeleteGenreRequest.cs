namespace MCInfrastructure.Messaging.Requsets.Genres
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
