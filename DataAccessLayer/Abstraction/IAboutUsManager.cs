using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer.Class;

namespace DataAccessLayer.Abstraction
{
    public interface IAboutUsManager<AboutUs>
    {
        List<AboutUs> GetAll();
        AboutUs getAboutUs();
        void removeAboutUs(AboutUs aboutUs);
        void updateAboutUs(AboutUs aboutUs);
        void addAboutUs(AboutUs aboutUs);
    }
}
