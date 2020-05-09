using System.Threading.Tasks;
using Chat.Presentation.StockBot.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Chat.Presentation.StockBot.Controllers
{
    public class BotCommandController : ControllerBase
    {
        private readonly ILogicMessage _logicMessage;

        public BotCommandController(ILogicMessage logicMessage)
        {
            _logicMessage = logicMessage;
        }

        [HttpPost]
        public IActionResult Post([FromBody] string text)
        {
            var botResponse = _logicMessage.CommandMessage(text);
            return Ok(botResponse);
        }
    }
}