using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Chat.Presentation.Client.Models
{
    public class MessageOutputDataModel
    {
        public string UserEmail { get; set; }
        public string TextMessage { get; set; }
        public DateTime Date { get; set; }
        public int UserId { get; set; }
        public UserMessageDataModel User { get; set; }
        public bool Status { get; set; }
    }

    public class UserMessageDataModel
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string FullName { get; set; }        
    }
}
