using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Chat.Domain.Entities
{
   public class User
   {
        public User()
        {
            Messages = new HashSet<Message>();
        }
        public int Id { get; set; }        
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string SecondLastName { get; set; }              
        [Required]
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
        public ICollection<Message> Messages { get; set; }
    }
}
