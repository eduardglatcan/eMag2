using System;
using System.IO;
using System.Linq;
using System.Web.Mvc;
using eMag2.Models;
using eMag2.ViewModels;
using System.Data.Entity;
using Microsoft.AspNet.Identity;

namespace eMag2.Controllers
{
    [Authorize(Roles = "Colab, Admin")]
    public class ColabController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ColabController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public ActionResult AddItem()
        {
            var categories = _context.Categories.ToList();
            var viewModel = new NewProductViewModel
            {
                Categories = categories
            };
            return View("AddItem", viewModel);
        }

        [ValidateInput(false)]
        public ActionResult UploadProduct(Product productToAdd)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new NewProductViewModel(productToAdd)
                {
                    Categories = _context.Categories.ToList()
                };
                return View("AddItem", viewModel);
            }

            var fileName = Path.GetFileNameWithoutExtension(productToAdd.ImageFile.FileName);
            var fileExtension = Path.GetExtension(productToAdd.ImageFile.FileName);
            fileName = DateTime.Now.ToString("yyyy-MM-dd-hh-mm-tt") + "-" + fileName.Trim() + fileExtension;

            productToAdd.ImagePath = Path.Combine(Server.MapPath("~/img/"), fileName);
            productToAdd.ImageFile.SaveAs(productToAdd.ImagePath);
            productToAdd.ImagePath = "~/img/" + fileName;
            if (productToAdd.Id == 0)
            {
                productToAdd.Rating = 0;
                productToAdd.CommentCount = 0;
                productToAdd.Posted = 0;
                productToAdd.OwnerId = User.Identity.GetUserId();
                productToAdd.SoldBy = User.Identity.Name;
                _context.Products.Add(productToAdd);
            }

            _context.SaveChanges();
            return RedirectToAction("Index", "Products");
        }

        public ActionResult EditProduct(int id)
        {
            var product = _context.Products.Include(c => c.Category).SingleOrDefault(c => c.Id == id);
            if (product == null)
                return HttpNotFound();
            var categories = _context.Categories.ToList();
            var viewModel = new NewProductViewModel(product)
            {
                Categories = categories
            };
            return View("EditItem", viewModel);
        }

        [ValidateInput(false)]
        [ValidateAntiForgeryToken]
        public ActionResult SaveEditProduct(Product productToEdit)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new NewProductViewModel(productToEdit)
                {
                    Categories = _context.Categories.ToList()
                };
                return View("EditItem", viewModel);
            }

            var fileName = Path.GetFileNameWithoutExtension(productToEdit.ImageFile.FileName);
            var fileExtension = Path.GetExtension(productToEdit.ImageFile.FileName);
            fileName = DateTime.Now.ToString("yyyy-MM-dd-hh-mm-tt") + "-" + fileName.Trim() + fileExtension;

            productToEdit.ImagePath = Path.Combine(Server.MapPath("~/img/"), fileName);
            productToEdit.ImageFile.SaveAs(productToEdit.ImagePath);
            productToEdit.ImagePath = "~/img/" + fileName;
            var productInDb = _context.Products.Single(p => p.Id == productToEdit.Id);
            productInDb.Name = productToEdit.Name;
            productInDb.ImagePath = productToEdit.ImagePath;
            productInDb.Posted = 0;
            productInDb.CategoryId = productToEdit.CategoryId;
            productInDb.Description = productToEdit.Description;
            productInDb.FullPrice = productToEdit.FullPrice;
            productInDb.DiscountedPrice = productToEdit.DiscountedPrice;
            productInDb.InternalCode = productToEdit.InternalCode;
            productInDb.NumberInStock = productToEdit.NumberInStock;

            _context.SaveChanges();
            return RedirectToAction("Index", "Products");
        }
    }
}