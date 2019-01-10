using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using eMag2.Models;
using Microsoft.AspNet.Identity;

namespace eMag2.ViewModels
{
    public class UserViewModel
    {
        public ApplicationUser User { get; set; }
        public string Role { get; set; }
    }
}