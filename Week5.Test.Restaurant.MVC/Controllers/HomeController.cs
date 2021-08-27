using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Week5.Test.Restaurant.Core.Repositories;
using Week5.Test.Restaurant.MVC.Models;

namespace Week5.Test.Restaurant.MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IBusinessLayer mainBL;

        public HomeController(ILogger<HomeController> logger, IBusinessLayer mainBL)
        {
            _logger = logger;
            this.mainBL = mainBL;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Login(string returnUrl)
        {
            return View(new UserViewModel() { 
                ReturnURL = returnUrl
            });
        }

        [HttpPost]
        public async Task<IActionResult> Login(UserViewModel userVM)
        {
            if (userVM == null)
                return View("Error", new ErrorViewModel());
            if(String.IsNullOrEmpty(userVM.Username))
                return View(userVM);
            var user = mainBL.GetUser(userVM.Username);
            if (user != null && ModelState.IsValid)
            {
                if (user.Password.Equals(userVM.Password))
                {
                    var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Name, userVM.Username),
                        new Claim(ClaimTypes.Role, user.Role())
                    };

                    var authProperties = new AuthenticationProperties()
                    {
                        ExpiresUtc = DateTimeOffset.UtcNow.AddMinutes(30),
                        RedirectUri = userVM.ReturnURL
                    };

                    var claimsIdentity = new ClaimsIdentity(claims,
                        CookieAuthenticationDefaults.AuthenticationScheme);
                    await HttpContext.SignInAsync(
                        CookieAuthenticationDefaults.AuthenticationScheme,
                        new ClaimsPrincipal(claimsIdentity),
                        authProperties
                        );
                    return Redirect("/");
                }
            }

            ViewData["LoginError"] = "Invalid Username or Password";
            return View();
        }

        
        [HttpPost]
        public async Task<IActionResult> Register(UserViewModel userVM)
        {
            if (! ModelState.IsValid)
                return View("Login", userVM);
            var userExisting = mainBL.GetUser(userVM.Username);
            if(userExisting != null)
            {
                ViewData["LoginError"] = "Username already existing";
                return View("Login");
            }

            var user = new Core.Models.User()
            {
                Username = userVM.Username,
                Password = userVM.Password,
                IsOwner = false
            };
            var result = mainBL.RegisterUser(user);

            if (result)
            {
                var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Name, userVM.Username),
                        new Claim(ClaimTypes.Role, user.Role())
                    };

                var authProperties = new AuthenticationProperties()
                {
                    ExpiresUtc = DateTimeOffset.UtcNow.AddMinutes(30),
                    RedirectUri = userVM.ReturnURL
                };

                var claimsIdentity = new ClaimsIdentity(claims,
                    CookieAuthenticationDefaults.AuthenticationScheme);
                await HttpContext.SignInAsync(
                    CookieAuthenticationDefaults.AuthenticationScheme,
                    new ClaimsPrincipal(claimsIdentity),
                    authProperties
                    );
                return Redirect("/");
            }
            return View();
        }


        public IActionResult Forbidden()
        {
            return View();
        }
        
        public async Task<IActionResult> Logout()
        {

            await HttpContext.SignOutAsync();

            return Redirect("/");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
