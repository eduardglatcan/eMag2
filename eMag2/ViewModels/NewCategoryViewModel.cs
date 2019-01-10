using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace eMag2.ViewModels
{
    public class NewCategoryViewModel
    {
        public int? Id { get; set; }
        [Required][StringLength(255)][Display(Name = "Category Name")]public string Name { get; set; }
    }
}