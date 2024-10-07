using DataAccessLayer.Abstraction;
using DataAccessLayer.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer.Class;

namespace DataAccessLayer.EntityFramework
{
    public class EFAboutUs : AboutUsManager, IAboutUsManager<AboutUs>
    {
    }
}
