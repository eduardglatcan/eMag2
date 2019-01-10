using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Security;
using eMag2.Models;
using eMag2.ViewModels;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;

namespace eMag2.Controllers
{
    public class ReviewsController : Controller
    {
        private ApplicationDbContext _context;

        public ReviewsController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SendReview(Review review)
        {
            review.UserId = User.Identity.GetUserId();
            review.Likes = 0;
            review.PostedDate = DateTime.Now;
            var rating = Request.Form["stars"];
            review.Rating = byte.Parse(rating);
            var product = _context.Products.SingleOrDefault(p => p.Id == review.AssociatedProductId);
            var oldReviews = _context.Reviews.Where(r => r.AssociatedProductId == review.AssociatedProductId).ToList();
            if (product == null)
                HttpNotFound();
            float prodRating = 0;
            foreach (var oldReview in oldReviews)
            {
                prodRating += oldReview.Rating;
            }
            product.CommentCount++;
            product.Rating = (review.Rating + prodRating) / product.CommentCount;
            _context.Reviews.Add(review);
            _context.SaveChanges();

            // ReSharper disable once Mvc.ActionNotResolved
            return RedirectToAction("Details", new RouteValueDictionary(new { controller = "Products", action = "Details", id = review.AssociatedProductId }));
        }
    }
}