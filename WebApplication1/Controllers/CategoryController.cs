using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
        public Category Post([FromBody] Category category)
        {
            return _categoryService.CreateCategory(category);
        }

        [HttpDelete("{id}")]
        public void Delete( int id)
        {

            _categoryService.DeleteCategory(id);
        }

        [HttpPut]

        public Category Put([FromBody] Category category)
        {

            return _categoryService.UpdateCategory(category);
        }
    }
}
