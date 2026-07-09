using AktiviteProjesi.Context;
using AktiviteProjesi.Identity;
using AktiviteProjesi.Models;
using AktiviteProjesi.Models.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace AktiviteProjesi.Controllers
{
    public class AccountController: Controller
    {
        private readonly EventDbContext _context;
        private readonly UserManager<EventIdentityUser> _userManager;
        private readonly SignInManager<EventIdentityUser> _signInManager;
        public AccountController(EventDbContext context, UserManager<EventIdentityUser> userManager, SignInManager<EventIdentityUser> signInManager)
        {
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;
        }
        public IActionResult login()
        {

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> login(LoginViewModel model)
        {
            var user = await _userManager.FindByNameAsync(model.Email);
            if (user == null)
            {
                return View();
            }
            var result = await _signInManager.PasswordSignInAsync(user, model.Password, true, false);

            if (result.Succeeded)
            {
                return RedirectToAction("Index", "Admin");
            }
            else
            {
                return View();
            }

        }
    }
}
