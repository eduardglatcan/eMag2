using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using eMag2.Models;

namespace eMag2.ViewModels
{
    public class CartViewModel
    {
        public List<Product> Products { get; set; }
        public int NumberOfItems { get; set; } = 0;
    }
}