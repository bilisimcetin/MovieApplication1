using MovieApplication.DataAccess.Abstract;
using MovieApplication.Entities;
using MovieApplicationBusiness.Abstract;
using MvApp1.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApplicationBusiness.Concrete
{
    public class CategoryManager : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryManager(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }
        public AddCategoryDto CreateCategory(AddCategoryDto addCategoryDto)
        {
            var category = new Category
            {
                Name = addCategoryDto.Name
            };

            _categoryRepository.CreateCategory(category);

            return new AddCategoryDto
            {
                Id = category.Id ,
                Name = category.Name
            };
        }

        public void DeleteCategory(int id)
        {
            _categoryRepository.DeleteCategory(id);
        }

        public List<Category> GetAllCategories()
        {
            return _categoryRepository.GetAllCategories();
        }

        public Category GetCategoryById(int id)
        {
            return _categoryRepository.GetCategoryById(id);
        }

        public Category UpdateCategory(Category category)
        {
            return _categoryRepository.UpdateCategory(category);
        }
    }
}
