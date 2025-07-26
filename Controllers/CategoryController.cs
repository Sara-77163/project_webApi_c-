using AutoMapper;
using final_project.BLL;
using final_project.Moddels;
using final_project.Moddels.DTO;
using Microsoft.AspNetCore.Mvc;

namespace final_project.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoryController :ControllerBase
    {
            private readonly ICategoryServices _categoryServices;
            private readonly IMapper _mapper; 

            public CategoryController(ICategoryServices categoryServices, IMapper mapper)
            {
                _categoryServices = categoryServices;
                _mapper = mapper;
            }

            [HttpGet]
            public async Task<ActionResult<List<GiftCategoryDTO>>> GetAllCategories()
            {
                var categories = await _categoryServices.GetAllCategories();
                var categoryDtos = _mapper.Map<List<GiftCategoryDTO>>(categories);
                return Ok(categoryDtos); 
            }

            [HttpGet("{id}")]
            public async Task<ActionResult<GiftCategoryDTO>> GetCategoryById(int id)
            {
                var category = await _categoryServices.GetCategoryById(id);
                if (category == null)
                {
                    return NotFound(); 
                }
                
                var categoryDto = _mapper.Map<GiftCategoryDTO>(category);
                return Ok(categoryDto); 
            }

            [HttpPost]
            public async Task<ActionResult<GiftCategoryDTO>> AddCategory([FromBody] GiftCategoryDTO categoryDto)
            {
            var categoryToAdd = _mapper.Map<GiftCategory>(categoryDto);
            var addedCategory = await _categoryServices.AddCategory(categoryToAdd);

            var addedCategoryDto = _mapper.Map<GiftCategoryDTO>(addedCategory);

            return CreatedAtAction(nameof(GetCategoryById), new { id = addedCategory.Id }, addedCategoryDto);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCategory(int id, [FromBody] GiftCategoryDTO categoryDto)
        {
            var existingCategory = await _categoryServices.GetCategoryById(id);
            if (existingCategory == null)
            {
            }

            _mapper.Map(categoryDto, existingCategory);

            await _categoryServices.UpdateCategory(existingCategory);
            return NoContent();


        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            var categoryToDelete = await _categoryServices.GetCategoryById(id);
            if (categoryToDelete == null)
            {
                return NotFound(); 
            }

            await _categoryServices.DeleteCategory(id);
            return NoContent(); 
        }
    }
        }
