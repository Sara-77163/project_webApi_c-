using final_project.Moddels;

namespace final_project.DAL
{
    public interface ICategoryDAL
        {
            public Task<List<GiftCategory>> GetAllCategories();

            public Task<GiftCategory?> GetCategoryById(int id);

            public Task<GiftCategory> AddCategory(GiftCategory category);

            public Task<GiftCategory> UpdateCategory(GiftCategory category);
            public Task DeleteCategory(int id);
        }
    }


