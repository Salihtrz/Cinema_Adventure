using EntityLayer.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstraction
{
    public interface IReview_NewsManager<Review_News>
    {
        List<Review_News> GetAllReview_News();
        Review_News GetReview_NewsById(int id);
        void addReview_News(Review_News review_news);
        void removeReview_News(Review_News review_news);
        void updateReview_News(Review_News review_news);
        List<Review_News> GetAllReview_NewsWithUsers(int id);
    }
}
