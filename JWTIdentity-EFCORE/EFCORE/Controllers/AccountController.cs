using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MVCWebApp2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCWebApp2.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly SignInManager<IdentityUser> signUser;

        public AccountController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signUser)
        {
            this.userManager = userManager;
            this.signUser = signUser;
        }
        [HttpPost]
        public async Task<IActionResult> Register()
        {
            var password = "Pa55w0rd1@";
            var user = new IdentityUser
            {
                UserName = "Abai",
                Email = "abhi@gmail.com"
            };
            var result = await userManager.CreateAsync(user, password);
            if(result.Succeeded)
            {
                // other overload of signAsync can be used where we have AuthenticationProperties there we can mention time out property of session 
                //AuthenticationProperties ap = new();
                //ap.ExpiresUtc = DateTime.UtcNow.AddMinutes(5);
                

                await signUser.SignInAsync(user, false);
                return RedirectToAction("index", "home");
            }
            return Json(user);
        }
        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await signUser.SignOutAsync();
            return RedirectToAction("index", "home");
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await userManager.FindByEmailAsync(model.Email);
                //await userManager.CheckPasswordAsync(user, model.Password);

                //AuthenticationProperties ap = new();
                //ap.ExpiresUtc = DateTime.UtcNow.AddMinutes(5);
                //ap.IsPersistent = model.RememberMe;

                //var result = await signUser.SignInAsync(user, ap);

                var result = await signUser.PasswordSignInAsync(
                    user.UserName, model.Password, model.RememberMe, false);

                if (result.Succeeded)
                {
                    return RedirectToAction("index", "home");
                }

                ModelState.AddModelError(string.Empty, "Invalid Login Attempt");
            }

            return View(model);
        }
    }
}
