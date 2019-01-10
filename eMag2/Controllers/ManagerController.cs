using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using eMag2.Models;
using System.Data.Entity;
using System.Web.Routing;
using System.Web.Security;
using eMag2.ViewModels;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace eMag2.Controllers
{
    [Authorize(Roles = "Admin")]
    public class ManagerController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ManagerController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Manager
        public ActionResult GetUsers()
        {
            var users = new List<UserViewModel>();
            foreach (var user in _context.Users)
            {
                var roleId = user.Roles.Select(a => a.RoleId).ToList();
                var uRoleId = roleId[0];
                var role = _context.Roles.Single(a => a.Id == uRoleId);
                var userToAdd = new UserViewModel
                {
                    User = user,
                    Role = role.Name
                };

                users.Add(userToAdd);
            }

            return View(users);
        }

        public ActionResult GetPendingProducts()
        {
            var products = _context.Products.ToList();
            return View(products);
        }

        public ActionResult GetDeniedProducts()
        {
            var products = _context.Products.ToList();
            return View(products);
        }

        public ActionResult Details(int id)
        {
            var product = _context.Products.Include(c => c.Category).SingleOrDefault(c => c.Id == id);
            if (product == null)
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

        public ActionResult GiveRankAdmin(string id)
        {
            //System.Web.Security.Roles.AddUserToRole(id, "Admin");
            var context = new ApplicationDbContext();
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));

            if (userManager.IsInRole(id, "Colab"))
            {
                userManager.RemoveFromRole(id, "Colab");
            }
            else if (userManager.IsInRole(id, "User"))
            {
                userManager.RemoveFromRole(id, "User");
            }

            userManager.AddToRole(id, "Admin");

            return RedirectToAction("GetUsers");
        }

        public ActionResult GiveRankColab(string id)
        {
            //System.Web.Security.Roles.AddUserToRole(id, "Colab");
            var context = new ApplicationDbContext();
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));

            if (userManager.IsInRole(id, "Admin"))
            {
                userManager.RemoveFromRole(id, "Admin");
            }
            else if (userManager.IsInRole(id, "User"))
            {
                userManager.RemoveFromRole(id, "User");
            }

            userManager.AddToRole(id, "Colab");

            return RedirectToAction("GetUsers");
        }

        public ActionResult GiveRankUser(string id)
        {
            //System.Web.Security.Roles.AddUserToRole(id, "User");
            var context = new ApplicationDbContext();
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));

            if (userManager.IsInRole(id, "Admin"))
            {
                userManager.RemoveFromRole(id, "Admin");
            }
            else if (userManager.IsInRole(id, "Colab"))
            {
                userManager.RemoveFromRole(id, "Colab");
            }

            userManager.AddToRole(id, "User");

            return RedirectToAction("GetUsers");
        }

        public ActionResult DenyProduct(int id)
        {
            var product = _context.Products.SingleOrDefault(c => c.Id == id);
            if (product == null)
                return HttpNotFound();
            product.Posted = 2;
            _context.SaveChanges();
            return RedirectToAction("GetDeniedProducts", "Manager");
        }

        public ActionResult ApproveProduct(int id)
        {
            var product = _context.Products.SingleOrDefault(c => c.Id == id);
            if (product == null)
                return HttpNotFound();
            product.Posted = 1;
            _context.SaveChanges();
            return RedirectToAction("GetPendingProducts", "Manager");
        }

        public ActionResult Admin()
        {
            return View();
        }

        public ActionResult ViewCategories()
        {
            var categories = _context.Categories.ToList();
            return View(categories);
        }

        public ActionResult EditCategory(int id)
        {
            var category = _context.Categories.SingleOrDefault(c => c.Id == id);
            if (category == null)
                return HttpNotFound();
            var viewModel = new NewCategoryViewModel
            {
                Id = category.Id,
                Name = category.Name
            };
            return View("EditCategory", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ConfirmEdit(Category category)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new NewCategoryViewModel
                {
                    Name = category.Name
                };
                return View("EditCategory", viewModel);
            }

            var categoryInDb = _context.Categories.Single(p => p.Id == category.Id);

            categoryInDb.Name = category.Name;

            _context.SaveChanges();
            return RedirectToAction("ViewCategories", "Manager");
        }

        public ActionResult DeleteCategory(int id)
        {
            var categoryToBeDeleted = _context.Categories.SingleOrDefault(c => c.Id == id);
            if (categoryToBeDeleted != null)
            {
                _context.Categories.Remove(categoryToBeDeleted);
                _context.SaveChanges();
            }

            return RedirectToAction("ViewCategories");
        }

        public ActionResult NewCategory()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UploadCategory(Category category)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new NewCategoryViewModel
                {
                    Name = category.Name
                };
                return View("NewCategory", viewModel);
            }

            _context.Categories.Add(category);
            _context.SaveChanges();
            return RedirectToAction("ViewCategories", "Manager");
        }

        public ActionResult EditReview(int id)
        {
            var reviewToEdit = _context.Reviews.SingleOrDefault(r => r.Id == id);
            if (reviewToEdit == null)
                return HttpNotFound();
            var viewModel = new EditReviewViewModel
            {
                Title = reviewToEdit.Title,
                Comment = reviewToEdit.Comment
            };
            return View("EditReview", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult ConfirmReviewEdit(Review reviewToEdit)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new EditReviewViewModel()
                {
                    Title = reviewToEdit.Title,
                    Comment = reviewToEdit.Comment
                };
                return View("EditReview", viewModel);
            }

            var reviewInDb = _context.Reviews.Single(r => r.Id == reviewToEdit.Id);
            reviewInDb.Title = reviewToEdit.Title;
            reviewInDb.Comment = reviewToEdit.Comment;
            _context.SaveChanges();
            return RedirectToAction("Details",
                new RouteValueDictionary(new
                    {controller = "Products", action = "Details", id = reviewInDb.AssociatedProductId}));
        }

        public ActionResult DeleteReview(int id)
        {
            var reviewToBeDeleted = _context.Reviews.SingleOrDefault(c => c.Id == id);
            int productId;
            if (reviewToBeDeleted != null)
            {
                productId = reviewToBeDeleted.AssociatedProductId;
                _context.Reviews.Remove(reviewToBeDeleted);
                var productInDb = _context.Products.Single(c => c.Id == productId);
                productInDb.CommentCount = productInDb.CommentCount - 1;
                float newRating = 0;
                foreach (var review in _context.Reviews.ToList())
                {
                    if (review.AssociatedProductId == productInDb.Id && review.Id != id)
                    {
                        newRating += review.Rating;
                    }
                }

                if (newRating != 0)
                {
                    newRating /= productInDb.CommentCount;
                }

                productInDb.Rating = newRating;
                _context.SaveChanges();
            }
            else
            {
                return HttpNotFound();
            }

            return RedirectToAction("Details",
                new RouteValueDictionary(new {controller = "Products", action = "Details", id = productId}));
        }

        public ActionResult DeleteProduct(int id)
        {
            var productToBeDeleted = _context.Products.SingleOrDefault(p => p.Id == id);
            if (productToBeDeleted != null)
            {
                var reviewsAssociated = _context.Reviews.Where(r => r.AssociatedProductId == id);
                foreach (var review in reviewsAssociated)
                {
                    _context.Reviews.Remove(review);
                }

                _context.Products.Remove(productToBeDeleted);
                _context.SaveChanges();
            }
            else
            {
                return HttpNotFound();
            }

            return RedirectToAction("Index", "Products");
        }
    }
}