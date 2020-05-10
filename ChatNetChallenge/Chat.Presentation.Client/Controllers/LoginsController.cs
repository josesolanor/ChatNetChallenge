using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using Chat.Presentation.Client.Core;
using Chat.Presentation.Client.Interfaces;
using Chat.Presentation.Client.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Chat.Presentation.Client.Controllers
{
    public class LoginsController : Controller
    {

        private readonly ILoginServices _loginServices;
        private readonly Hash _hash;
        public LoginsController(Hash hash, ILoginServices loginServices)
        {
            _hash = hash;
            _loginServices = loginServices;
        }

        [AllowAnonymous]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Index(LoginViewModels model)
        {
            if (ModelState.IsValid)
            {
                var loginModelInputData = new LoginInputDataModel
                {
                    Email = model.Input.Email,                    
                    Password = _hash.EncryptString(model.Input.Password)
                };

                var login = await _loginServices.CheckCredencial(loginModelInputData);

                if (!login.Status)
                {
                    model.ErrorMessage = login.Error;
                    return View(model);
                }

                if (!login.APIResponse)
                {
                    model.ErrorMessage = "Incorrect credentials";
                    return View(model);
                }

                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Email, model.Input.Email)
                };

                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var authProperties = new AuthenticationProperties();
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity), authProperties);

                return RedirectToAction("Create", "Messages");
            }
            model.ErrorMessage = "Wrong Data";
            return View(model);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction("Index", "Login");
        }
    }
}