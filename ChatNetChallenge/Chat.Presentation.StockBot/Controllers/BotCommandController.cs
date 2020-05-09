using System.Threading.Tasks;
using Chat.Presentation.StockBot.Interfaces;
using Chat.Presentation.StockBot.Model;
using Microsoft.AspNetCore.Mvc;

namespace Chat.Presentation.StockBot.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BotCommandController : ControllerBase
    {
        private readonly ILogicMessage _logicMessage;

        public BotCommandController(ILogicMessage logicMessage)
        {
            _logicMessage = logicMessage;
        }

        [HttpPost]
        public async Task<IActionResult> Post(BotCommandInputModel model)
        {
            var botResponse = await _logicMessage.CommandMessage(model.Message);
            return Ok(botResponse);
        }
    }
}