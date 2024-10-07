using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer.Class;

namespace BusinessLayer.Abstraction
{
	public interface IAboutUsService<AboutUs>
	{
		List<AboutUs> GetAll();
		AboutUs getAboutUs();
		void updateAboutUs(AboutUs aboutUs);
		void removeAbousUs(AboutUs aboutUs);
		void addAboutUs(AboutUs aboutUs);
	}
}
