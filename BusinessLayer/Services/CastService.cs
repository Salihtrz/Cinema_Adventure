//using BusinessLayer.Abstraction;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using EntityLayer.Class;
//using DataAccessLayer.Abstraction;
//using DataAccessLayer.EntityFramework;

//namespace BusinessLayer.Services
//{
//    public class CastService : ICastService<MovieCast>
//    {
//        EFCast efcast;
//        public CastService(EFCast efcast)
//        {
//            this.efcast = efcast;
//        }
//        public List<MovieCast> GetAllCasts()
//        {
//            return efcast.GetAllCasts();
//        }

//        public void addCast(MovieCast moviecast)
//        {
//            efcast.addCast(moviecast);
//        }

//        public void removeCast(MovieCast moviecast)
//        {
//            efcast.removeCast(moviecast);
//        }

//        public void updateCast(MovieCast moviecast)
//        {
//            efcast.updateCast(moviecast);
//        }

//        public MovieCast GetCastById(int id)
//        {
//            return efcast.GetCastById(id);
//        }
//    }
//}







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
    public class CastService : ICastService<Cast>
    {
        EFCast efcast;
        public CastService(EFCast efcast)
        {
            this.efcast = efcast;
        }
        public List<Cast> GetAllCasts()
        {
            return efcast.GetAllCasts();
        }

        public void addCast(Cast cast)
        {
            efcast.addCast(cast);
        }

        public void removeCast(Cast cast)
        {
            efcast.removeCast(cast);
        }

        public void updateCast(Cast cast)
        {
            efcast.updateCast(cast);
        }

        public Cast GetCastById(int id)
        {
            return efcast.GetCastById(id);
        }
    }
}
