using System.ComponentModel.DataAnnotations;

namespace MCData.Entities
{
    public class Rating : BaseEntity
    {
        [Required]
        public string Score { get; set; }
        public string? Description { get; set; }
    }
}
