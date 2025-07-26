

namespace final_project.Moddels.DTO
{
    public class PurchaseDTO
    {
        public int UserId { get; set; }
        public int GiftID { get; set; }
        public int Quantity { get; set; } = 1;
        public DateTime Date { get; } = DateTime.Now;
        public StatusPurchase Status { get; set; } = StatusPurchase.In_progress;
    }
}
