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
    public class ReviewService : IReviewService<Review>
    {
        EFReview efReview;
        public ReviewService(EFReview efReview) 
        {
            this.efReview = efReview;
        }

        public void addReview(Review review)
        {
            efReview.addReview(review);
        }

        public List<Review> GetAllReviews()
        {
            return efReview.GetAllReviews();
        }

        public List<Review> GetAllReviewsWithUsers(int id)
        {
            return efReview.GetAllReviewsWithUsers(id);
        }

        public Review GetReviewById(int id)
        {
            return efReview.GetReviewById(id);
        }

        public void removeReview(Review review)
        {
            efReview.removeReview(review);
        }

        public void updateReview(Review review)
        {
            efReview.updateReview(review);
        }
    }
}
