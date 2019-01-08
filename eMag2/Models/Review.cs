using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace eMag2.Models
{
    public class Review
    {
        public int Id { get; set; }
        public int AssociatedProductId { get; set; }
        [Required(ErrorMessage = "If you want to give a review to this product you must least a rating!")]
        public byte Rating { get; set; }
        public string Comment { get; set; }

    }
}