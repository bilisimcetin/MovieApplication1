using MvApp1.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApplication.DataAccess.Abstract
{
   public interface ICategoryRepository
    {

        List<Category> GetAllCategories();
        Category GetCategoryById(int id);

        Category CreateCategory(Category category);
        
        void DeleteCategory(int id);

    }
}
