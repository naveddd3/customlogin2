using customlogin2.Models;
using customlogin2.ViewModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace customlogin2.Controllers
{
    public class AccountController : Controller
    {
        private readonly SignInManager<AppUser> signInManager; 
        private readonly UserManager<AppUser> userManager;

        public AccountController(SignInManager<AppUser> signInManager,UserManager<AppUser> userManager)
        {
            this.signInManager = signInManager;
            this.userManager = userManager;
        }

        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginVM model)

        {
            if(ModelState.IsValid)
            {
                var result = await signInManager.PasswordSignInAsync(model.Username!,model.Password!,model.RememberMe,false);
                if(result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");

                }
                ModelState.AddModelError("", "Invalid Login");
                return View(model);
            }
            return View(model);
        }
        public IActionResult Registration()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Registration(RegistrationVM registrationVM)
        {
            if (ModelState.IsValid)
            {
                AppUser user = new()
                {
                    Name = registrationVM.Name,
                    UserName = registrationVM.Email,
                    Email = registrationVM.Email,
                    Address = registrationVM.Address,
                };
                var result = await userManager.CreateAsync(user,registrationVM.Password);
                if(result.Succeeded)
                {
                    await signInManager.SignInAsync(user, false);
                    return RedirectToAction("Index","Home");
                }
                foreach(var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }
            return View(registrationVM);
        }

        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("Index","Home");
        }
    }
}
