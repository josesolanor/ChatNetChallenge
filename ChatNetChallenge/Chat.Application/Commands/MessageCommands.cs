using Chat.Application.Interfaces;
using Chat.Domain.Entities;
using Chat.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Chat.Application.Commands
{
    class MessageCommands : IMethodsCommands<Message>
    {
        private readonly ApplicationDBContext _context;

        public MessageCommands(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task InsertAsync(Message model)
        {
            await _context.Messages.AddAsync(model);
        }

        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }
    }
}