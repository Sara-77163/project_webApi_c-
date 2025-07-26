using final_project.Moddels;
using final_project.Moddels.DTO;

namespace final_project.DAL
{
    public interface IPurchaseDAL
    {
        public Task<List<Purchase>> GetAllPurchase();

        public Task<Purchase?> GetPurchaseById(int id);

        public Task<Purchase> AddPurchase(Purchase purchase);

        public Task<Purchase> UpdatePurchase(Purchase purchase);
        public Task DeletePurchase(int id);
        public  Task<List<PurchaseByGiftDTO>> GetPurchaseByGift();
    }
}
