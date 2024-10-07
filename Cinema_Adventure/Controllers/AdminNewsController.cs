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

namespace Cinema_Adventure.Controllers
{
    public class AdminNewsController : Controller
    {
        NewsService ns = new NewsService(new DataAccessLayer.EntityFramework.EFNews());
        public async Task<IActionResult> Index()
        {
            if (HttpContext.Session.GetInt32("IsAdmin") == 1 ||
               HttpContext.Session.GetInt32("IsNewsReadAccess") == 1 ||
               HttpContext.Session.GetInt32("IsNewsWriteAccess") == 1)
            {
                return View(ns.GetAllNews());
            }
            else
                return RedirectToAction(actionName: "Index", controllerName: "Home");
        }

        public async Task<IActionResult> Details(int id)
        {
            if (HttpContext.Session.GetInt32("IsAdmin") == 1 ||
               HttpContext.Session.GetInt32("IsNewsReadAccess") == 1)
            {
                return View(ns.GetNewsById(id));
            }
            else
                return RedirectToAction(actionName: "Index", controllerName: "Home");
        }

        public IActionResult Create()
        {
            if (HttpContext.Session.GetInt32("IsAdmin") == 1 ||
               HttpContext.Session.GetInt32("IsNewsWriteAccess") == 1)
            {
                return View();
            }
            else
                return RedirectToAction(actionName: "Index", controllerName: "Home");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(News news)
        {
            if (ModelState.IsValid)
            {
                ns.addNews(news);
                return RedirectToAction("Index");
            }
            return View();
        }

        public async Task<IActionResult> Edit(int id)
        {
            if (HttpContext.Session.GetInt32("IsAdmin") == 1 ||
               HttpContext.Session.GetInt32("IsNewsWriteAccess") == 1)
            {
                return View(ns.GetNewsById(id));
            }
            else
                return RedirectToAction(actionName: "Index", controllerName: "Home");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(News news)
        {
            if (ModelState.IsValid)
            {
                ns.updateNews(news);
                return RedirectToAction("Index");
            }
            return View(news);
        }

        public async Task<IActionResult> Delete(int id)
        {
            if (HttpContext.Session.GetInt32("IsAdmin") == 1 ||
               HttpContext.Session.GetInt32("IsNewsWriteAccess") == 1)
            {
                return View(ns.GetNewsById(id));
            }
            else
                return RedirectToAction(actionName: "Index", controllerName: "Home");
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(News news)
        {
            if (ModelState.IsValid)
            {
                ns.removeNews(news);
                return RedirectToAction("Index");
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
