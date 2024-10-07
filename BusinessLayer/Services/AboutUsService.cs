using BusinessLayer.Abstraction;
using DataAccessLayer.EntityFramework;
using EntityLayer.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Services
{
    public class AboutUsService : IAboutUsService<AboutUs>
    {
        EFAboutUs efAboutUs;
        public AboutUsService(EFAboutUs efAboutUs)
        {
            this.efAboutUs = efAboutUs;
        }
        public void updateAboutUs(AboutUs aboutUs)
        {
            efAboutUs.updateAboutUs(aboutUs);
        }

        public void removeAbousUs(AboutUs aboutUs)
        {
            efAboutUs.removeAboutUs(aboutUs);
        }

		public AboutUs getAboutUs()
		{
			return efAboutUs.getAboutUs();
		}

		public void addAboutUs(AboutUs aboutUs)
		{
			efAboutUs.addAboutUs(aboutUs);
		}

		public List<AboutUs> GetAll()
		{
            return efAboutUs.GetAll();
		}
	}
}
