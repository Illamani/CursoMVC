﻿using CursoIndio.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CursoIndio.Controllers
{
    public class AccountController : Controller
    {
        public UserManager<IdentityUser> UserManager;
        public SignInManager<IdentityUser> SignInManager;
        public AccountController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            UserManager = userManager;
            SignInManager = signInManager;
        }
        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await SignInManager.SignOutAsync();
            return RedirectToAction("index", "home");
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async  Task<IActionResult> Register(RegisterViewModel model)
        {
            if(ModelState.IsValid)
            {
                var user = new IdentityUser { UserName = model.Email,Email = model.Email };
                var result = await UserManager.CreateAsync(user, model.Password);

                if(result.Succeeded)
                {
                    await SignInManager.SignInAsync(user, isPersistent: false);
                    return RedirectToAction("index", "home");
                }
                foreach(var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }
            return View(model);
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
                var result = await SignInManager.PasswordSignInAsync(model.Email, model.Password,model.RememberMe, false);

                if (result.Succeeded)
                {
                    return RedirectToAction("index", "home");
                }
                ModelState.AddModelError("","Invalid Login Attempt" );
            }

            return View(model);
        }
    }
}