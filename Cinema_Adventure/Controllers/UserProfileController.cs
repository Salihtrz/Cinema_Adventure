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
using Newtonsoft.Json;

namespace Cinema_Adventure.Controllers
{
    public class UserProfileController : Controller
    {
		UserService us = new UserService(new DataAccessLayer.EntityFramework.EfUser());
		CategoryService cm = new CategoryService(new DataAccessLayer.EntityFramework.EFCategory());

		public async Task<IActionResult> Index(int? id)
        {
            var userId = HttpContext.Session.GetInt32("UserId");
            if(userId != null)
            {
                id = userId;
            }
			TempData["categorys"] = JsonConvert.SerializeObject(cm.GetAllCategories());
            var user = us.getAllUsers().Where(i => i.UserID == id).FirstOrDefault();
			return View(user);
        }

        public async Task<IActionResult> Details(int? id)
        {
            return View();
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(User user)
        {
            return View(user);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(User user)
        {
            var userıd = HttpContext.Session.GetInt32("UserId");
            var User = us.getUserById((int)userıd);
            if(ModelState.IsValid)
            {
                if(User != null)
                {
					User.UserName = user.UserName;
					User.UserSurname = user.UserSurname;
					User.UserEmail = user.UserEmail;
                    User.BirthDate = user.BirthDate;
                    User.Password = user.Password;
                    User.RoleId = user.RoleId;
				}
                us.updateUser(User);
                return RedirectToAction("Index");
            }
            return View();
        }

        public async Task<IActionResult> Delete(int? id)
        {
            return View();
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            return RedirectToAction(nameof(Index));
        }
    }
}
