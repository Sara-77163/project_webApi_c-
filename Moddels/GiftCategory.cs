using System.ComponentModel.DataAnnotations;

namespace final_project.Moddels
{
    public class GiftCategory
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string  Name{get;set;} 
        public List<Gift> gifts { get; set; } = new();
    }
}
