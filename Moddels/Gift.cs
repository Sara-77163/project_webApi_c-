using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace final_project.Moddels
{
    public class Gift
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string? Name { get; set; }
      
        public string? Description { get; set; }

        [Required]
        public int Price { get; set; } 

        [ForeignKey ("GiftCategory")]
        public int GigtCategoryId { get; set; }
        [ForeignKey ("Donor")]
        public int DonorId { get; set; }
        public int NumBuyers { get; set; }
        public Donor? Donor { get; set; }
        public GiftCategory? Category { get; set; }
    }
}
