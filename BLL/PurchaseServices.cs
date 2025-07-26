using final_project.DAL;
using final_project.Moddels;
using final_project.Moddels.DTO;

namespace final_project.BLL
{
    public class PurchaseServices : IPurchaseServices
    {
        public readonly IPurchaseDAL _purchaseDal;
        public PurchaseServices(IPurchaseDAL purchaseDal)
        {
            _purchaseDal = purchaseDal;
        }
        public async  Task<Purchase> AddPurchase(Purchase purchase)
        {
            return await _purchaseDal.AddPurchase(purchase);
        }

        public async Task DeletePurchase(int id)
        {
             await _purchaseDal.DeletePurchase(id);
        }

        public async Task<List<Purchase>> GetAllPurchase()
        {
            return await GetAllPurchase();
        }

        public async Task<List<PurchaseByGiftDTO>> GetPurchaseByGift()
        {
            return await _purchaseDal.GetPurchaseByGift();
        }

        public async Task<Purchase?> GetPurchaseById(int id)
        {
            return await _purchaseDal.GetPurchaseById(id);
        }

        public async Task<Purchase> UpdatePurchase(Purchase purchase)
        {
            return await _purchaseDal.UpdatePurchase(purchase);
        }
    }
}
