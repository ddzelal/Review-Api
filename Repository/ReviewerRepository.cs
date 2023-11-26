using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using web_app1.Data;
using web_app1.Interfaces;
using web_app1.Models;

namespace web_app1.Repository
{
    public class ReviewerRepository : IReviewerRepository
    {
        private readonly DataContext _context;
        public ReviewerRepository(DataContext context)
        {
            _context = context;

        }

        public ICollection<Reviewer> GetReviewers()
        {
            return _context.Reviewers.ToList();
        }

        public Reviewer GetReviewer(int reviewId)
        {
            return _context.Reviewers.Where(r => r.Id == reviewId).Include(r => r.Reviews).FirstOrDefault();
        }

        public ICollection<Review> GetReviewsByReviewer(int reviewerId)
        {
            return _context.Reviews.Where(r => r.Reviewer.Id == reviewerId).ToList();
        }

        public bool ReviewerExists(int reviewerId)
        {
            return _context.Reviewers.Any(r => r.Id == reviewerId);
        }
    }
}