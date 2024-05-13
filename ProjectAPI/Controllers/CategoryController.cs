using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project.Business.Abstract;
using Project.Data.Entities;
using Project.DTO.CategoryDTO;

namespace ProjectAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;

        public CategoryController(ICategoryService categoryService, IMapper mapper)
        {
            _categoryService = categoryService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult CategoryList()
        {
            var categoryList = _mapper.Map<List<ResultCategoryDTO>>(_categoryService.TGetAll());
            return Ok(categoryList);
        }

        [HttpGet("GET_CATEGORY_COUNT")]
        public IActionResult GetCategoryCount()
        {
			var categoryCount = _categoryService.TGetCategoryCount();
			return Ok(categoryCount);
		}

		[HttpGet("ACTIVE_CATEGORY_COUNT")]
		public IActionResult ActiveCategoryCount()
		{
			var activeCategoryCount = _categoryService.TActiveCategoryCount();
			return Ok(activeCategoryCount);
		}

		[HttpGet("PASSIVE_CATEGORY_COUNT")]
		public IActionResult PassiveCategoryCount()
		{
			var passiveCategoryCount = _categoryService.TPassiveCategoryCount();
			return Ok(passiveCategoryCount);
		}

		[HttpPost]
        public IActionResult CreateCategory(CreateCategoryDTO createCategoryDTO)
        {
            _categoryService.TAdd(new Category
            {
                CategoryName = createCategoryDTO.CategoryName,
                CategoryStatus = true
            });
            return Ok("Kategori Eklendi!");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCategory(int id)
        {
            var category = _categoryService.TGetById(id);
            _categoryService.TDelete(category);
            return Ok("Kategori Silindi!");
        }

        [HttpGet("{id}")]
        public IActionResult GetCategoryById(int id)
        {
            var category = _categoryService.TGetById(id);
            return Ok(category);
        }

        [HttpPut]
        public IActionResult UpdateCategory(UpdateCategoryDTO updateCategoryDTO)
        {
            _categoryService.TUpdate(new Category
            {
                CategoryId = updateCategoryDTO.CategoryId,
                CategoryName = updateCategoryDTO.CategoryName,
                CategoryStatus = updateCategoryDTO.CategoryStatus
            });
            return Ok("Kategori Güncellendi!");
        }
    }
}
