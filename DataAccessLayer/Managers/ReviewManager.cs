using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer.Class;
using DataAccessLayer.Abstraction;
using Microsoft.EntityFrameworkCore;
using DataAccessLayer.Context;

namespace DataAccessLayer.Managers
{
    public class ReviewManager : IReviewManager<Review>
    {
        CinemaDb CinemaDb = new CinemaDb();
        public void addReview(Review review)
        {
            CinemaDb.Add(review);
            CinemaDb.SaveChanges();
        }

        public List<Review> GetAllReviews()
        {
            return CinemaDb.Set<Review>().ToList();
        }

        public List<Review> GetAllReviewsWithUsers(int id)
        {
            return CinemaDb.Set<Review>()
                .Include(i => i.UserID)
                .ToList();
        }

        public Review GetReviewById(int id)
        {
            return CinemaDb.Reviews.Find(id);
        }

        public void removeReview(Review review)
        {
            CinemaDb.Remove(review);
            CinemaDb.SaveChanges();
        }

        public void updateReview(Review review)
        {
            CinemaDb.Update(review);
            CinemaDb.SaveChanges();
        }
    }
}
