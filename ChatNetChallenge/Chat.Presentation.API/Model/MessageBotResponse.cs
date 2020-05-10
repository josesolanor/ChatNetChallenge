using Chat.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Chat.Presentation.API.Model
{
    public class MessageBotResponse
    {
        public bool BotCommand { get; set; }
        public MessageDTO Message { get; set; }
    }
}
