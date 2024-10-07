//using BusinessLayer.Abstraction;
//using DataAccessLayer.Abstraction;
//using DataAccessLayer.Context;
//using EntityLayer.Class;
//using Microsoft.EntityFrameworkCore;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace DataAccessLayer.Managers
//{
//    public class CastManager : ICastManager<MovieCast>
//    {
//        CinemaDb CinemaDb = new CinemaDb();
//        public List<MovieCast> GetAllCasts()
//        {
//            return CinemaDb.Set<MovieCast>().ToList();
//        }

//        public void addCast(MovieCast moviecast)
//        {
//            CinemaDb.Add(moviecast);
//            CinemaDb.SaveChanges();
//        }

//        public void removeCast(MovieCast moviecast)
//        {
//            CinemaDb.Remove(moviecast);
//            CinemaDb.SaveChanges();
//        }

//        public void updateCast(MovieCast moviecast)
//        {
//            CinemaDb.Update(moviecast);
//            CinemaDb.SaveChanges();
//        }

//        public MovieCast GetCastById(int id)
//        {
//            //var FindCast = CinemaDb.Set<MovieCast>().Include(i => i.casts.CastId);
//            return CinemaDb.MovieCasts.Find(id);
//        }
//    }
//}







using BusinessLayer.Abstraction;
using DataAccessLayer.Abstraction;
using DataAccessLayer.Context;
using EntityLayer.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Managers
{
    public class CastManager : ICastManager<Cast>
    {
        CinemaDb CinemaDb = new CinemaDb();
        public List<Cast> GetAllCasts()
        {
            return CinemaDb.Set<Cast>().ToList();
        }

        public void addCast(Cast cast)
        {
            CinemaDb.Casts.Add(cast);
            CinemaDb.SaveChanges();
        }

        public void removeCast(Cast cast)
        {
            CinemaDb.Casts.Remove(cast);
            CinemaDb.SaveChanges();
        }

        public void updateCast(Cast cast)
        {
            CinemaDb.Casts.Update(cast);
            CinemaDb.SaveChanges();
        }

        public Cast GetCastById(int id)
        {
            return CinemaDb.Casts.Find(id);
        }
    }
}
