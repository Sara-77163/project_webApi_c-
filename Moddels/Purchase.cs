using Microsoft.Extensions.Configuration.UserSecrets;
using Microsoft.VisualBasic;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace final_project.Moddels
{
    public enum StatusPurchase
    {
        In_progress=1,
        Completed =2
    }
    public class Purchase
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("User")]
        public int UserId {get;set;}
        [ForeignKey("Gift")]
        public int GiftID { get; set; }
        public int Quantity { get; set; } = 1;
        public DateTime Date { get; } = DateTime.Now;
        public StatusPurchase Status { get; set; } = StatusPurchase.In_progress;
        public Gift Gift { get; set; }
        public User User { get; set; }
    }
}
