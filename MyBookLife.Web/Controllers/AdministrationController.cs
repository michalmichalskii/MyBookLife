using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace MyBookLife.Web.Controllers
{
    [Authorize (Roles = "Admin")]
    public class AdministrationController :Controller
    {
        private readonly UserManager<IdentityUser> _userManager;

        public AdministrationController(UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpGet]
        public IActionResult GetListUsers()
        {
            var users = _userManager.Users;
            return View(users);
        }
    }
}
