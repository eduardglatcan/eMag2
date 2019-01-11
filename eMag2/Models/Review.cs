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
<<<<<<< HEAD

        public string UserId { get; set; }
        public DateTime PostedDate { get; set; }
        [MaxLength(255)]public string Title { get; set; }
        public string Comment { get; set; }
        public int Likes { get; set; }

        public virtual ApplicationUser ApplicationUser { get; set; }
=======
        public string Comment { get; set; }

>>>>>>> 9317837701c2b79591122ea61468e137a92fe3f0
    }
}