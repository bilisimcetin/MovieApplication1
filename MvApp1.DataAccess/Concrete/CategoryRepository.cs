using Microsoft.EntityFrameworkCore;
using MovieApplication.DataAccess.Abstract;
using MvApp1.DataAccess;
using MvApp1.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApplication.DataAccess.Concrete
{


    public class CategoryRepository : ICategoryRepository

    {
        private readonly MovieDbContext _movieContext;


        public CategoryRepository(MovieDbContext movieContext)
        {
            _movieContext = movieContext;

        }

        public Category CreateCategory(Category category)
        {
            _movieContext.Categories.Add(category);
            _movieContext.SaveChanges();
            return category;
        }

        public void DeleteCategory(int id)
        {
            var category = GetCategoryById(id);
            if (category != null)
            {
                _movieContext.Categories.Remove(category);
                _movieContext.SaveChanges();
            }
        }

        public List<Category> GetAllCategories()
        {
            return _movieContext.Categories.ToList();
        }

        public Category GetCategoryById(int id)
        {
            return _movieContext.Categories.Find(id);
        }

        
    }
}