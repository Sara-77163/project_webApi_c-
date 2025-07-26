
using System.ComponentModel.DataAnnotations;

namespace final_project.Moddels
{
   public  enum UserRole
    {
        Admin=1,
        User=2
    }
  
    public class User
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public required string Name { get; set; }
        [EmailAddress]
        [Required]
        public required string Email { get; set; }
        [Phone]
        [Required]
        public required string Phone { get; set; }
        [Required]
        public required string Password { get; set; }

        public UserRole Role { get; set; } = UserRole.User;
        public List<Purchase> purchases { get; set; } = new();
    }
}
