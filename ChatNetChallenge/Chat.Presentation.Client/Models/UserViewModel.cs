using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Chat.Presentation.Client.Models
{
    public class UserViewModel
    {

        [BindProperty]
        public InputUserModel Input { get; set; }

        [TempData]
        public string ErrorMessage { get; set; }

        public class InputUserModel
        {
            [Required(ErrorMessage = "The firstname field is required.")]
            public string FirstName { get; set; }

            [Required(ErrorMessage = "The lastname field is required.")]
            public string LastName { get; set; }

            [Required(ErrorMessage = "The second lastname field is required.")]
            public string SecondLastName { get; set; }

            [Required(ErrorMessage = "The email field is required.")]
            [EmailAddress]
            public string Email { get; set; }

            [Required(ErrorMessage = "The password field is required.")]
            [DataType(DataType.Password)]
            public string Password { get; set; }
        }
    }
}
