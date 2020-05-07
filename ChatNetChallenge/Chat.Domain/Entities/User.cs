using System;
using System.Collections.Generic;
using System.ComponentModel;
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
        public string Nickname { get; set; }
        public string FirstName { get; set; }        
        public string LastName { get; set; }        
        public string SecondLastName { get; set; }       
        public int ContractNumber { get; set; }        
        public string Email { get; set; }        
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
