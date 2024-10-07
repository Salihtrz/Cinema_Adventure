using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer.Class;
using DataAccessLayer.Abstraction;
using Microsoft.EntityFrameworkCore;
using DataAccessLayer.Context;

namespace DataAccessLayer.Managers
{
	public class MovieManager : IMovieManager<Movie>
	{
		CinemaDb CinemaDb = new CinemaDb();

		public void addMovie(Movie movie)
		{
			CinemaDb.Add(movie);
			CinemaDb.SaveChanges();
		}

		public List<Movie> GetAllMovies()
		{
			var movies = CinemaDb.Movies
				.Include(i => i.Reviews)
				.Include(i => i.MovieCasts)
					.ThenInclude(i => i.casts)
				.Include(i => i.MovieCategories)
					.ThenInclude(i => i.categorys)
				.ToList();

			foreach (var movie in movies)
			{
				movie.VideoLink = ExtractYoutubeVideoId(movie.VideoLink);
			}

			return movies;
		}
		private string ExtractYoutubeVideoId(string youtubeLink)
		{
			if (string.IsNullOrEmpty(youtubeLink))
				return string.Empty;

			try
			{
				if (youtubeLink.Contains("youtu.be"))
				{
					return youtubeLink.Split('/').Last();
				}
				else if (youtubeLink.Contains("youtube.com"))
				{
					var uri = new Uri(youtubeLink);
					var query = System.Web.HttpUtility.ParseQueryString(uri.Query);
					return query["v"];
				}
			}
			catch (UriFormatException)
			{
				return string.Empty;
			}

			return string.Empty;
		}
		public List<Movie> GetAllMoviesWithCategory()
		{
			var movie = CinemaDb.Set<Movie>()
				.Include(i => i.Reviews)
					.ThenInclude(i => i.users)
                .Include(i => i.MovieCasts)
					.ThenInclude(i => i.casts)
				.Include(i => i.MovieCategories)
					.ThenInclude(i => i.categorys)
				.ToList();
			return movie;
		}

        public void removeMovie(Movie movie)
		{
			CinemaDb.Remove(movie);
			CinemaDb.SaveChanges();
		}

		public void updateMovie(Movie movie)
		{
			CinemaDb.Update(movie);
			CinemaDb.SaveChanges();
		}

		public Movie GetMovieById(int id)
		{
			var FindCategory = CinemaDb.Set<Movie>()
				.Include(i => i.MovieCasts)
					.ThenInclude(i => i.casts)
				.Include(i => i.MovieCategories)
					.ThenInclude(i => i.categorys)
				.FirstOrDefault(x => x.MovieId == id);
			return FindCategory;

		}
        public void addMovieCast(MovieCast movieCast)
        {
            CinemaDb.Add(movieCast);
            CinemaDb.SaveChanges();
        }
        public void updateMovieCast(MovieCast movieCast)
        {
            CinemaDb.Update(movieCast);
            CinemaDb.SaveChanges();
        }
		public List<MovieCast> FindRelatedCast(int id)
		{
			var FindRelatedCast = CinemaDb.Set<MovieCast>().Where(i => i.MovieId == id).ToList();
			return FindRelatedCast;
		}
		public void removeRelatedCast(MovieCast movieCast)
		{
			CinemaDb.Remove(movieCast);
			CinemaDb.SaveChanges();
		}
		public void addMovieCategory(MovieCategory movieCategory)
		{
			CinemaDb.Add(movieCategory);
			CinemaDb.SaveChanges();
		}

        public void removeRelatedCategory(MovieCategory movieCategory)
        {
            CinemaDb.Remove(movieCategory);
			CinemaDb.SaveChanges();
        }

        public void updateMovieCategory(MovieCategory movieCategory)
        {
            CinemaDb.Update(movieCategory);
			CinemaDb.SaveChanges();
        }

        public List<MovieCategory> FindRelatedCategory(int id)
        {
            var FindRelatedCategory = CinemaDb.Set<MovieCategory>().Where(i => i.MovieId ==id).ToList();
			return FindRelatedCategory;
        }
    }
}
