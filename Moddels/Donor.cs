using System.ComponentModel.DataAnnotations;

namespace final_project.Moddels
{
    public class Donor
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public required string Name { get; set; }
        [EmailAddress]
        public string? Email { get; set; }
        [Phone]
        [Required]
        public required string Phone { get; set; }

        public List<Gift> Gifts { get; set; } = new();
    }
}
