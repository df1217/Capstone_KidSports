using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using KidSports.Models;
using KidSports.Models.ViewModels;
using System.Threading.Tasks;
using KidSports.Repositories;

namespace KidSports.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        private UserManager<IdUser> userManager;
        private SignInManager<IdUser> signInManager;
        private IUserRepo userRepo;

        public AccountController(UserManager<IdUser> userMgr, SignInManager<IdUser> signInMgr, IUserRepo uRepo)
        {
            userManager = userMgr;
            signInManager = signInMgr;
            userRepo = uRepo;
        }

        #region Register
        [AllowAnonymous]
        public IActionResult Register()
        {
            return View(new RegisterViewModel());
        }

        [HttpPost]
        [AllowAnonymous]
        public IActionResult Register(RegisterViewModel vm)
        {
            if (ModelState.IsValid)
            {
                IdentityResult identityResult;
                User user = userRepo.CreateUser(vm.FirstName, vm.MiddleName, vm.LastName, vm.Email,
                    vm.Password, UserRole.Applicant, out identityResult);

                if (identityResult != null)
                {
                    if (identityResult.Succeeded)
                    {
                        return RedirectToAction("Login", "Account");
                    }
                    else
                    {
                        foreach (IdentityError error in identityResult.Errors)
                        {
                            ModelState.AddModelError("", error.Description);
                        }
                    }
                }
                else    // user already exists
                {
                    ModelState.AddModelError("", "This user is already registered");
                }
            }
            // We get here either if the model state is invalid or if create user fails
            return View(vm);
        }
        #endregion

        #region Login
        [AllowAnonymous]
        public ViewResult Login(string returnUrl)
        {
            ViewBag.returnUrl = returnUrl;
            return View(new LoginViewModel());
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login(LoginViewModel vm, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                IdUser identityUser = userRepo.GetIdUserByEmail(vm.Email);
                if (identityUser != null)
                {
                    await signInManager.SignOutAsync();
                    Microsoft.AspNetCore.Identity.SignInResult result =
                            await signInManager.PasswordSignInAsync(
                                identityUser, vm.Password, false, false);
                    if (result.Succeeded)
                    {
                        return RedirectToAction("NoApplication", "Application");
                    }
                }
                ModelState.AddModelError(nameof(LoginViewModel.Email),
                    "Invalid user or password");
            }
            return View(vm);
        }
        #endregion

        #region Logout
        [AllowAnonymous]
        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("Login", "Account");
        }
        #endregion

        #region Profile
        public IActionResult Profile()
        {
            return View();
        }
        #endregion

        #region Access Denied
        public ViewResult AccessDenied()
        {
            return View();
        }
        #endregion
    }
}
