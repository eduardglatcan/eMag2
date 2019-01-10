using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

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

        [Display(Name = "Product's Category")] public short CategoryId { get; set; }

        public string Description { get; set; }

        [Display(Name = "Upload An Image")]
        public string ImagePath { get; set; }

        public float Rating { get; set; } = 0;
        [Display(Name = "Product stock")]
        public int NumberInStock { get; set; } = 0;
        
        [Display(Name = "Sold By")]
        public string SoldBy { get; set; }

        [Required(ErrorMessage = "Please enter a price!")]
        [Display(Name = "Full Price")]
        public float FullPrice { get; set; }

        [Display(Name = "Discounted Price(if exists)")]
        public float DiscountedPrice { get; set; }

        [Required(ErrorMessage = "Please insert an internal code for the product!")]
        [Display(Name = "Product's internal code")]
        public string InternalCode { get; set; }

        public int CommentCount { get; set; }
        public byte Posted { get; set; } = 0;

        public string OwnerId { get; set; }

        [NotMapped]
        public HttpPostedFileBase ImageFile { get; set; }
    }
}