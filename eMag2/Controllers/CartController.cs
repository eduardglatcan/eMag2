using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using eMag2.Models;
using eMag2.ViewModels;

namespace eMag2.Controllers
{
    public class CartController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CartController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Cart
        [Authorize]
        public ActionResult AddToCart(Product product)
        {
            if (Session["Cart"] == null)
            {
                var productsInCart = new CartViewModel
                {
                    Products = new List<Product>(),
                    NumberOfItems = 1
                };
                productsInCart.Products.Add(product);
                Session["cart"] = productsInCart.Products;
                ViewBag.cart = productsInCart.Products.Count();
                Session["countCart"] = 1;
            }
            else
            {
                var productsInCart = new CartViewModel
                {
                    Products = (List<Product>) Session["cart"],
                    NumberOfItems = Convert.ToInt32(Session["countCart"])
                };
                productsInCart.Products.Add(product);
                Session["cart"] = productsInCart.Products;
                ViewBag.cart = productsInCart.Products.Count();
                Session["countCart"] = productsInCart.NumberOfItems + 1;
            }

            return RedirectToAction("Index", "Products");
        }

        public ActionResult GetCart()
        {
            var productsInCart = new CartViewModel
            {
                Products =  (List<Product>)Session["cart"],
                NumberOfItems = Convert.ToInt32(Session["countCart"])
            };
            return View(productsInCart);
        }

        public ActionResult CleanCart()
        {
            Session.Clear();
            return RedirectToAction("Index", "Products");
        }

        public ActionResult RemoveProductFromCart(int id)
        {
            var productsInCart = new CartViewModel
            {
                Products = (List<Product>)Session["cart"],
                NumberOfItems = Convert.ToInt32(Session["countCart"])
            };
            foreach (var product in productsInCart.Products)
            {
                if (product.Id == id)
                {
                    productsInCart.Products.Remove(product);
                    break;
                }
            }
            Session["cart"] = productsInCart.Products;
            Session["countCart"] = productsInCart.NumberOfItems - 1;
            return RedirectToAction("GetCart", "Cart");
        }

        public ActionResult CheckOut()
        {
            throw new NotImplementedException();
        }
    }
}