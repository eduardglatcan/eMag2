using eMag2.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(eMag2.Startup))]

namespace eMag2
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            CreateRolesAndUsers();
        }

        private void CreateRolesAndUsers()
        {
            var context = new ApplicationDbContext();

            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));


            if (!roleManager.RoleExists("Admin"))
            {
                var role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole { Name = "Admin" };
                roleManager.Create(role);

                var user = new ApplicationUser { UserName = "Admin", Email = "admin@emag2.com" };

                const string userPwd = "25Egi0702!";

                var chkUser = userManager.Create(user, userPwd);

                if (chkUser.Succeeded)
                {
                    var result1 = userManager.AddToRole(user.Id, "Admin");
                }
            }

            if (!roleManager.RoleExists("User"))
            {
                var role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole { Name = "User" };
                roleManager.Create(role);
            }

            // ReSharper disable once InvertIf
            if (!roleManager.RoleExists("Colab"))
            {
                var role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole { Name = "Colab" };
                roleManager.Create(role);
            }
        }
    }
}