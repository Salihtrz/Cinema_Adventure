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
    public class CastsController : Controller
    {
        CastService cm = new CastService(new DataAccessLayer.EntityFramework.EFCast());

        public async Task<IActionResult> Index()
        {
            if (HttpContext.Session.GetInt32("IsAdmin") == 1 ||
               HttpContext.Session.GetInt32("IsCastReadAccess") == 1 ||
               HttpContext.Session.GetInt32("IsCastWriteAccess") == 1)
            {
                return View(cm.GetAllCasts());
            }
            else
                return RedirectToAction(actionName: "Index", controllerName: "Home");
        }
        public async Task<IActionResult> Details(int id)
        {
            if (HttpContext.Session.GetInt32("IsAdmin") == 1 ||
               HttpContext.Session.GetInt32("IsCastReadAccess") == 1)
            {
                return View(cm.GetCastById(id));
            }
            else
                return RedirectToAction(actionName: "Index", controllerName: "Home");
        }
        public IActionResult Create()
        {
            if (HttpContext.Session.GetInt32("IsAdmin") == 1 ||
               HttpContext.Session.GetInt32("IsCastWriteAccess") == 1)
            {
                return View();
            }
            else
                return RedirectToAction(actionName: "Index", controllerName: "Home");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Cast cast)
        {
            if (ModelState.IsValid)
            {
                cm.addCast(cast);
                return RedirectToAction("Index");
            }
            return View();
        }

        public async Task<IActionResult> Edit(int id)
        {
            if (HttpContext.Session.GetInt32("IsAdmin") == 1 ||
               HttpContext.Session.GetInt32("IsCastWriteAccess") == 1)
            {
                return View(cm.GetCastById(id));
            }
            else
                return RedirectToAction(actionName: "Index", controllerName: "Home");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Cast cast)
        {
            if (ModelState.IsValid)
            {
                cm.updateCast(cast);
                return RedirectToAction("Index");
            }
            return View();
        }

        public async Task<IActionResult> Delete(int id)
        {
            if (HttpContext.Session.GetInt32("IsAdmin") == 1 ||
               HttpContext.Session.GetInt32("IsCastWriteAccess") == 1)
            {
                return View(cm.GetCastById(id));
            }
            else
                return RedirectToAction(actionName: "Index", controllerName: "Home");
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Cast cast)
        {
            if (ModelState.IsValid)
            {
                cm.removeCast(cast);
                return RedirectToAction("Index");
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
