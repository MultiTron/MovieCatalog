namespace MCInfrastructure.Messaging.Requsets.Movies
{
    public class MovieModel
    {
        required public string Title { get; set; }
        public DateTime? ReleaseDate { get; set; }
        public string? Studio { get; set; }
        public string? Country { get; set; }
        required public int GenreId { get; set; }
        public int? RatingId { get; set; }
    }
}
