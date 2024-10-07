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
using Microsoft.Data.SqlClient;
using System.Drawing.Printing;
using Newtonsoft.Json;
using Utilities;

namespace Cinema_Adventure.Controllers
{
    public class MoviesController : Controller
    {
        MovieService mo = new MovieService(new DataAccessLayer.EntityFramework.EFMovie());
        CategoryService cm = new CategoryService(new DataAccessLayer.EntityFramework.EFCategory());

        public async Task<IActionResult> Index(string movieName, string sortOrder, string ratingRange, int? yearFrom, int? yearTo, int page = 1, int pageSize = 5)
        {
			TempData["categorys"] = JsonConvert.SerializeObject(cm.GetAllCategories());
			var movies = mo.GetAllMovies();
			movies = Utilities.FilterHelper.RangeFilter(ratingRange,movies);
			movies = Utilities.FilterHelper.YearFilter(yearFrom,yearTo,movies);
			movies = Utilities.FilterHelper.SearchFilter(movieName, movies);
			movies = Utilities.FilterHelper.SortFilter(sortOrder,movies);

			int totalMovies = movies.Count();
			var pagedMovies = movies.Skip((page - 1) * pageSize).Take(pageSize).ToList();

			ViewBag.CurrentPage = page;
			ViewBag.TotalPages = (int)Math.Ceiling((double)totalMovies / pageSize);
			ViewBag.PageSize = pageSize;
			ViewBag.TotalMovies = totalMovies;

			return View(pagedMovies);
        }

        public async Task<IActionResult> Details(int id, int page = 1, int pageSize = 5)
        {
            TempData["categorys"] = JsonConvert.SerializeObject(cm.GetAllCategories());
            var movies = mo.GetAllMoviesWithCategory().Where(i => i.MovieId == id).ToList();

            int totalMovies = movies.Count();
            var pagedMovies = movies.Skip((page - 1) * pageSize).Take(pageSize).ToList();

            ViewBag.CurrentPage = page;
            ViewBag.TotalPages = (int)Math.Ceiling((double)totalMovies / pageSize);
            ViewBag.PageSize = pageSize;
            ViewBag.TotalMovies = totalMovies;

            return View(pagedMovies);
        }
        public async Task<IActionResult> CategoryWithMovies(int id, string movieName, string sortOrder, string ratingRange, int? yearFrom, int? yearTo, int page=1, int pageSize=5)
        {
            TempData["categorys"] = JsonConvert.SerializeObject(cm.GetAllCategories());

			var movies = mo.GetAllMoviesWithCategory().Where(i => i.MovieCategories.Any(m => m.CategoryId == id)).ToList();
            var selectedCategory = cm.GetCategoryById(id);

			movies = Utilities.FilterHelper.RangeFilter(ratingRange, movies);
			movies = Utilities.FilterHelper.YearFilter(yearFrom, yearTo, movies);
			movies = Utilities.FilterHelper.SearchFilter(movieName, movies);
			movies = Utilities.FilterHelper.SortFilter(sortOrder, movies);

			int totalMovies = movies.Count();
            var pagedMovies = movies.Skip((page - 1) * pageSize).Take(pageSize).ToList();

            ViewBag.CurrentPage = page;
            ViewBag.TotalPages = (int)Math.Ceiling((double)totalMovies / pageSize);
            ViewBag.PageSize = pageSize;
            ViewBag.TotalMovies = totalMovies;

            ViewBag.selectedCategoryName = selectedCategory;

            return View(pagedMovies);
        }
    }
}
