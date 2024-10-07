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
    public class AdminAboutUsController : Controller
    {
        AboutUsService aum = new AboutUsService(new DataAccessLayer.EntityFramework.EFAboutUs());

        public async Task<IActionResult> Index()
        {
            if (HttpContext.Session.GetInt32("IsAdmin") == 1)
            {
                return View(aum.getAboutUs());
            }
            else
                return RedirectToAction(actionName: "Index", controllerName: "Home");
        }

        public async Task<IActionResult> Details()
        {
            if (HttpContext.Session.GetInt32("IsAdmin") == 1)
            {
                return View(aum.getAboutUs());
            }
            else
                return RedirectToAction(actionName: "Index", controllerName: "Home");
        }

        public IActionResult Create()
        {
            if (HttpContext.Session.GetInt32("IsAdmin") == 1)
            {
                return View();
            }
            else
                return RedirectToAction(actionName: "Index", controllerName: "Home");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(AboutUs aboutUs)
        {
            if (ModelState.IsValid)
            {
                aum.addAboutUs(aboutUs);
                return RedirectToAction("Index");
            }
            return View();
        }

        public async Task<IActionResult> Edit()
        {
            if (HttpContext.Session.GetInt32("IsAdmin") == 1)
            {
                return View(aum.getAboutUs());
            }
            else
                return RedirectToAction(actionName: "Index", controllerName: "Home");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(AboutUs aboutUs)
        {
            if (ModelState.IsValid)
            {
                aum.updateAboutUs(aboutUs);
                return RedirectToAction("Index");
            }
            return View(aboutUs);
        }
        public async Task<IActionResult> Delete()
        {
            if (HttpContext.Session.GetInt32("IsAdmin") == 1)
            {
                return View(aum.getAboutUs());
            }
            else
                return RedirectToAction(actionName: "Index", controllerName: "Home");
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(AboutUs aboutUs)
        {
            if (ModelState.IsValid)
            {
                aum.removeAbousUs(aboutUs);
                return RedirectToAction("Index");
            }
            return RedirectToAction(nameof(Index));
        }

    }
}
