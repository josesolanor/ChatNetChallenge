using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Chat.Application.Interfaces;
using Chat.Application.Models;
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
        public MessagesController(IMessageQueries<MessageDTO> messageQueries, IMessageCommands<MessageDTO> messageCommands)
        {
            _messageCommands = messageCommands;
            _messageQueries = messageQueries;
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
            await _messageCommands.Insert(data);
            await _messageCommands.Save();
            return Ok();
        }
    }
}
