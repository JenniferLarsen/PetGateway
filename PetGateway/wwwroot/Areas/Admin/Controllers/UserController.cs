using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using PetGateway.Models;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace PetGateway.Areas.Admin.Controllers
{
    [Authorize(Role = "Admin")]
    [Area("Admin")]
    public class UserController : Controller
    {
        private UserManager<User> userManager;
        private RoleManager<IdentityRole> roleManager;

        public UserController(UserManager<User> userMngr,
            RoleManager<IdentityRole> roleMngr)
        {
            userManager = userMngr;
            roleManager = roleMngr;
        }

        public async Task<IActionResult> Index()
        {
            List<User> users = new List<User>();
            foreach (UserController user in userManager.Users)
            {
                user.RoleNames = await userManager.GetRolesAsync(user);
                users.Add(user);
            }
            UserViewModel model = new UserViewModel
            {
                users = users,
                Roles = roleManager.Roles
            };
            return View(model);
        }
    }
}
