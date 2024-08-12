using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using WebApplication1.ViewModels;

namespace WebApplication1.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;

        public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }
        [HttpGet]
        public IActionResult LogIn()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> LogIn(LoginUserViewModel UserViewModel)
        {
            if (ModelState.IsValid)
            {
                ApplicationUser user = await userManager.FindByNameAsync(UserViewModel.UserName);
                if (user != null)
                {
                    bool found = await userManager.CheckPasswordAsync(user, UserViewModel.PassWord);

                    if (found)
                    {
                        // create cookie 
                        await signInManager.SignInAsync(user, UserViewModel.RememberMe);
                        return RedirectToAction("Index", "Home");
                    }
                    else { ModelState.AddModelError("", "Password or Username wrong"); }
                }
            }
            return View(UserViewModel);
        }
        public IActionResult LogOut()
        {
            signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult Registure() => View();

        [HttpPost]
        public async Task<IActionResult> Registure(RegistureUserViewModel newUserVm)
        {
            if (ModelState.IsValid)
            {
                ApplicationUser userModel = new ApplicationUser();
                userModel.UserName = newUserVm.UserName;
                userModel.PasswordHash = newUserVm.Password;
                userModel.Address = newUserVm.Address;

                //save in db 
                IdentityResult result = await userManager.CreateAsync(userModel, newUserVm.Password);
                if (result.Succeeded)
                {
                    // assign role student to any registration   
                    await userManager.AddToRoleAsync(userModel, "student");
                    // create cookie 
                    await signInManager.SignInAsync(userModel, isPersistent: false);
                    return RedirectToAction("Index", "Instructor");
                }
                else
                {
                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError("Errors", item.Description);
                    }
                }

            }
            return View(newUserVm);
        }
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> AddAdmin()
        {
            return View();
        }

        [HttpPost]
        [Authorize(Roles ="Admin")]
        public async Task<IActionResult> AddAdmin(RegistureUserViewModel newUserVm)
        {
            if (ModelState.IsValid)
            {
                ApplicationUser userModel = new ApplicationUser();
                userModel.UserName = newUserVm.UserName;
                userModel.PasswordHash = newUserVm.Password;
                userModel.Address = newUserVm.Address;

                //save in db 
                IdentityResult result = await userManager.CreateAsync(userModel, newUserVm.Password);
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(userModel, "Admin");
                    // create cookie 
                    return RedirectToAction("Index", "Instructor");
                }
                else
                {
                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError("Errors", item.Description);
                    }
                }
            }
            return View(newUserVm);
        }
    
    
    }
}
