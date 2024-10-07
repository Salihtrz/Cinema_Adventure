using EntityLayer.Class;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilities
{
	public class FilterHelper
	{
		public static List<Movie> RangeFilter(string ratingRange, List<Movie> movies)
		{
			if (!string.IsNullOrEmpty(ratingRange))
			{
				var ratingParts = ratingRange.Split('-');
				int minRating = int.Parse(ratingParts[0]);
				int maxRating = int.Parse(ratingParts[1]);

				movies = movies.Where(m =>
				{
					var averageRating = m.Reviews.Any() ? m.Reviews.Average(r => r.VoteGiven) : 0;
					return averageRating >= minRating && averageRating <= maxRating;
				}).ToList();
				return movies;
			}
			return movies;
		}

		public static List<Movie> YearFilter(int? yearFrom, int? yearTo, List<Movie> movies)
		{
			if (yearFrom.HasValue && yearTo.HasValue)
			{
				movies = movies.Where(m => m.ReleaseDate.HasValue &&
										   m.ReleaseDate.Value.Year >= yearFrom.Value &&
										   m.ReleaseDate.Value.Year <= yearTo.Value).ToList();
				return movies;
			}
			return movies;
		}

		public static List<Movie> SearchFilter(string movieName, List<Movie> movies)
		{
			if (!string.IsNullOrEmpty(movieName))
			{
				movies = movies.Where(m => m.MovieName.Contains(movieName, StringComparison.OrdinalIgnoreCase)).ToList();
				return movies;
			}
			return movies;
		}
		public static List<News> SearchFilter2(string newsname, List<News> news)
		{
			if (!string.IsNullOrEmpty(newsname))
			{
				news = news.Where(m => m.NewsTitle.Contains(newsname, StringComparison.OrdinalIgnoreCase)).ToList();
				return news;
			}
			return news;
		}

		public static List<Movie> SortFilter(string sortOrder, List<Movie> movies)
		{
			if (!string.IsNullOrEmpty(sortOrder))
			{
				switch (sortOrder)
				{
					case "alphabetAsc":
						movies = movies.OrderBy(m => m.MovieName).ToList();
						break;
					case "alphabetDesc":
						movies = movies.OrderByDescending(m => m.MovieName).ToList();
						break;
					case "ratingAsc":
						movies = movies.OrderBy(m => m.Reviews.Average(r => r.VoteGiven)).ToList();
						break;
					case "ratingDesc":
						movies = movies.OrderByDescending(m => m.Reviews.Average(r => r.VoteGiven)).ToList();
						break;
					case "dateAsc":
						movies = movies.OrderBy(m => m.ReleaseDate).ToList();
						break;
					case "dateDesc":
						movies = movies.OrderByDescending(m => m.ReleaseDate).ToList();
						break;
					default:
						break;
				}
				return movies;
			}
			return movies;
		}
	}
}
