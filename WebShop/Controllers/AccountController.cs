﻿using Microsoft.AspNetCore.Mvc;
using WebShop.Services;

namespace WebShop.Controllers
{
    public class AccountController : Controller
    {
        private readonly AccountService _accountService;

        public AccountController(AccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginRequest request)
        {
            if (ModelState.IsValid)
            {
                LoginResponse result = await _accountService.LoginRequest(request);

                if (result is not null)
                {
                    return RedirectToAction("Index", "Home");
                }

                ModelState.AddModelError("", "Invalid login attempt. Please try again.");
            }

            return View(request);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterRequest request)
        {
            if (ModelState.IsValid)
            {
                RegisterResponse result = await _accountService.RegisterRequest(request);

                if (result is not null)
                {
                    return RedirectToAction("Success");
                }

                ModelState.AddModelError("", "Registration failed. Please try again.");
            }

            return View(request);
        }
    }
}