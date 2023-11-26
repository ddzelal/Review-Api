using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using web_app1.Models;

namespace web_app1.Interfaces
{
    public interface IReviewRepository
    {
        ICollection<Review> GetReviews();
        Review GetReview(int id);
        ICollection<Review> GetReviewsOfAPokemon(int pokeId);
        bool ReviewExists(int reviewId);
    }
}