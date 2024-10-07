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
    public class ReviewsController : Controller
    {
        ReviewService rm = new ReviewService(new DataAccessLayer.EntityFramework.EFReview());
        UserService us = new UserService(new DataAccessLayer.EntityFramework.EfUser());

        public async Task<IActionResult> Index()
        {
            return View();
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
        public async Task<IActionResult> Create(Review review)
        {
            var userId = HttpContext.Session.GetInt32("UserId");
            if (userId != null)
            {
                review.UserID = userId;
                review.SendingDate = DateTime.Now;

				if (BannedWords.ContainsBannedWord(review.ReviewContent))
				{
					review.State = false;
                    review.Visibility = false;
				}
				else
				{
					review.State = true;
                    review.Visibility = true;
				}

				if (ModelState.IsValid)
                {
                    if(review.State == true && review.Visibility == true)
                    {
                        rm.addReview(review);
                        return RedirectToAction("Details", "Movies", new { id = review.MovieId });
					}
                    
                }
            }
            else
            {
                return RedirectToAction("Index", "Movies");
            }
            return RedirectToAction("Index", "Movies");
        }

        public async Task<IActionResult> Edit(int? id)
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Review review)
        {
            return View(review);
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
