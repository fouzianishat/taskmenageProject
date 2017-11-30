
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Owin;
using NewTask.Models;

[assembly: OwinStartupAttribute(typeof(NewTask.Startup))]
namespace NewTask
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            CreateUserRole();
        }
        public void CreateUserRole()
        {
            ApplicationDbContext context = new ApplicationDbContext();
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
            if (!roleManager.RoleExists("ITAdmin"))
            {
                var role = new IdentityRole("ITAdmin");
                roleManager.Create(role);
                var user = new ApplicationUser();
                user.UserName = "Fouzia@gmail.com";
                user.Email = "Fouzia@gmail.com";
                string pass = "Fouzia@gamil.com123";

                var newUser = userManager.Create(user, pass);
                if (newUser.Succeeded)
                {
                    userManager.AddToRole(user.Id, "ITAdmin");
                }


            }
        }
    }
}




 