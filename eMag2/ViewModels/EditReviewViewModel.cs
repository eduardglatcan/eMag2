using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using eMag2.Models;

namespace eMag2.ViewModels
{
    public class EditReviewViewModel
    {
        public int? Id { get; set; }

        [MaxLength(255)] public string Title { get; set; }
        public string Comment { get; set; }
        public string UserId { get; set; }
    }
}