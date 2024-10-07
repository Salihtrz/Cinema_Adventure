using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DataAccessLayer.Context;
using EntityLayer.Class;
using DataAccessLayer.Managers;
using BusinessLayer.Services;

namespace Cinema_Adventure.Controllers
{
    public class AdminCategoriesController : Controller
    {
        CategoryService cs = new CategoryService(new DataAccessLayer.EntityFramework.EFCategory());
        CinemaDb _context = new CinemaDb();

        public async Task<IActionResult> Index()
        {
            if (HttpContext.Session.GetInt32("IsAdmin") == 1 ||
               HttpContext.Session.GetInt32("IsCategoryReadAccess") == 1 ||
               HttpContext.Session.GetInt32("IsCategoryWriteAccess") == 1)
            {
                return View(cs.GetAllCategories());
            }
            else
                return RedirectToAction(actionName: "Index", controllerName: "Home");
        }
        public async Task<IActionResult> Details(int id)
        {
            if (HttpContext.Session.GetInt32("IsAdmin") == 1 ||
               HttpContext.Session.GetInt32("IsCategoryReadAccess") == 1)
            {
                return View(cs.GetCategoryById(id));
            }
            else
                return RedirectToAction(actionName: "Index", controllerName: "Home");
        }
        public IActionResult Create()
        {
            if (HttpContext.Session.GetInt32("IsAdmin") == 1 ||
               HttpContext.Session.GetInt32("IsCategoryWriteAccess") == 1)
            {
                return View();
            }
            else
                return RedirectToAction(actionName: "Index", controllerName: "Home");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Category category)
        {
            if (ModelState.IsValid)
            {
                cs.addCategory(category);
                return RedirectToAction("Index");
            }
            return View();
        }

        public async Task<IActionResult> Edit(int id)
        {
            if (HttpContext.Session.GetInt32("IsAdmin") == 1 ||
               HttpContext.Session.GetInt32("IsCategoryWriteAccess") == 1)
            {
                return View(cs.GetCategoryById(id));
            }
            else
                return RedirectToAction(actionName: "Index", controllerName: "Home");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Category category)
        {
            if (ModelState.IsValid)
            {
                cs.updateCategory(category);
                return RedirectToAction("Index");
            }
            return View(category);
        }

        public async Task<IActionResult> Delete(int id)
        {
            if (HttpContext.Session.GetInt32("IsAdmin") == 1 ||
               HttpContext.Session.GetInt32("IsCategoryWriteAccess") == 1)
            {
                return View(cs.GetCategoryById(id));
            }
            else
                return RedirectToAction(actionName: "Index", controllerName: "Home");
        }

        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(int id)
        //{
        //    // Kategoriye ait olan tüm filmlerin kategori referanslarını null yap
        //    var relatedMovies = _context.Movies.Where(i => i.CategoryId == id);
        //    foreach (var movie in relatedMovies)
        //    {
        //        movie.CategoryId = null;
        //    }

        //    // Kategoriyi bul
        //    var category = await _context.Categorys.FindAsync(id);
        //    if (category == null)
        //    {
        //        return NotFound();
        //    }

        //    // Kategoriyi sil
        //    _context.Categorys.Remove(category);
        //    await _context.SaveChangesAsync();

        //    return RedirectToAction("Index");
        //}

    }
}
