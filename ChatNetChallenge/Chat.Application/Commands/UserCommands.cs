using Chat.Application.Interfaces;
using Chat.Domain.Entities;
using Chat.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Chat.Application.Commands
{
    public class UserCommands : IUserCommands<User>
    {
        private readonly ApplicationDBContext _context;

        public UserCommands(ApplicationDBContext context)
        {
            _context = context;
        }

        public Task InsertAsync(User model)
        {
            throw new NotImplementedException();
        }

        public Task Save()
        {
            throw new NotImplementedException();
        }
    }
}
