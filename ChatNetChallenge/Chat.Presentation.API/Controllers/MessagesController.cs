using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Chat.Application.Interfaces;
using Chat.Application.Models;
using Chat.Presentation.API.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Chat.Presentation.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessagesController : ControllerBase
    {
        private readonly IMessageCommands<MessageDTO> _messageCommands;
        private readonly IMessageQueries<MessageDTO> _messageQueries;
        private readonly IUserQueries<UserDTO> _userQueries;
        public MessagesController(IMessageQueries<MessageDTO> messageQueries,
            IMessageCommands<MessageDTO> messageCommands,
            IUserQueries<UserDTO> userQueries)
        {
            _messageCommands = messageCommands;
            _messageQueries = messageQueries;
            _userQueries = userQueries;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await _messageQueries.GetAll();
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] MessageDTO data)
        {
            if (_messageCommands.CheckBotCommand(data.TextMessage))
            {
                var botMessage = await _messageQueries.GetBotResponse(data.TextMessage.ToLower());
                var option = new MessageDTO
                {
                    UserEmail = "Bot@Bot.com",
                    TextMessage = botMessage,
                    Date = DateTime.Now,
                    User = new UserDTO
                    {
                        FirstName = "Bot",
                        Email = "Bot@Bot.com"
                    }
                };
                return Ok(option);
            }

            var userDTO = await _userQueries.GetByEmail(data.UserEmail);
            if (userDTO is null)
                return NotFound();
            data.UserId = userDTO.Id;
            data.Date = DateTime.Now;
            await _messageCommands.Insert(data);
            await _messageCommands.Save();
            data.User = userDTO;
            return Ok(data);
        }

    }
}
