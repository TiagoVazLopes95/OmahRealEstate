using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OmahRealEstate.Web.Data.Entities;
using OmahRealEstate.Web.Helpers;
using OmahRealEstate.Web.Models;
using System.Security.Claims;
using System.Threading.Tasks;

namespace OmahRealEstate.Web.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUserHelper _userHelper;

        public AccountController(IUserHelper userHelper)
        {
            _userHelper = userHelper;
        }

        public IActionResult Login()
        {
            if(User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Home");
            }

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if(ModelState.IsValid)
            {
                var result = await _userHelper.LoginAsync(model);

                if(result.Succeeded)
                {
                    var user = await _userHelper.GetUserByEmailAsync(model.UserName);

                    await AddUserClaims(user);

                    if (this.Request.Query.Keys.Contains("ReturnUrl"))
                    {
                        return Redirect(this.Request.Query["ReturnUrl"].First());
                    }

                    return this.RedirectToAction("Index", "Home");
                }
            }

            this.ModelState.AddModelError(string.Empty, "Failed to Login");

            return View(model);
        }

        public async Task<IActionResult> Logout()
        {
            await _userHelper.LogoutAsync();
            return RedirectToAction("Index", "Home");
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterUserViewModel model)
        {
            if(ModelState.IsValid)
            {
                var user = await _userHelper.GetUserByEmailAsync(model.UserName);

                if(user == null)
                {
                    user = new User
                    {
                        FirstName = model.FirstName,
                        LastName = model.LastName,
                        Email = model.UserName,
                        UserName = model.UserName,
                        Age = model.Age,
                        City = model.City,
                    };

                    var result = await _userHelper.AddUserAsync(user, model.Password);

                    if(!result.Succeeded)
                    {
                        ModelState.AddModelError(string.Empty, "The user couldn't be created.");
                        return View(model);
                    }

                    var loginviewmodel = new LoginViewModel
                    {
                        Password = model.Password,
                        RememberMe = false,
                        UserName = model.UserName
                    };

                    var result2 = await _userHelper.LoginAsync(loginviewmodel);

                    if(result2.Succeeded)
                    {
                        await AddUserClaims(user);
                        return RedirectToAction("Index","Home");
                    }

                    ModelState.AddModelError(string.Empty, "The user couldn't be logged in.");
                    
                }
            }

            return View(model);
        }

        public async Task<IActionResult> UserProfile()
        {
            var user = await _userHelper.GetUserByEmailAsync(this.User.Identity.Name);
            
            var model = new ChangeUserViewModel();
            
            if (user != null)
            {
                model.FirstName = user.FirstName;
                model.LastName = user.LastName;
                model.PhoneNumber = user.PhoneNumber;
                model.Age = user.Age;
                model.City = user.City;
            }

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> UserProfile(ChangeUserViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userHelper.GetUserByEmailAsync(this.User.Identity.Name);

                if (user != null)
                {
                    user.FirstName = model.FirstName;
                    user.LastName = model.LastName;
                    user.PhoneNumber = model.PhoneNumber;
                    user.Age = model.Age;
                    user.City = model.City;

                    var response = await _userHelper.UpdateUserAsync(user);

                    await AddUserClaims(user);

                    if (response.Succeeded)
                    {
                        return RedirectToAction("UserProfile");
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, response.Errors.FirstOrDefault().Description);
                    }

                }

            }
            ViewData["ActiveTab"] = "profile-settings";
            return View(model);

        }

        public IActionResult ChangePassword()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ChangePassword(ChangePasswordViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userHelper.GetUserByEmailAsync(this.User.Identity.Name);
                if (user != null)
                {
                    var result = await _userHelper.ChangePasswordAsync(user, model.OldPassword, model.NewPassword);
                    if (result.Succeeded)
                    {
                        return RedirectToAction("UserProfile");
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, result.Errors.FirstOrDefault().Description);
                    }
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "User not found.");
                }
            }
            ViewData["ActiveTab"] = "change-password";
            return View(model);
        }

        public async Task AddUserClaims(User user)
        {
            var claims = new List<Claim>
            {
                new Claim("FirstName", user.FirstName),
                new Claim("LastName", user.LastName),
                new Claim("Age", user.Age.ToString()),
                new Claim("City", user.City),
            };

            await _userHelper.CreateUserClaims(user, false, claims);
        }
    }
}
