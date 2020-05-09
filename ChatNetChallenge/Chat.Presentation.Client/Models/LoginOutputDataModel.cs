using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Chat.Presentation.Client.Models
{
    public class LoginOutputDataModel
    {
        public bool APIResponse { get; set; }
        public bool Status { get; set; }
        public string Error { get; set; }
    }
}
