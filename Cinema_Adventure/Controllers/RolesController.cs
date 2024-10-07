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

namespace Cinema_Adventure.Controllers
{
    public class RolesController : Controller
    {
        RoleManager rm = new RoleManager();
        public async Task<IActionResult> Index()
        {
            if (HttpContext.Session.GetInt32("IsAdmin") == 1)
            {
                return View(rm.GetAllRoles());
            }
            else
                return RedirectToAction(actionName: "Index", controllerName: "Home");
        }

        public async Task<IActionResult> Details(int id)
        {
            if (HttpContext.Session.GetInt32("IsAdmin") == 1)
            {
                return View(rm.getRoleById(id));
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
        public async Task<IActionResult> Create(Role role)
        {

            if (ModelState.IsValid)
            {
                rm.addRole(role);
                return RedirectToAction("Index");
            }
            return View();
        }

        public async Task<IActionResult> Edit(int id)
        {
            if (HttpContext.Session.GetInt32("IsAdmin") == 1)
            {
                return View(rm.getRoleById(id));
            }
            else
                return RedirectToAction(actionName: "Index", controllerName: "Home");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Role role)
        {
            if (ModelState.IsValid)
            {
                rm.updateRole(role);
                return RedirectToAction("Index");
            }
            return View();
        }

        public async Task<IActionResult> Delete(int id)
        {
            if (HttpContext.Session.GetInt32("IsAdmin") == 1)
            {
                return View(rm.getRoleById(id));
            }
            else
                return RedirectToAction(actionName: "Index", controllerName: "Home");
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Role role)
        {
            if (ModelState.IsValid)
            {
                rm.removeRole(role);
                return RedirectToAction("Index");
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
