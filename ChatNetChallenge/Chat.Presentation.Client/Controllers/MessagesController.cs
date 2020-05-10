using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Chat.Presentation.Client.Interfaces;
using Chat.Presentation.Client.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Chat.Presentation.Client.Controllers
{
    public class MessagesController : Controller
    {
        private readonly IMessageServices _messageServices;

        public MessagesController(IMessageServices messageServices)
        {
            _messageServices = messageServices;
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

                return Json(JsonContext);
            }
            return BadRequest();
        }
      
    }
}