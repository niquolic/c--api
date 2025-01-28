using System.ComponentModel.DataAnnotations;

namespace LibraryAPI.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [RegularExpression("^(Administrateur|Lecteur)$", ErrorMessage = "Le rôle doit être 'Administrateur' ou 'Lecteur'.")]
        public string Role { get; set; }
    }
}