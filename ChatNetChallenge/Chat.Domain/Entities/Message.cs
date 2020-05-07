using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Chat.Domain.Entities
{
    public class Message
    {
        public int Id { get; set; }
        [Required]
        public string UserEmail { get; set; }
        [Required]
        public string TextMessage { get; set; }
        public DateTime Date { get; set; }        
        public User Sender { get; set; }        
    }
}
