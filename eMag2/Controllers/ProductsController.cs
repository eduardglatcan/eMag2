using System.Linq;
using System.Web.Mvc;
using eMag2.Models;
using System.Data.Entity;

namespace eMag2.Controllers
{
    public class ProductsController : Controller
    {
        private ApplicationDbContext _context;

        public ProductsController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        // GET: Products
        public ViewResult Index()
        {
            var products = _context.Products.Include(c => c.Category).ToList();

            return View(products);
        }
        public ActionResult Details(int id)
        {
            var product = _context.Products.Include(c => c.Category).SingleOrDefault(c => c.Id == id);
            if (product == null)
                return HttpNotFound();
            return View(product);
        } 
    }
}