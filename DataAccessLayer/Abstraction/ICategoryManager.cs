using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer.Class;

namespace DataAccessLayer.Abstraction
{
    public interface ICategoryManager<Category>
    {
        List<Category> GetAllCategories();
        Dictionary<Category, int> GetCategoriesWithMovieCounts();
		void addCategory(Category category);
        void removeCategory(Category category);
        void updateCategory(Category category);
        Category GetCategoryById(int id);
    }
}
