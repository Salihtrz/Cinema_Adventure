using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Abstraction;
using DataAccessLayer.Context;
using EntityLayer.Class;

namespace DataAccessLayer.Managers
{
    public class AboutUsManager : IAboutUsManager<AboutUs>
    {
        CinemaDb CinemaDb = new CinemaDb();
        public void updateAboutUs(AboutUs aboutUs)
        {
            CinemaDb.Update(aboutUs);
            CinemaDb.SaveChanges();
        }

        public void removeAboutUs(AboutUs aboutUs)
        {
            CinemaDb.Remove(aboutUs);
            CinemaDb.SaveChanges();
        }

		public AboutUs getAboutUs()
		{
            return CinemaDb.AboutUss.FirstOrDefault();
		}

		public void addAboutUs(AboutUs aboutUs)
		{
			CinemaDb.Add(aboutUs);
            CinemaDb.SaveChanges();
		}
        public List<AboutUs> GetAll()
        {
            return CinemaDb.Set<AboutUs>().ToList();
        }
	}
}
