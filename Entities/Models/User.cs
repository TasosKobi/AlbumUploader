using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    [Table("user")]
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [StringLength(45, ErrorMessage = "Email can't be longer than 60 characters")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [StringLength(100, ErrorMessage = "Password can't be longer than 100 characters")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Salt is required")]
        [StringLength(100, ErrorMessage = "Salt can't be longer than 60 characters")]
        public string Salt { get; set; }

        [Required(ErrorMessage = "IsValid is required")]
        public bool IsLoggedIn { get; set ; }
    }
}
