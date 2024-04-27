using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MCData.Entities
{
    public class Movie : BaseEntity
    {
        [Required]
        public string Title { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string? Country { get; set; }
        public string? Studio { get; set; }
        [ForeignKey("Rating")]
        public int? RatingId { get; set; }
        public virtual Rating? Rating { get; set; }
        [ForeignKey("Genre")]
        public int GenreId { get; set; }
        public virtual Genre Genre { get; set; }
    }
}
