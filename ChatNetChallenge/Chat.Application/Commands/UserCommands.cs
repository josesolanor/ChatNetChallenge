using AutoMapper;
using Chat.Application.Interfaces;
using Chat.Application.Models;
using Chat.Domain.Entities;
using Chat.Infrastructure.Data;
using System;
using System.Threading.Tasks;

namespace Chat.Application.Commands
{
    public class UserCommands : IUserCommands<UserDTO>
    {
        private readonly ApplicationDBContext _context;
        private readonly IMapper _mapper;

        public UserCommands(ApplicationDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task Insert(UserDTO model)
        {
            var userEntity = _mapper.Map<User>(model);
            await _context.Users.AddAsync(userEntity);
        }

        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }
    }
}
