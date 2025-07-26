using final_project.DAL;
using final_project.Moddels;

namespace final_project.BLL
{
 
        public class CategoryServices : ICategoryServices
        {
            private readonly ICategoryDAL _categoryDal; 

            public CategoryServices(ICategoryDAL categoryDal)
            {
                _categoryDal = categoryDal;
            }

            public async Task<List<GiftCategory>> GetAllCategories()
            {
                return await _categoryDal.GetAllCategories();
            }

            public async Task<GiftCategory?> GetCategoryById(int id)
            {
                return await _categoryDal.GetCategoryById(id);
            }

            public async Task<GiftCategory> AddCategory(GiftCategory category)
            {
                return await _categoryDal.AddCategory(category);
            }

            public async Task<GiftCategory> UpdateCategory(GiftCategory category)
            {
                return await _categoryDal.UpdateCategory(category);
            }

            public async Task DeleteCategory(int id)
            {
                await _categoryDal.DeleteCategory(id);
            }
        }
    }

