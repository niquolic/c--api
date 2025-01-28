using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryAPI.Models
{
    public class Loan
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Book")]
        public int BookId { get; set; }

        [Required]
        public string BorrowerName { get; set; }

        [Required]
        public DateTime BorrowDate { get; set; } = DateTime.Now;

        public DateTime? ReturnDate { get; set; }
    }
}