using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Chat.Presentation.Client.Core;
using Chat.Presentation.Client.Interfaces;
using Chat.Presentation.Client.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Chat.Presentation.Client.Controllers
{
    public class UsersController : Controller
    {
        private readonly IUserServices _userServices;
        private readonly Hash _hash;
        public UsersController(Hash hash, IUserServices userServices)
        {
            _hash = hash;
            _userServices = userServices;
        }

        [AllowAnonymous]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(UserViewModel model)
        {
            if (ModelState.IsValid)
            {
                var userModelInputData = new UserInputDataModel
                {
                    FirstName = model.Input.FirstName,
                    LastName = model.Input.LastName,
                    SecondLastName = model.Input.SecondLastName,
                    Email = model.Input.Email,
                    Password = _hash.EncryptString(model.Input.Password)                    
                };

                var registerUser = await _userServices.RegisterUser(userModelInputData);

                if (!registerUser.Status)
                {
                    model.ErrorMessage = registerUser.Error;
                    return View(model);
                }

                return RedirectToAction("Index", "Logins");
            }
            return View(model);            
        }      
    }
}