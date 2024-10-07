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
    public class AdminReviewsController : Controller
    {
        ReviewService rm = new ReviewService(new DataAccessLayer.EntityFramework.EFReview());
        public async Task<IActionResult> Index()
        {
            if (HttpContext.Session.GetInt32("IsAdmin") == 1 ||
               HttpContext.Session.GetInt32("IsReviewsReadAccess") == 1 ||
               HttpContext.Session.GetInt32("IsReviewsWriteAccess") == 1)
            {
                return View(rm.GetAllReviews());
            }
            else
                return RedirectToAction(actionName: "Index", controllerName: "Home");
        }

        public async Task<IActionResult> Details(int id)
        {
            if (HttpContext.Session.GetInt32("IsAdmin") == 1 ||
               HttpContext.Session.GetInt32("IsReviewsReadAccess") == 1 ||
               HttpContext.Session.GetInt32("IsReviewsWriteAccess") == 1)
            {
                return View(rm.GetReviewById(id));
            }
            else
                return RedirectToAction(actionName: "Index", controllerName: "Home");
        }

        public async Task<IActionResult> PendingReviews()
        {
            if (HttpContext.Session.GetInt32("IsAdmin") == 1 ||
               HttpContext.Session.GetInt32("IsReviewsReadAccess") == 1 ||
               HttpContext.Session.GetInt32("IsReviewsWriteAccess") == 1)
            {
                var pendingReviews = rm.GetAllReviews().Where(i => i.State == false && i.Visibility == false).ToList();
            return View(pendingReviews);
            }
            else
                return RedirectToAction(actionName: "Index", controllerName: "Home");
        }

        public async Task<IActionResult> ApproveReviews(int id)
        {
            var review = rm.GetReviewById(id);
            if(review != null)
            {
                review.State = true;
                review.Visibility = true;
                rm.updateReview(review);
            }
            return RedirectToAction("PendingReviews");
        }
        public async Task<IActionResult> ListApprovedReviews()
        {
            if (HttpContext.Session.GetInt32("IsAdmin") == 1 ||
               HttpContext.Session.GetInt32("IsReviewsReadAccess") == 1 ||
               HttpContext.Session.GetInt32("IsReviewsWriteAccess") == 1)
            {
                var approvedReviews = rm.GetAllReviews().Where(i => i.State == true && i.Visibility == true).ToList();
            return View(approvedReviews);
            }
            else
                return RedirectToAction(actionName: "Index", controllerName: "Home");
        }

        public async Task<IActionResult> RejectReviews(int id)
        {
            var review = rm.GetReviewById(id);
            if(review != null)
            {
                review.State = true;
                review.Visibility = false;
                rm.updateReview(review);
            }
            return RedirectToAction("PendingReviews");
        }
        public async Task<IActionResult> ListRejectedReviews()
        {
            if (HttpContext.Session.GetInt32("IsAdmin") == 1 ||
               HttpContext.Session.GetInt32("IsReviewsReadAccess") == 1 ||
               HttpContext.Session.GetInt32("IsReviewsWriteAccess") == 1)
            {
                var approvedReviews = rm.GetAllReviews().Where(i => i.State == true && i.Visibility == false).ToList();
            return View(approvedReviews);
            }
            else
                return RedirectToAction(actionName: "Index", controllerName: "Home");
        }
        public async Task<IActionResult> UndoReview(int id)
        {
            var review = rm.GetReviewById(id);
            if(review != null)
            {
                review.State = false;
                review.Visibility = false;
                rm.updateReview(review);
            }
            return RedirectToAction("PendingReviews");
        }
        public async Task<IActionResult> Edit(int id)
        {
            if (HttpContext.Session.GetInt32("IsAdmin") == 1 ||
               HttpContext.Session.GetInt32("IsReviewsReadAccess") == 1 ||
               HttpContext.Session.GetInt32("IsReviewsWriteAccess") == 1)
            {
                return View(rm.GetReviewById(id));
            }
            else
                return RedirectToAction(actionName: "Index", controllerName: "Home");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Review review)
        {
            if(ModelState.IsValid)
            { 
                rm.updateReview(review);
                return RedirectToAction("Index");
            }
            return View(review);
        }
    }
}
