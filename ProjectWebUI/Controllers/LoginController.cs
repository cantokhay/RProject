﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Project.Data.Entities;
using ProjectWebUI.VMs.IdentityVM;

namespace ProjectWebUI.Controllers
{
	[AllowAnonymous]
	public class LoginController : Controller
	{
		private readonly SignInManager<AppUser> _signInManager;

		public LoginController(SignInManager<AppUser> signInManager)
		{
			_signInManager = signInManager;
		}

		[HttpGet]
		public async Task<IActionResult> Index()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> Index(LoginVM loginVM)
		{
			var result = await _signInManager.PasswordSignInAsync(loginVM.UserName, loginVM.Password, false, false);
			if (result.Succeeded)
			{
				return RedirectToAction("Index", "Default");
			}
			return View();
		}

        public async Task<IActionResult> LogOut()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Default");
        }
    }
}
