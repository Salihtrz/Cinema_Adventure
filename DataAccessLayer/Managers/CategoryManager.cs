using DataAccessLayer.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer.Class;
using DataAccessLayer.Context;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Managers
{
    public class CategoryManager : ICategoryManager<Category>
    {
        CinemaDb CinemaDb = new CinemaDb();
        public void addCategory(Category category)
        {
            CinemaDb.Add(category);
            CinemaDb.SaveChanges();
        }

        public List<Category> GetAllCategories()
        {
            return CinemaDb.Set<Category>().ToList();
        }
        public Dictionary<Category, int> GetCategoriesWithMovieCounts()
        {
            var categories = CinemaDb.Categorys.ToList();
            var categoryCounts = new Dictionary<Category, int>();

            foreach (var category in categories)
            {
                if (category != null)
                {
                    var count = CinemaDb.Movies
                        .Include(m => m.MovieCategories)
                            .ThenInclude(mc => mc.categorys)
                        .Count(m => m.MovieCategories.Any(mc => mc.categorys.CategoryId == category.CategoryId));
                    categoryCounts.Add(category, count);
                }
            }

            return categoryCounts;
        }

        public void removeCategory(Category category)
        {
            CinemaDb.Remove(category);
            CinemaDb.SaveChanges();
        }

        public void updateCategory(Category category)
        {
            CinemaDb.Update(category);
            CinemaDb.SaveChanges();
        }

        public Category GetCategoryById(int id)
        {
            return CinemaDb.Categorys.Find(id);
        }
    }
}
