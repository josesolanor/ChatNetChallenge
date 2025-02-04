﻿using AutoMapper;
using Chat.Application.Interfaces;
using Chat.Application.Models;
using Chat.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Chat.Application.Queries
{
    public class UserQueries : IUserQueries<UserDTO>
    {
        private readonly ApplicationDBContext _context;
        private readonly IMapper _mapper;

        public UserQueries(ApplicationDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<UserDTO> GetByEmail(string email)
        {
            var userEntity = await _context.Users.FirstOrDefaultAsync(x => x.Email.Equals(email));
            var result = _mapper.Map<UserDTO>(userEntity);
            return result;
        }
    }
}
