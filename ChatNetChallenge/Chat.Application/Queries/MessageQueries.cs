using Chat.Application.Interfaces;
using Chat.Infrastructure.Data;
using Chat.Domain.Entities;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using Chat.Application.Models;
using AutoMapper;

namespace Chat.Application.Queries
{
    public class MessageQueries : IMessageQueries<MessageDTO>
    {
        private readonly ApplicationDBContext _context;
        private readonly IMapper _mapper;

        public MessageQueries(ApplicationDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<MessageDTO>> GetAll()
        {
            var listMessagesEntities = await _context.Messages.OrderByDescending(m => m.Date).Take(50).ToListAsync();
            var result = _mapper.Map<List<MessageDTO>>(listMessagesEntities);
            return result;
        }
    }
}
