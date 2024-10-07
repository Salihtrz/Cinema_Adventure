using BusinessLayer.Services;
using Cinema_Adventure.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;

namespace Cinema_Adventure.Controllers
{
    public class HomeController : Controller
    {
		MovieService mo = new MovieService(new DataAccessLayer.EntityFramework.EFMovie());
		CategoryService cm = new CategoryService(new DataAccessLayer.EntityFramework.EFCategory());
		NewsService ns = new NewsService(new DataAccessLayer.EntityFramework.EFNews());

        public IActionResult Index()
        {
			//TempData["categorys"] = cm.GetAllCategories();
			TempData["categorys"] = JsonConvert.SerializeObject(cm.GetAllCategories());
			var latestNews = ns.GetAllNews().OrderByDescending(n => n.SendingDate).Take(4).ToList();
			ViewBag.News = latestNews;
			return View(mo.GetAllMovies());
		}
        public IActionResult AdminIndex()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}