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
using Newtonsoft.Json;

namespace Cinema_Adventure.Controllers
{
    public class AboutUsController : Controller
    {
        AboutUsService aum = new AboutUsService(new DataAccessLayer.EntityFramework.EFAboutUs());
        CategoryService cm = new CategoryService(new DataAccessLayer.EntityFramework.EFCategory());
        public async Task<IActionResult> Index()
        {
            TempData["categorys"] = JsonConvert.SerializeObject(cm.GetAllCategories());
            ViewBag.CategoriesWithCounts = cm.GetCategoriesWithMovieCounts();
			return View(aum.getAboutUs());
        }
        
    }
}
