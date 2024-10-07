using BusinessLayer.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer.Class;
using DataAccessLayer.EntityFramework;

namespace BusinessLayer.Services
{
    public class CategoryService : ICategoryService<Category>
    {
        EFCategory efCategory;
        public CategoryService(EFCategory efCategory)
        {
            this.efCategory = efCategory;
        }
        public void addCategory(Category category)
        {
            efCategory.addCategory(category);
        }

        public List<Category> GetAllCategories()
        {
            return efCategory.GetAllCategories();
        }
        public Dictionary<Category, int> GetCategoriesWithMovieCounts() 
        {
            return efCategory.GetCategoriesWithMovieCounts();
        }

        public void removeCategory(Category category)
        {
            efCategory.removeCategory(category);
        }

        public void updateCategory(Category category)
        {
            efCategory.updateCategory(category);
        }

        public Category GetCategoryById(int id)
        {
            return efCategory.GetCategoryById(id);
        }
    }
}
