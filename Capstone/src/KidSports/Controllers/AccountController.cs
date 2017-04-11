using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using KidSports.Models;
using KidSports.Models.ViewModels;
using System.Threading.Tasks;

namespace KidSports.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        private UserManager<User> userManager;
        private SignInManager<User> signInManager;

        public AccountController(UserManager<User> userMgr, SignInManager<User> signInMgr)
        {
            userManager = userMgr;
            signInManager = signInMgr;
        }

        [AllowAnonymous]
        public IActionResult Register()
        {
            return View(new RegisterViewModel());
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Register(RegisterViewModel vm)
        {
            if (ModelState.IsValid)
            {
                User user = new User
                {
                    FirstName = vm.FirstName,
                    MiddleName = vm.MiddleName,
                    LastName = vm.LastName,
                    Email = vm.Email,
                    UserName = vm.Email
                };

                IdentityResult result = await userManager.CreateAsync(user, vm.Password);

                if (result.Succeeded)
                {
                    return RedirectToAction("Login", "Account");
                }

                else
                {
                    foreach (IdentityError error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                }

            }
            return View(vm);
        }


        public IActionResult Login()
        {
            return View();
        }
    }
}
