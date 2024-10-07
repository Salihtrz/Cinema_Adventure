using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Abstraction;
using DataAccessLayer.Managers;
using EntityLayer.Class;

namespace DataAccessLayer.EntityFramework
{
	public class EFMovie : MovieManager, IMovieManager<Movie>
	{

	}
}
