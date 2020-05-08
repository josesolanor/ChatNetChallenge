using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Chat.Application.Interfaces;
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
        private readonly ILoginQueries<LoginDTO> _loginQueries;

        public LoginsController(ILoginQueries<LoginDTO> loginQueries)
        {
            _loginQueries = loginQueries;            
        }

        [HttpGet]
        public async Task<IActionResult> CheckCredentials(LoginDTO data)
        {
            var result = await _loginQueries.CheckCredencial(data);
            return Ok(result);
        }       
    }
}
