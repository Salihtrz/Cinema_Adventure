using BusinessLayer.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer.Class;
using DataAccessLayer.Abstraction;
using DataAccessLayer.EntityFramework;

namespace BusinessLayer.Services
{
    public class MovieService : IMovieService<Movie>
    {
        EFMovie efmovie;
        public MovieService(EFMovie efmovie)
        {
            this.efmovie = efmovie;
        }

        public void addMovie(Movie movie)
        {
            efmovie.addMovie(movie);
        }

        public List<Movie> GetAllMovies()
        {
            return efmovie.GetAllMovies();
        }

		public List<Movie> GetAllMoviesWithCategory()
        {
            return efmovie.GetAllMoviesWithCategory();
        }

        public void removeMovie(Movie movie)
        {
            efmovie.removeMovie(movie);
        }

        public void updateMovie(Movie movie)
        {
            efmovie.updateMovie(movie);
        }

        public Movie GetMovieByID(int id)
        {
            return efmovie.GetMovieById(id);
        }
        public void addMovieCast(MovieCast movieCast)
        {
            efmovie.addMovieCast(movieCast);
        }
        public void updateMovieCast(MovieCast movieCast)
        {
            efmovie.updateMovieCast(movieCast);
        }
        public List<MovieCast> FindRelatedCast(int id)
        {
            return efmovie.FindRelatedCast(id);
        }
        public void removeRelatedCast(MovieCast movieCast)
        {
            efmovie.removeRelatedCast(movieCast);
        }
        public void addMovieCategory(MovieCategory movieCategory)
        {
            efmovie.addMovieCategory(movieCategory);
        }

        public void removeRelatedCategory(MovieCategory movieCategory)
        {
            efmovie.removeRelatedCategory(movieCategory);
        }

        public void updateMovieCategory(MovieCategory movieCategory)
        {
            efmovie.updateMovieCategory(movieCategory);
        }

        public List<MovieCategory> FindRelatedCategory(int id)
        {
            return efmovie.FindRelatedCategory(id);
        }
    }
}
