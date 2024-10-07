using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer.Class;

namespace DataAccessLayer.Abstraction
{
	public interface IMovieManager<Movie>
	{
		List<Movie> GetAllMovies();
		void addMovie(Movie movie);
		void addMovieCast(MovieCast movieCast);
		void addMovieCategory(MovieCategory movieCategory);
		void removeMovie(Movie movie);
		void removeRelatedCast(MovieCast movieCast);
        void removeRelatedCategory(MovieCategory movieCategory);
        void updateMovie(Movie movie);
        void updateMovieCast(MovieCast moviecast);
        void updateMovieCategory(MovieCategory movieCategory);
        Movie GetMovieById(int id);
		List<MovieCast> FindRelatedCast(int id);
        List<MovieCategory> FindRelatedCategory(int id);
        List<Movie> GetAllMoviesWithCategory();

    }
}
