namespace MCApplicationServices.Messaging.Responses
{
    /// <summary>
    /// Get movies response object.
    /// </summary>
    public class GetMoviesResponse : ServiceResponseBase
    {
        /// <summary>
        /// Gets or sets the movie list.
        /// </summary>
        public List<MovieViewModel> Movies { get; set; }
    }
}
