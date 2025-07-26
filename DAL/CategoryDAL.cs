using final_project.Moddels;
using Microsoft.EntityFrameworkCore;
using System;

namespace final_project.DAL
{
    public class CategoryDAL :ICategoryDAL

    {
       
            private readonly ChinaSaleContext _chainaSaleContext; 

            public CategoryDAL(ChinaSaleContext chainaSaleContext)
            {
            _chainaSaleContext = chainaSaleContext;
            }

            public async Task<List<GiftCategory>> GetAllCategories()
            {
                return await _chainaSaleContext.GiftCategories.ToListAsync();
            }

            public async Task<GiftCategory?> GetCategoryById(int id)
            {
                return await _chainaSaleContext.GiftCategories.FindAsync(id);
            }

            public async Task<GiftCategory> AddCategory(GiftCategory category)
            {
            _chainaSaleContext.GiftCategories.Add(category);
                await _chainaSaleContext.SaveChangesAsync();
                return category;
            }

           public async Task<GiftCategory> UpdateCategory(GiftCategory category)
            {

          _chainaSaleContext.GiftCategories.Update(category);
          await _chainaSaleContext.SaveChangesAsync();
          return category;
            

        }
        public async Task DeleteCategory(int id)
            {
                var categoryToDelete = await _chainaSaleContext.GiftCategories.FindAsync(id);
                if (categoryToDelete != null)
                {
                _chainaSaleContext.GiftCategories.Remove(categoryToDelete);
                    await _chainaSaleContext.SaveChangesAsync();
                }
            }
    //    public async Task<List<IGrouping<string ,Purchase>>> purchaseByGift()
    //    {
    //      //  return await _chainaSaleContext.Purchases.Include(p => p.Gift).GroupBy(p => p.GiftID) 
    //      //.Select(p => new
    //      //{
    //      //    GiftName = p.Key,
    //      //    Purchases = p.ToList()
    //      //}
    //      var purchasesPerGift = _chainaSaleContext.Purchases
    //     .GroupBy(p => p.Gift.Name)
    //     .Select(g => new
    //     {
    //    GiftName = g.Key,
    //    TotalTickets = g.Count(),
    //    TotalAmount = g.Sum(p => p.Amount)
    //})
    //.ToListAsync();
    //    }
        }
    }

