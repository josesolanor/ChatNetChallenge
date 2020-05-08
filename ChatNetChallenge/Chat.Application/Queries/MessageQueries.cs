﻿using Chat.Application.Interfaces;
using Chat.Infrastructure.Data;
using Chat.Domain.Entities;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Chat.Application.Queries
{
    class MessageQueries : IMessageQueries<Message>
    {
        private readonly ApplicationDBContext _context;

        public MessageQueries(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<List<Message>> GetAll()
        {
            var result = await _context.Messages.OrderByDescending(m => m.Date).Take(50).ToListAsync();
            return result;
        }
    }
}
