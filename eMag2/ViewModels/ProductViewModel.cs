using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using eMag2.Models;

namespace eMag2.ViewModels
{
    public class ProductViewModel
    {
        public List<Review> Reviews { get; set; }
        public Product Product { get; set; }
        public List<ApplicationUser> User { get; set; }
    }
}