using final_project.Moddels;
using final_project.Moddels.DTO;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace final_project.DAL
{
    public class PurchaseDAL : IPurchaseDAL
    {
        private readonly ChinaSaleContext _chainaSaleContext;

        public PurchaseDAL(ChinaSaleContext chainaSaleContext)
        {
            _chainaSaleContext = chainaSaleContext;
        }
        public async Task<Purchase> AddPurchase(Purchase purchase)
        {
            _chainaSaleContext.Purchases.Add(purchase);
            await _chainaSaleContext.SaveChangesAsync();
            return purchase;
            
        }

        public async Task DeletePurchase(int id)
        {
            var purchase=await _chainaSaleContext.Purchases.Where(p=>p.Id==id).FirstOrDefaultAsync();
            if (purchase != null)
            {
                _chainaSaleContext.Purchases.Remove(purchase);
                await _chainaSaleContext.SaveChangesAsync();
            }
            
        }


        public async Task<List<Purchase>> GetAllPurchase()
        {
            return await _chainaSaleContext.Purchases.ToListAsync(); ;
        }

        public async  Task<Purchase?> GetPurchaseById(int id)
        {
            return  await _chainaSaleContext.Purchases.Where(p => p.Id == id).FirstOrDefaultAsync();
        }

        public async Task<Purchase> UpdatePurchase(Purchase purchase)
        {
            _chainaSaleContext.Purchases.Update(purchase);
            await _chainaSaleContext.SaveChangesAsync();
            return purchase;
        }
        public async Task<List<PurchaseByGiftDTO>> GetPurchaseByGift()
        {
          return await _chainaSaleContext.Purchases.GroupBy(p=>new { p.GiftID, p.Gift.Name }).Select(g => new PurchaseByGiftDTO
            {
                GiftName = g.Key.Name,
                Purchases = g.ToList()
            }).ToListAsync();
        }
        public async Task<List<User>> GetPurchaser()
        {
            return await _chainaSaleContext.Purchases.Include(p => p.User).Select(p => p.User).ToListAsync();

        }

    }
}
