using final_project.Moddels;

namespace final_project.DAL
{
    public interface IGiftDAL
    {
        

            public Task<List<Gift>> GetAllGifts();

 
            public Task<Gift> GetGiftById(int id);

 
           public  Task<Gift> AddGift(Gift gift);


            public Task<Gift> UpdateGift(Gift gift);

            public Task DeleteGift(int id);
            public Task<List<Gift>?> FilteredGifts(string? giftName, string? donorName, int? numBuyers);

        }
    }


