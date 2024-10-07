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
    public class Review_NewsManager : IReview_NewsManager<Review_News>
    {
        CinemaDb CinemaDb = new CinemaDb();
        public void addReview_News(Review_News review_news)
        {
            CinemaDb.Add(review_news);
            CinemaDb.SaveChanges();
        }

        public List<Review_News> GetAllReview_News()
        {
            return CinemaDb.Set<Review_News>().ToList();
        }

        public List<Review_News> GetAllReview_NewsWithUsers(int id)
        {
            return CinemaDb.Set<Review_News>()
                .Include(i => i.UserID)
                .ToList();
        }

        public Review_News GetReview_NewsById(int id)
        {
            return CinemaDb.Reviews_News.Find(id);
        }

        public void removeReview_News(Review_News review_news)
        {
            CinemaDb.Remove(review_news);
            CinemaDb.SaveChanges();
        }

        public void updateReview_News(Review_News review_news)
        {
            CinemaDb.Update(review_news);
            CinemaDb.SaveChanges();
        }
    }
}
