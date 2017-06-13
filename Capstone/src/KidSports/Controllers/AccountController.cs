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
        private UserManager<User> userManager;
        private SignInManager<User> signInManager;
        private IUserRepo userRepo;

        public AccountController(UserManager<User> userMgr, SignInManager<User> signInMgr, IUserRepo uRepo)
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
        public async Task<IActionResult> Register(RegisterViewModel vm)
        {
            if (ModelState.IsValid)
            {
                IdentityResult result;
                User user = userRepo.CreateUser(vm.FirstName, vm.MiddleName, vm.LastName, vm.Email,
                    vm.Password, UserRole.Applicant, out result);

                if (result != null)
                {
                    if (result.Succeeded)
                    {

                        User identityUser = userRepo.GetUserByEmail(vm.Email);
                        if (identityUser != null)
                        {
                            await signInManager.SignOutAsync();
                            Microsoft.AspNetCore.Identity.SignInResult login =
                                    await signInManager.PasswordSignInAsync(
                                        identityUser, vm.Password, false, false);

                            if (login.Succeeded)
                            {
                               return RedirectToAction("Index", "Application");
                            }
                        }
                       
                    }
                    return View(vm);
                }
                else
                {
                    foreach (IdentityError error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                }
            }
            else    // user already exists
            {
                ModelState.AddModelError("", "This user is already registered");
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
                User identityUser = userRepo.GetUserByEmail(vm.Email);
                if (identityUser != null)
                {
                    await signInManager.SignOutAsync();
                    Microsoft.AspNetCore.Identity.SignInResult result =
                            await signInManager.PasswordSignInAsync(
                                identityUser, vm.Password, false, false);

                    if (result.Succeeded)
                    {
                        var isAdmin = await userManager.IsInRoleAsync(identityUser, "Admin");
                        var isSportsManager = await userManager.IsInRoleAsync(identityUser, "SportsManager");

                        if (isAdmin)
                            return RedirectToAction("Applications", "Application");
                        else if (isSportsManager)
                            return RedirectToAction("Applications", "Application");
                        else
                            return RedirectToAction("Index", "Application");
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
