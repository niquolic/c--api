using System.ComponentModel.DataAnnotations;

namespace LibraryAPI.Models
{
    public class Publisher
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required]
        [EmailAddress]
        public string ContactEmail { get; set; }

        [Range(1801, int.MaxValue, ErrorMessage = "FoundedYear must be greater than 1800.")]
        public int FoundedYear { get; set; }
    }
}