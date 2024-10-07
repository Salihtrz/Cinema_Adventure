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
using Utilities;

namespace Cinema_Adventure.Controllers
{
    public class Review_NewsController : Controller
    {
        Review_NewsService rns = new Review_NewsService(new DataAccessLayer.EntityFramework.EFReview_News());
        UserService us = new UserService(new DataAccessLayer.EntityFramework.EfUser());

        public async Task<IActionResult> Index()
        {
            return View();
        }

        public async Task<IActionResult> Details(int id)
        {
            return View();
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Review_News review_News)
        {
            var userId = HttpContext.Session.GetInt32("UserId");
            if(userId != null)
            {
                review_News.UserID = userId;
                review_News.SendingDate = DateTime.Now;
                if (BannedWords.ContainsBannedWord(review_News.ReviewContent))
                {
                    review_News.State = false;
                    review_News.Visibility = false;
                }
                else
                {
                    review_News.State = true;
                    review_News.Visibility = true;
                }
                if (ModelState.IsValid)
                {
                    if(review_News.State == true && review_News.Visibility == true)
                    {
                        rns.addReview_News(review_News);
                        return RedirectToAction("Details","News", new {id = review_News.NewsId});
                    }
                }
            }
            else
            {
                return RedirectToAction("Details", "News", new { id = review_News.NewsId });
            }
            return RedirectToAction("Details", "News", new { id = review_News.NewsId });
        }

        public async Task<IActionResult> Edit(int? id)
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Review_News review_News)
        {
            return View(review_News);
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
