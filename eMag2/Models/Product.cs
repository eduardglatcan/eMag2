using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
<<<<<<< HEAD
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;
=======
using System.Linq;
using System.Web;
>>>>>>> 9317837701c2b79591122ea61468e137a92fe3f0

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
<<<<<<< HEAD

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
=======
        public string Description { get; set; }
        [Required] public string ImagePath { get; set; }

        public float Rating { get; set; } = 0;
        public int NumberInStock { get; set; } = 0;
        [Required(ErrorMessage = "Please enter the vendor name!")]public string SoldBy { get; set; }
        [Required(ErrorMessage = "Please enter a price!")]public float FullPrice { get; set; }
        public float DiscountedPrice { get; set; }
        [Required(ErrorMessage = "Please insert an internal code for the product!")]public string InternalCode { get; set; }
        public int CommentCount { get; set; }
>>>>>>> 9317837701c2b79591122ea61468e137a92fe3f0
    }
}