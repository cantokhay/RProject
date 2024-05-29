using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Project.Data.Entities;
using ProjectWebUI.VMs.IdentityVM;

namespace ProjectWebUI.Controllers
{
    public class SettingsController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        public SettingsController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            var userEditVM = new AppUserEditVM();
            userEditVM.Email = user.Email;
            userEditVM.FirstName = user.FirstName;
            userEditVM.LastName = user.LastName;
            userEditVM.UserName = user.UserName;
            return View(userEditVM);
        }

        [HttpPost]
        public async Task<IActionResult> Index(AppUserEditVM model)
        {
            if (model.Password == model.ConfirmPassword)
            {
                var user = await _userManager.FindByNameAsync(User.Identity.Name);
                user.Email = model.Email;
                user.FirstName = model.FirstName;
                user.LastName = model.LastName;
                user.UserName = model.UserName;
                user.PasswordHash = _userManager.PasswordHasher.HashPassword(user, model.Password);
                var result = await _userManager.UpdateAsync(user);
                return RedirectToAction("Index", "Category");
            }
            return View();
        }
    }
}
