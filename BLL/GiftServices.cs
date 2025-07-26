using final_project.DAL;
using final_project.Moddels;

namespace final_project.BLL
{
    public class GiftServices : IGiftServices
    {
        private readonly IGiftDAL _giftDal;
        public GiftServices(IGiftDAL giftDal)
        {
            _giftDal = giftDal;
        }
        public async Task<Gift> AddGift(Gift gift)
        {
           return await _giftDal.AddGift(gift);
        }

        public async Task DeleteGift(int id)
        {
             await _giftDal.DeleteGift(id);
        }

        public async  Task<List<Gift>?> FilteredGifts(string? giftName, string? donorName, int? numBuyers)
        {
            return await _giftDal.FilteredGifts(giftName,donorName,numBuyers); 
        }

        public async Task<List<Gift>> GetAllGifts()
        {
            return await _giftDal.GetAllGifts();
        }

        public async Task<Gift> GetGiftById(int id)
        {
            return await _giftDal.GetGiftById(id);
           
        }

        public async Task<Gift> UpdateGift(Gift gift)
        {
            return await _giftDal.UpdateGift(gift);

        }
    }
}
