using final_project.Moddels;
using Microsoft.EntityFrameworkCore;
using static final_project.DAL.IGiftDAL;

namespace final_project.DAL
{
    public class GiftDal : IGiftDAL

    {
        private readonly ChinaSaleContext _chainaSaleContext;

        public GiftDal(ChinaSaleContext chainaSaleContext)
        {
            _chainaSaleContext = chainaSaleContext;
        }


        public async Task<List<Gift>> GetAllGifts()
        {
            return await _chainaSaleContext.Gifts
                                 .Include(g => g.Category)
                                 .ToListAsync();
        }


        public async Task<Gift?> GetGiftById(int id)
        {
            return await _chainaSaleContext.Gifts
                                 .Include(g => g.Category)
                                 .FirstOrDefaultAsync(g => g.Id == id);
        }


        public async Task<Gift> AddGift(Gift gift)
        {
            _chainaSaleContext.Gifts.Add(gift);
            await _chainaSaleContext.SaveChangesAsync();
            return gift;
        }


        public async Task<Gift> UpdateGift(Gift gift)
        {

            _chainaSaleContext.Entry(gift).State = EntityState.Modified;
            await _chainaSaleContext.SaveChangesAsync();
            return gift;
        }


        public async Task DeleteGift(int id)
        {
            var giftToDelete = await _chainaSaleContext.Gifts.FindAsync(id);
            if (giftToDelete != null)
            {
                _chainaSaleContext.Gifts.Remove(giftToDelete);
                await _chainaSaleContext.SaveChangesAsync();
            }
        }
       public async Task<List<Gift>?> FilteredGifts(string? giftName,string? donorName,int? numBuyers)
        {
           var query = _chainaSaleContext.Gifts
                .Include(g => g.Donor)
                 .Where(g =>
                         (string.IsNullOrEmpty(giftName) || g.Name.Contains(giftName)) &&
                         (string.IsNullOrEmpty(donorName) || g.Donor.Name.Contains(donorName)) &&
                         (!numBuyers.HasValue || g.NumBuyers == numBuyers)
      ).ToList();
            return query;
        }
}
}
