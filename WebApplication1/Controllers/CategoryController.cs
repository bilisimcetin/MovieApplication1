using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieApplication.Entities;
using MovieApplicationBusiness.Abstract;
using MvApp1.Business.Abstract;
using MvApp1.Entities;

namespace MovieApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        public List<Category> Get()

        { return _categoryService.GetAllCategories(); }

        [HttpGet("{id}")]

        public Category Get(int id)

        { return _categoryService.GetCategoryById(id); }

        [HttpPost]
        public IActionResult Post([FromBody] AddCategoryDto addCategoryDto)
        {
            try
            {
                var createdCategory = _categoryService.CreateCategory(addCategoryDto);
                return Ok(createdCategory);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public void Delete( int id)
        {

            _categoryService.DeleteCategory(id);
        }

    }
}
