using AutoMapper;
using Chat.Application.Interfaces;
using Chat.Application.Models;
using Chat.Domain.Entities;
using Chat.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
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

        public Task<List<UserDTO>> GetAll()
        {
            throw new NotImplementedException();
        }

        public async Task<UserDTO> GetByEmail(string email)
        {
            var userEntity = await _context.Users.FirstOrDefaultAsync(x => x.Email.Equals(email));
            var result = _mapper.Map<UserDTO>(userEntity);
            return result;
        }
    }
}
