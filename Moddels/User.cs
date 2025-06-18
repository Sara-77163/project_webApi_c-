
using System.ComponentModel.DataAnnotations;

namespace final_project.Moddels
{
   public  enum Role
    {
        Admin=1,
        User=2
    }
  
    public class User
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [EmailAddress]
        [Required]
        public string Email { get; set; }
        [Phone]
        [Required]
        public string Phone { get; set; }
        [Required]
        public string Password { get; set; }

        public Role UserRole { get; set; } = Role.User;
        public List<Purchase> purchases { get; set; } = new();
    }
}
