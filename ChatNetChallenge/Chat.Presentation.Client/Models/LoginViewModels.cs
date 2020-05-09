using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Chat.Presentation.Client.Models
{
    public class LoginViewModels
    {
        [BindProperty]
        public InputModel Input { get; set; }

        [TempData]
        public string ErrorMessage { get; set; }

        public class InputModel
        {
            [Required(ErrorMessage = "The email field is required.")]
            public string Email { get; set; }

            [Required(ErrorMessage = "The password field is required.")]
            [DataType(DataType.Password)]
            public string Password { get; set; }

        }
    }
}
