using AutoMapper;
using Chat.Application.Interfaces;
using Chat.Application.Models;
using Chat.Domain.Entities;
using Chat.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Chat.Application.Commands
{
    public class MessageCommands : IMessageCommands<MessageDTO>
    {
        private readonly ApplicationDBContext _context;
        private readonly IMapper _mapper;

        public MessageCommands(ApplicationDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task Insert(MessageDTO model)
        {
            var messageEntity = _mapper.Map<Message>(model);
            await _context.Messages.AddAsync(messageEntity);
        }

        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }

        public bool CheckBotCommand(string text)
        {
            if (text.Trim()[0] == '/')
                return true;            
            return false;
        }
    }
}