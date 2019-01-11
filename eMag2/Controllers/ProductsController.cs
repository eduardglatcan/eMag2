<<<<<<< HEAD
﻿using System;
using System.Linq;
using System.Web.Mvc;
using eMag2.Models;
using System.Data.Entity;
using System.Web.Security;
using eMag2.ViewModels;
using Microsoft.AspNet.Identity;
=======
﻿using System.Linq;
using System.Web.Mvc;
using eMag2.Models;
using System.Data.Entity;
>>>>>>> 9317837701c2b79591122ea61468e137a92fe3f0

namespace eMag2.Controllers
{
    public class ProductsController : Controller
    {
<<<<<<< HEAD
        private readonly ApplicationDbContext _context;
=======
        private ApplicationDbContext _context;
>>>>>>> 9317837701c2b79591122ea61468e137a92fe3f0

        public ProductsController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
<<<<<<< HEAD

=======
>>>>>>> 9317837701c2b79591122ea61468e137a92fe3f0
        // GET: Products
        public ViewResult Index()
        {
            var products = _context.Products.Include(c => c.Category).ToList();

            return View(products);
        }
<<<<<<< HEAD

        public ActionResult Details(int id)
        {
            var product = _context.Products.Include(c => c.Category).SingleOrDefault(c => c.Id == id);
            if (product == null || product.Posted == 0)
                return HttpNotFound();
            var reviews = _context.Reviews.Include(c => c.ApplicationUser).Where(r => r.AssociatedProductId == id)
                .ToList();
            var users = _context.Users.ToList();
            var viewModel = new ProductViewModel
            {
                Product = product,
                Reviews = reviews,
                User = users
            };
            return View("Details", viewModel);
        }

        [Authorize]
        public ActionResult AddReview(int id)
        {
            var product = _context.Products.SingleOrDefault(c => c.Id == id);
            if (product == null)
                return HttpNotFound();
            var viewModel = new ReviewFormViewModel
            {
                Product = product,
                AssociatedProductId = product.Id,
            };
            return View("AddReview", viewModel);
        }

        public ActionResult Search(string searchedWord)
        {
            var searchResult = _context.Products
                .Include(c => c.Category)
                .Where(s => s.Name.Contains(searchedWord))
                .ToList();
            return View("ProductSearch", searchResult);
        }

        public ViewResult Sorted(string sortOrder)
        {
            var products = _context.Products.Include(c => c.Category).ToList();
            IOrderedEnumerable<Product> products2 = null;

            if (!(String.IsNullOrEmpty(sortOrder)))
            {
                switch (sortOrder)
                {
                    case "rating":
                        products2 = products.OrderBy(s => s.Rating);
                        break;
                    case "priceDesc":
                        products2 = products.OrderByDescending(s => s.FullPrice);
                        break;
                    case "price":
                        products2 = products.OrderBy(s => s.FullPrice);
                        break;
                    default:
                        products2 = products.OrderByDescending(s => s.Rating);
                        break;
                }

                return View("Index", products2);
            }
            else
            {
                return View("Index", products);
            }
        }
=======
        public ActionResult Details(int id)
        {
            var product = _context.Products.Include(c => c.Category).SingleOrDefault(c => c.Id == id);
            if (product == null)
                return HttpNotFound();
            return View(product);
        } 
>>>>>>> 9317837701c2b79591122ea61468e137a92fe3f0
    }
}