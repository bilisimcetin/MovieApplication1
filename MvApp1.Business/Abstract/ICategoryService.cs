using MovieApplication.Entities;
using MvApp1.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApplicationBusiness.Abstract
{
    public interface ICategoryService
    {

        List<Category> GetAllCategories();
        Category GetCategoryById(int id);
        AddCategoryDto CreateCategory(AddCategoryDto addCategoryDto);
        Category UpdateCategory(Category category);

        void DeleteCategory(int id);

    }
}
