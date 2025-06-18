using System.ComponentModel.DataAnnotations;

namespace final_project.Moddels
{
    public class Donor
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public  string Name { get; set; }
        [EmailAddress]
        public string? Email { get; set; }
        [Phone]
        [Required]
        public string Phone { get; set; }

        public List<Gift> gifts { get; set; } = new();
    }
}
