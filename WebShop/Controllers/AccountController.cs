using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using WebShop.Services;

namespace WebShop.Controllers
{
    [AllowAnonymous]
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
                AuthResponse result = await _accountService.LoginRequest(request);

                if (result is not null && !string.IsNullOrEmpty(result.Token))
                {
                    var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Name, result.Name),
                        new Claim(ClaimTypes.Role, result.Role ?? "U"),
                        new Claim("AuthToken", result.Token)
                    };

                    var claimsIdentity = new ClaimsIdentity(claims, "Cookies");
                    var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);
                    await HttpContext.SignInAsync("Cookies", claimsPrincipal);

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
                var res = await _accountService.RegisterRequest(request);

                if (res is AuthResponse result && !string.IsNullOrEmpty(result.Token))
                {
                    var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Name, result.Name),
                        new Claim(ClaimTypes.Role, result.Role ?? "U"),
                        new Claim("AuthToken", result.Token)
                    };

                    var claimsIdentity = new ClaimsIdentity(claims, "Cookies");
                    var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);
                    await HttpContext.SignInAsync("Cookies", claimsPrincipal);

                    return RedirectToAction("Index", "Home");
                }

                ModelState.AddModelError("", "Registration failed. Please try again.");
            }
            return View(request);
        }

        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync("Cookies");
            _accountService.ClearJWT();
            return RedirectToAction("Index", "Home");
        }
    }
}