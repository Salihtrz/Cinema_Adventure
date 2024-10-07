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
    public class AdminReview_NewsController : Controller
    {
        Review_NewsService rns = new Review_NewsService(new DataAccessLayer.EntityFramework.EFReview_News());

        public async Task<IActionResult> Index()
        {
            if (HttpContext.Session.GetInt32("IsAdmin") == 1 ||
               HttpContext.Session.GetInt32("IsReview_NewsReadAccess") == 1 ||
               HttpContext.Session.GetInt32("IsReview_NewsWriteAccess") == 1)
            {
                return View(rns.GetAllReview_News());
            }
            else
                return RedirectToAction(actionName: "Index", controllerName: "Home");
        }

        public async Task<IActionResult> Details(int id)
        {
            if (HttpContext.Session.GetInt32("IsAdmin") == 1 ||
               HttpContext.Session.GetInt32("IsReview_NewsReadAccess") == 1 ||
               HttpContext.Session.GetInt32("IsReview_NewsWriteAccess") == 1)
            {
                return View(rns.GetReview_NewsById(id));
            }
            else
                return RedirectToAction(actionName: "Index", controllerName: "Home");
        }

        public async Task<IActionResult> PendingReviews()
        {
            if (HttpContext.Session.GetInt32("IsAdmin") == 1 ||
               HttpContext.Session.GetInt32("IsReview_NewsReadAccess") == 1 ||
               HttpContext.Session.GetInt32("IsReview_NewsWriteAccess") == 1)
            {
                var PendingReviews = rns.GetAllReview_News().Where(i => i.Visibility == false && i.State == false).ToList();
            return View(PendingReviews);
            }
            else
                return RedirectToAction(actionName: "Index", controllerName: "Home");
        }

        public async Task<IActionResult> ApproveReviews(int id)
        {
            var review = rns.GetReview_NewsById(id);
            if (ModelState.IsValid)
            {
                review.State = true;
                review.Visibility = true;
                rns.updateReview_News(review);
            }
            return RedirectToAction("PendingReviews");
        }

        public async Task<IActionResult> ListApprovedReviews()
        {
            if (HttpContext.Session.GetInt32("IsAdmin") == 1 ||
               HttpContext.Session.GetInt32("IsReview_NewsReadAccess") == 1 ||
               HttpContext.Session.GetInt32("IsReview_NewsWriteAccess") == 1)
            {
                var ApprovedReviews = rns.GetAllReview_News().Where(i => i.Visibility == true && i.State == true).ToList();
            return View(ApprovedReviews);
            }
            else
                return RedirectToAction(actionName: "Index", controllerName: "Home");
        }

        public async Task<IActionResult> RejectReviews(int id)
        {
            var review = rns.GetReview_NewsById(id);
            if (ModelState.IsValid)
            {
                review.State = true;
                review.Visibility = false;
                rns.updateReview_News(review);
            }
            return RedirectToAction("PendingReviews");
        }

        public async Task<IActionResult> ListRejectedReviews()
        {
            if (HttpContext.Session.GetInt32("IsAdmin") == 1 ||
               HttpContext.Session.GetInt32("IsReview_NewsReadAccess") == 1 ||
               HttpContext.Session.GetInt32("IsReview_NewsWriteAccess") == 1)
            {
                var RejectedReviews = rns.GetAllReview_News().Where(i => i.State == true && i.Visibility == false).ToList();
            return View(RejectedReviews);
            }
            else
                return RedirectToAction(actionName: "Index", controllerName: "Home");
        }

        public async Task<IActionResult> UndoReview(int id)
        {
            var review = rns.GetReview_NewsById(id);
            if (ModelState.IsValid)
            {
                review.State = false;
                review.Visibility = false;
                rns.updateReview_News(review);
            }
            return RedirectToAction("PendingReviews");
        }
        public async Task<IActionResult> Edit(int id)
        {
            if (HttpContext.Session.GetInt32("IsAdmin") == 1 ||
               HttpContext.Session.GetInt32("IsReview_NewsReadAccess") == 1 ||
               HttpContext.Session.GetInt32("IsReview_NewsWriteAccess") == 1)
            {
                return View(rns.GetReview_NewsById(id));
            }
            else
                return RedirectToAction(actionName: "Index", controllerName: "Home");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Review_News review_News)
        {
            if (ModelState.IsValid)
            {
                rns.updateReview_News(review_News);
                return RedirectToAction("Index");
            }
            return View(review_News);
        }

    }
}
