﻿using System.Threading.Tasks;
using Chat.Application.Interfaces;
using Chat.Application.Models;
using Microsoft.AspNetCore.Mvc;

namespace Chat.Presentation.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserCommands<UserDTO> _userCommands;
        private readonly IUserQueries<UserDTO> _userQueries;

        public UsersController(IUserCommands<UserDTO> userCommands, IUserQueries<UserDTO> userQueries)
        {
            _userCommands = userCommands;
            _userQueries = userQueries;
        }
     
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] UserDTO data)
        {
            await _userCommands.Insert(data);
            await _userCommands.Save();
            return Ok();            
        } 
    }
}
