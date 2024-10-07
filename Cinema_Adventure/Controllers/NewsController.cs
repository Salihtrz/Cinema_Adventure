using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DataAccessLayer.Context;
using EntityLayer.Class;
using BusinessLayer.Services;
using System.Drawing.Printing;
using Newtonsoft.Json;

namespace Cinema_Adventure.Controllers
{
    public class NewsController : Controller
    {
        NewsService ns = new NewsService(new DataAccessLayer.EntityFramework.EFNews());
        CategoryService cm = new CategoryService(new DataAccessLayer.EntityFramework.EFCategory());
        public async Task<IActionResult> Index(string newsname, int page=1, int pageSize=5)
        {
            TempData["categorys"] = JsonConvert.SerializeObject(cm.GetAllCategories());
            ViewBag.CategoriesWithCounts = cm.GetCategoriesWithMovieCounts();
			var news = ns.GetAllNews();
            news = Utilities.FilterHelper.SearchFilter2(newsname, news);

			int totalNews = news.Count();
			var pagedNews = news.Skip((page - 1) * pageSize).Take(pageSize).ToList();

			ViewBag.CurrentPage = page;
			ViewBag.TotalPages = (int)Math.Ceiling((double)totalNews / pageSize);
			ViewBag.PageSize = pageSize;
			ViewBag.TotalMovies = totalNews;
			return View(pagedNews);
        }


        public async Task<IActionResult> Details(int id)
        {
            TempData["categorys"] = JsonConvert.SerializeObject(cm.GetAllCategories());
            ViewBag.CategoriesWithCounts = cm.GetCategoriesWithMovieCounts();
            var news = ns.GetAllNews().Where(i => i.NewsId == id);
			return View(news);
        }
    }
}
