using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Chat.Application.Models
{
    public class UserDTO
    {
        public int Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string SecondLastName { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        public string FullName
        {
            get
            {
                string FullNameCommisioner = $"{FirstName} {LastName} {SecondLastName}";
                return FullNameCommisioner;
            }
        }
        //public ICollection<MessageDTO> Messages { get; set; }
    }
}
