using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using eMag2.Models;

namespace eMag2.ViewModels
{
    public class ReviewFormViewModel
    {
        public Product Product { get; set; }
        public int Id { get; set; }
        public int AssociatedProductId { get; set; }

        [Required(ErrorMessage = "If you want to give a review to this product you must least a rating!")]
        public byte Rating { get; set; }
        public string UserId { get; set; }

        public DateTime PostedDate { get; set; }
        [MaxLength(255)] public string Title { get; set; }
        [Display(Name = "Review")] public string Comment { get; set; }
        public int Likes { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }
    }
}