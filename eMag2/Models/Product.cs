using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace eMag2.Models
{
    public class Product
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter a product name!")]
        [MaxLength(255, ErrorMessage = "Product name can't exceed 255 characters!")]
        [Display(Name = "Product Name")]
        public string Name { get; set; }

        public Category Category { get; set; }
        public string Description { get; set; }
        [Required] public string ImagePath { get; set; }

        public float Rating { get; set; } = 0;
        public int NumberInStock { get; set; } = 0;
        [Required(ErrorMessage = "Please enter the vendor name!")]public string SoldBy { get; set; }
        [Required(ErrorMessage = "Please enter a price!")]public float FullPrice { get; set; }
        public float DiscountedPrice { get; set; }
        [Required(ErrorMessage = "Please insert an internal code for the product!")]public string InternalCode { get; set; }
        public int CommentCount { get; set; }
    }
}