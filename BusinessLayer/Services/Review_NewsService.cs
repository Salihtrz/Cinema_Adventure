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
    public class Review_NewsService : IReview_NewsService<Review_News>
    {
        EFReview_News efreview_news;
        public Review_NewsService(EFReview_News efreview_news)
        {
            this.efreview_news = efreview_news;
        }

        public void addReview_News(Review_News review_news)
        {
            efreview_news.addReview_News(review_news);
        }

        public List<Review_News> GetAllReview_News()
        {
            return efreview_news.GetAllReview_News();
        }

        public List<Review_News> GetAllReview_NewsWithUsers(int id)
        {
            return efreview_news.GetAllReview_NewsWithUsers(id);
        }

        public Review_News GetReview_NewsById(int id)
        {
            return efreview_news.GetReview_NewsById((int)id);
        }

        public void removeReview_News(Review_News review_news)
        {
            efreview_news.removeReview_News(review_news);
        }

        public void updateReview_News(Review_News review_news)
        {
            efreview_news.updateReview_News(review_news);
        }
    }
}
