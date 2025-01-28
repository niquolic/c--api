using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryAPI.Models
{
    public class Book
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(200)]
        public string Title { get; set; }

        [Required]
        [MaxLength(100)]
        public string Author { get; set; }

        [Range(1500, 2025, ErrorMessage = "FoundedYear must be greater than 1800.")]
        public int PublishedYear { get; set; }

        [Required]
        public string Isbn { get; set;}

        [ForeignKey("Publisher")]
        public int PublisherId { get; set; }

        [ForeignKey("Category")]
        public int CategoryId { get; set; }
    }
}