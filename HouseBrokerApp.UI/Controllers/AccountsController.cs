using HouseBroker.Domain.Entities;
using HouseBrokerApp.UI.ViewModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace HouseBrokerApp.UI.Controllers
{
    public class AccountsController : Controller
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ILogger<AccountsController> _logger;

        public AccountsController(SignInManager<ApplicationUser> signInManager, UserManager<ApplicationUser> userManager, ILogger<AccountsController> logger)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model, string returnUrl)
        {
            if (User.Identity.IsAuthenticated)
            {
                Response.Redirect("/");
            }

            ModelState.Remove("returnUrl");
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, true);
                if (result.Succeeded)
                {
                    if (!string.IsNullOrEmpty(returnUrl))
                    {
                        return LocalRedirect(returnUrl);
                    }
                    return RedirectToAction("Index", "Property");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                }

            }
            return View(model);
        }

        [HttpGet]
        public IActionResult Register(string returnUrl = null)
        {
            if (User.Identity.IsAuthenticated)
            {
                Response.Redirect("/");
            }
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Register(UserRegistrationViewModel model)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError(string.Empty, "Please input all the required field.");
                return View(model);
            }
            var user = new ApplicationUser()
            {
                Email = model.Email,
                UserName = model.Email,
                FullName = model.FullName,
                PhoneNumber = model.PhoneNumber
            };

            var result = await _userManager.CreateAsync(user, model.Password);
            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(user, UserRole.Customer);
                await _signInManager.PasswordSignInAsync(model.Email, model.Password, false, false);
                return RedirectToAction("Login", "Account");
            }
            else
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Code + " " + error.Description);
                }
            }
            return View(model);

        }

        [HttpPost]
        public async Task<IActionResult> Logout(string? returnUrl = null)
        {
            await _signInManager.SignOutAsync();
            _logger.LogInformation(string.Empty,"Logged out successfully.");
            return RedirectToAction("Login", "Accounts", new { area = "" });
        }
    }
}
