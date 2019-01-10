using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using eMag2.Models;

namespace eMag2.ViewModels
{
    public class NewProductViewModel
    {
        public IEnumerable<Category> Categories { get; set; }
        public int? Id { get; set; }

        [Required(ErrorMessage = "Please enter a product name!")]
        [MaxLength(255, ErrorMessage = "Product name can't exceed 255 characters!")]
        [Display(Name = "Product Name")]
        public string Name { get; set; }

        private Category Category { get; set; }

        [Display(Name = "Product's Category")]public short CategoryId { get; set; }

        public string Description { get; set; }

        [Display(Name = "Upload An Image")]
        public string ImagePath { get; set; }

        [Display(Name = "Product stock")] public int? NumberInStock { get; set; }

        [Required(ErrorMessage = "Please enter the vendor name!")]
        [Display(Name = "Sold By")]
        private string SoldBy { get; set; }

        [Required(ErrorMessage = "Please enter a price!")]
        [Display(Name = "Full Price")]
        public float? FullPrice { get; set; }

        [Display(Name = "Discounted Price(if exists)")]
        public float? DiscountedPrice { get; set; }

        [Required(ErrorMessage = "Please insert an internal code for the product!")]
        [Display(Name = "Product's internal code")]
        public string InternalCode { get; set; }

        public string OwnerId { get; set; }

        [NotMapped] public HttpPostedFileBase ImageFile { get; set; }

        public NewProductViewModel()
        {
            Id = 0;
        }

        public NewProductViewModel(Product product)
        {
            Id = product.Id;
            Name = product.Name;
            Category = product.Category;
            Description = product.Description;
            ImagePath = product.ImagePath;
            NumberInStock = product.NumberInStock;
            SoldBy = product.SoldBy;
            FullPrice = product.FullPrice;
            DiscountedPrice = product.DiscountedPrice;
            InternalCode = product.InternalCode;
        }
    }
}