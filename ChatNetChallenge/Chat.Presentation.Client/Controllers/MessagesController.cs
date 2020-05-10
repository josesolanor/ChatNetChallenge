using System.Threading.Tasks;
using Chat.Presentation.Client.Hubs;
using Chat.Presentation.Client.Interfaces;
using Chat.Presentation.Client.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Newtonsoft.Json;

namespace Chat.Presentation.Client.Controllers
{
    [Authorize]
    public class MessagesController : Controller
    {
        private readonly IMessageServices _messageServices;
        private readonly IHubContext<ChatHub> _hubContext;

        public MessagesController(IMessageServices messageServices, IHubContext<ChatHub> hubContext)
        {
            _messageServices = messageServices;
            _hubContext = hubContext;
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> GetAllChatMessages()
        {
            var messages = await _messageServices.GetAllMessages();         
            string JsonContext = JsonConvert.SerializeObject(messages, Formatting.Indented, new JsonSerializerSettings()
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });

            return Json(JsonContext);
        }

        [HttpPost]
        public async Task<IActionResult> SendMessage(MessageInputDataModel model)
        {
            if (ModelState.IsValid)
            {
                var messageSend = await _messageServices.SendMessage(model);

                if (!messageSend.Status)
                {
                    return RedirectToAction("Create");
                }
                string JsonContext = JsonConvert.SerializeObject(messageSend, Formatting.Indented, new JsonSerializerSettings()
                {
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                });

                await _hubContext.Clients.All.SendAsync("Message", JsonContext);
                return Ok();
            }
            return BadRequest();
        }
      
    }
}