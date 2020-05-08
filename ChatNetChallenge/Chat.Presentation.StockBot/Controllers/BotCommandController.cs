using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Chat.Presentation.StockBot.Controllers
{
    public class BotCommandController : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] string text)
        {
            return Ok(text);
        }
    }
}