using final_project.Moddels.DTO;
using final_project.Moddels;

namespace final_project.BLL
{
    public interface IPurchaseServices
    {
        
            public Task<List<Purchase>> GetAllPurchase();

            public Task<Purchase?> GetPurchaseById(int id);

            public Task<Purchase> AddPurchase(Purchase purchase);

            public Task<Purchase> UpdatePurchase(Purchase purchase);
            public Task DeletePurchase(int id);
            public Task<List<PurchaseByGiftDTO>> GetPurchaseByGift();
        
    }
}
