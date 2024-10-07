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
	public class AdminMoviesController : Controller
	{
		MovieService mo = new MovieService(new DataAccessLayer.EntityFramework.EFMovie());
		CategoryService cas = new CategoryService(new DataAccessLayer.EntityFramework.EFCategory());
		CastService cs = new CastService(new DataAccessLayer.EntityFramework.EFCast());

		public async Task<IActionResult> Index()
		{
			if (HttpContext.Session.GetInt32("IsAdmin") == 1 ||
			   HttpContext.Session.GetInt32("IsMovieReadAccess") == 1 ||
			   HttpContext.Session.GetInt32("IsMovieWriteAccess") == 1)
			{
				return View(mo.GetAllMoviesWithCategory());
			}
			else
				return RedirectToAction(actionName: "Index", controllerName: "Home");
		}

		public async Task<IActionResult> Details(int id)
		{
			if (HttpContext.Session.GetInt32("IsAdmin") == 1 ||
			   HttpContext.Session.GetInt32("IsMovieReadAccess") == 1)
			{
				return View(mo.GetMovieByID(id));
			}
			else
				return RedirectToAction(actionName: "Index", controllerName: "Home");
		}

		public IActionResult Create()
		{
			if (HttpContext.Session.GetInt32("IsAdmin") == 1 ||
			   HttpContext.Session.GetInt32("IsMovieWriteAccess") == 1)
			{
				{
					var casts = cs.GetAllCasts();
					var categories = cas.GetAllCategories();

					var castList = casts.Select(c => new SelectListItem
					{
						Value = c.CastId.ToString(),
						Text = $"{c.CastName} {c.CastSurname}"
					});
					var categoryList = categories.Select(c => new SelectListItem
					{
						Value = c.CategoryId.ToString(),
						Text = $"{c.CategoryName}"
					});
					ViewData["CastId"] = new SelectList(castList, "Value", "Text");
					ViewData["CategoryId"] = new SelectList(categoryList, "Value", "Text");
					return View();
				}
			}
			else
				return RedirectToAction(actionName: "Index", controllerName: "Home");
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Create(Movie movie, List<int> selectedCastId, List<int> selectedCategoryId)
		{
			var casts = cs.GetAllCasts();
			var categories = cas.GetAllCategories();

			if (ModelState.IsValid)
			{
				mo.addMovie(movie);
				foreach (int castId in selectedCastId)
				{
					var movieCast = new MovieCast { MovieId = movie.MovieId, CastId = castId };
					mo.addMovieCast(movieCast);
				}
				foreach (int categoryId in selectedCategoryId)
				{
					var movieCategory = new MovieCategory { MovieId = movie.MovieId, CategoryId = categoryId };
					mo.addMovieCategory(movieCategory);
				}

				var castList = casts.Select(c => new SelectListItem
				{
					Value = c.CastId.ToString(),
					Text = $"{c.CastName} {c.CastSurname}"
				});
				var categoryList = categories.Select(c => new SelectListItem
				{
					Value = c.CategoryId.ToString(),
					Text = $"{c.CategoryName}"
				});

				ViewData["CastId"] = new SelectList(castList, "Value", "Text");
				ViewData["CategoryId"] = new SelectList(categoryList, "Value", "Text");
				return RedirectToAction("Index");
			}
			return View(movie);
		}

		public async Task<IActionResult> Edit(int id)
		{
			if (HttpContext.Session.GetInt32("IsAdmin") == 1 ||
			   HttpContext.Session.GetInt32("IsMovieWriteAccess") == 1)
			{
				var casts = cs.GetAllCasts();
				var categories = cas.GetAllCategories();

				var castList = casts.Select(c => new SelectListItem
				{
					Value = c.CastId.ToString(),
					Text = $"{c.CastName} {c.CastSurname}"
				});
				var categoryList = categories.Select(c => new SelectListItem
				{
					Value = c.CategoryId.ToString(),
					Text = $"{c.CategoryName}"
				});
				ViewData["CastId"] = new SelectList(castList, "Value", "Text");
				ViewData["CategoryId"] = new SelectList(categoryList, "Value", "Text");
				return View(mo.GetMovieByID(id));
			}
			else
				return RedirectToAction(actionName: "Index", controllerName: "Home");
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Edit(Movie movie, List<int> selectedCastId, List<int> selectedCategoryId)
		{
			var categories = cas.GetAllCategories();
			var casts = cs.GetAllCasts();
			if (ModelState.IsValid)
			{
				mo.updateMovie(movie);
				if (selectedCastId.Count > 0)
				{
					var RelatedCast = mo.FindRelatedCast(movie.MovieId);
					foreach (var cast in RelatedCast)
					{
						mo.removeRelatedCast(cast);
					}
				}
				if (selectedCategoryId.Count > 0)
				{
					var RelatedCategory = mo.FindRelatedCategory(movie.MovieId);
					foreach (var category in RelatedCategory)
					{
						mo.removeRelatedCategory(category);
					}
				}
				foreach (int castId in selectedCastId)
				{
					var movieCast = new MovieCast { MovieId = movie.MovieId, CastId = castId };
					mo.updateMovieCast(movieCast);
				}
				foreach (int categoryId in selectedCategoryId)
				{
					var movieCategory = new MovieCategory { MovieId = movie.MovieId, CategoryId = categoryId };
					mo.addMovieCategory(movieCategory);
				}

				var castList = casts.Select(c => new SelectListItem
				{
					Value = c.CastId.ToString(),
					Text = $"{c.CastName} {c.CastSurname}"
				});
				var categoryList = categories.Select(c => new SelectListItem
				{
					Value = c.CategoryId.ToString(),
					Text = $"{c.CategoryName}"
				});
				ViewData["CastId"] = new SelectList(castList, "Value", "Text");
				ViewData["CategoryId"] = new SelectList(cas.GetAllCategories(), "CategoryId", "CategoryName");
				return RedirectToAction("Index");
			}
			return View(movie);
		}

		public async Task<IActionResult> Delete(int id)
		{
			if (HttpContext.Session.GetInt32("IsAdmin") == 1 ||
			   HttpContext.Session.GetInt32("IsMovieWriteAccess") == 1)
			{
				return View(mo.GetMovieByID(id));
			}
			else
				return RedirectToAction(actionName: "Index", controllerName: "Home");
		}

		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> DeleteConfirmed(Movie movie)
		{
			if (ModelState.IsValid)
			{
				var RelatedCast = mo.FindRelatedCast(movie.MovieId);
				foreach (var cast in RelatedCast)
				{
					mo.removeRelatedCast(cast);
				}
				var RelatedCategory = mo.FindRelatedCategory(movie.MovieId);
				foreach (var category in RelatedCategory)
				{
					mo.removeRelatedCategory(category);
				}
				mo.removeMovie(movie);
				return RedirectToAction("Index");
			}
			return RedirectToAction(nameof(Index));
		}
	}
}
