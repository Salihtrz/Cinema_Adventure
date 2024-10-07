using BusinessLayer.Abstraction;
using DataAccessLayer.EntityFramework;
using EntityLayer.Class;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Services
{
	public class NewsService : INewsService<News>
	{
		EFNews efnews;
		public NewsService(EFNews efnews) 
		{
			this.efnews = efnews;
		}

		public void addNews(News news)
		{
			efnews.addNews(news);
		}

		public List<News> GetAllNews()
		{
			return efnews.GetAllNews();
		}

		public News GetNewsById(int id)
		{
			return efnews.GetNewsById(id);
		}

		public void removeNews(News news)
		{
			efnews.removeNews(news);
		}

		public void updateNews(News news)
		{
			efnews.updateNews(news);
		}
	}
}
