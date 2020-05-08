using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Chat.Application.Models
{
    public class MessageDTO
    {        
        [Required]
        public string UserEmail { get; set; }
        [Required]
        public string TextMessage { get; set; }
        public DateTime Date { get; set; }
        public UserDTO Sender { get; set; }
    }
}
