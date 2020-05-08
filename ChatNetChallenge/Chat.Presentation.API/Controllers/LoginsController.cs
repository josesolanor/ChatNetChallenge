using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Chat.Application.Models;
using Chat.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Chat.Presentation.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginsController : ControllerBase
    {
        [HttpGet]
        public bool CheckCredentials(LoginDTO data)
        {
            return true;
        }       
    }
}
