using Bowling_Tournament_Registration_System.Domain.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
namespace Bowling_Tournament_Registration_System.Ui.Controllers
{
	public class AuthController : Controller


	{
		private readonly IAuthService _authService;

		public AuthController(IAuthService authService)
		{
			_authService = authService;
		}


		public IActionResult Login()
		{
			return View();
		}


		[HttpPost]
		public async Task<IActionResult> Login(string username , string password) 
		{
			var result = _authService.Authenticate(username, password);

			if (!result)
			{
				TempData["Error"] = "Invalid username or password.";
				return RedirectToAction("Login");
			}

			var claims = new List<Claim> { new Claim(ClaimTypes.Name, username) };
			var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
			await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(identity));
			TempData["Success"] = "Logged in successfully!";
			return RedirectToAction("Index", "Home");
		}

		public async Task<IActionResult> Logout()
		{
			await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
			return RedirectToAction("Login");
		}
	}
}
