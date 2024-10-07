using Microsoft.AspNetCore.Http;
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
    public class UsersController : Controller
    {
        UserService us = new UserService(new DataAccessLayer.EntityFramework.EfUser());
        RoleService rs = new RoleService(new DataAccessLayer.EntityFramework.EFRole());

        public async Task<IActionResult> Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(User model)
        {
            var user = us.Login(model.UserEmail, model.Password);
            if(user == null)
            {
                return View();
            }

            HttpContext.Session.SetInt32("UserId", user.UserID);
            HttpContext.Session.SetString("UserName", user.UserName);
            HttpContext.Session.SetString("UserSurname", user.UserSurname);
            HttpContext.Session.SetString("UserFullname", string.Format("{0} {1}", user.UserName, user.UserSurname));
            HttpContext.Session.SetString("UserEmail", user.UserEmail);
            HttpContext.Session.SetInt32("IsAdmin", user.roles.IsAdmin == true ? 1 : 0);
            HttpContext.Session.SetInt32("IsUser", user.roles.IsUser == true ? 1 : 0);
            HttpContext.Session.SetInt32("IsCategoryReadAccess", user.roles.IsCategoryReadAccess == true ? 1 : 0);
            HttpContext.Session.SetInt32("IsCategoryWriteAccess", user.roles.IsCategoryWriteAccess == true ? 1 : 0);
            HttpContext.Session.SetInt32("IsMovieReadAccess", user.roles.IsMovieReadAccess == true ? 1 : 0);
            HttpContext.Session.SetInt32("IsMovieWriteAccess", user.roles.IsMovieWriteAccess == true ? 1 : 0);
			HttpContext.Session.SetInt32("IsNewsReadAccess", user.roles.IsNewsReadAccess == true ? 1 : 0);
			HttpContext.Session.SetInt32("IsNewsWriteAccess", user.roles.IsNewsWriteAccess == true ? 1 : 0);
			HttpContext.Session.SetInt32("IsCastReadAccess", user.roles.IsCastReadAccess == true ? 1 : 0);
			HttpContext.Session.SetInt32("IsCastWriteAccess", user.roles.IsCastWriteAccess == true ? 1 : 0);
			HttpContext.Session.SetInt32("IsReviewsReadAccess", user.roles.IsReviewsReadAccess == true ? 1 : 0);
			HttpContext.Session.SetInt32("IsReviewsWriteAccess", user.roles.IsReviewsWriteAccess == true ? 1 : 0);
			HttpContext.Session.SetInt32("IsReview_NewsReadAccess", user.roles.IsReview_NewsReadAccess == true ? 1 : 0);
			HttpContext.Session.SetInt32("IsReview_NewsWriteAccess", user.roles.IsReview_NewsWriteAccess == true ? 1 : 0);

			if (HttpContext.Session.GetInt32("IsUser") == 1)
            {
                return RedirectToAction(actionName: "Index", controllerName: "Home");
            }
            return RedirectToAction(actionName: "AdminIndex", controllerName: "Home");
        }
        public async Task<IActionResult> Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(User user)
        {
            
            return View();
        }
        public async Task<IActionResult> Index()
        {
            if (HttpContext.Session.GetInt32("IsAdmin") == 1)
            {
                return View(us.getUserWithRole());
            }
            else
                return RedirectToAction(actionName: "Index", controllerName: "Home");
        }

        public async Task<IActionResult> Details(int id)
        {
            if (HttpContext.Session.GetInt32("IsAdmin") == 1)
            {
                return View(us.getUserById(id));
            }
            else
                return RedirectToAction(actionName: "Index", controllerName: "Home");
        }

        public IActionResult Create()
        {
            if (HttpContext.Session.GetInt32("IsAdmin") == 1)
            {
                ViewData["RoleId"] = new SelectList(rs.GetAllRoles(), "RoleId", "RoleName");
            return View();
            }
            else
                return RedirectToAction(actionName: "Index", controllerName: "Home");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(User user)
        {
            if (HttpContext.Session.GetInt32("IsAdmin") == 1)
            {
                if (ModelState.IsValid)
            {
                us.addUser(user);
                return RedirectToAction("Index");
            }
            return View(user);
            }
            else
                return RedirectToAction(actionName: "Index", controllerName: "Home");
        }

        public async Task<IActionResult> Edit(int id)
        {
            if (HttpContext.Session.GetInt32("IsAdmin") == 1)
            {
                ViewData["RoleId"] = new SelectList(rs.GetAllRoles(), "RoleId", "RoleName");
            return View(us.getUserById(id));
                }
            else
                return RedirectToAction(actionName: "Index", controllerName: "Home");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(User user)
        {
            if (ModelState.IsValid)
            {
                us.updateUser(user);
                return RedirectToAction("Index");
            }
            return View();
        }

        public async Task<IActionResult> Delete(int id)
        {
            return View(us.getUserById(id));
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(User user)
        {
            if (ModelState.IsValid)
            {
                us.removeUser(user);
                return RedirectToAction("Index");
            }
            return RedirectToAction(nameof(Index));
        }

        //private bool UserExists(int id)
        //{
        //    return rm.Users.Any(e => e.UserID == id);
        //}
    }
}
