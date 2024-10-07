using DataAccessLayer.Abstraction;
using DataAccessLayer.Context;
using EntityLayer.Class;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Managers
{
	public class NewsManager : INewsManager<News>
	{
		CinemaDb CinemaDb = new CinemaDb();
		public void addNews(News news)
		{
			CinemaDb.Add(news);
			CinemaDb.SaveChanges();
		}

		public List<News> GetAllNews()
		{
			return CinemaDb.Set<News>()
				.Include(i => i.reviews_News)
					.ThenInclude(i => i.users)
				.ToList();
		}

		public News GetNewsById(int id)
		{
			return CinemaDb.News.Find(id);
		}

		public void removeNews(News news)
		{
			CinemaDb.Remove(news);
			CinemaDb.SaveChanges();
		}

		public void updateNews(News news)
		{
			CinemaDb.Update(news);
			CinemaDb.SaveChanges();
		}
	}
}
