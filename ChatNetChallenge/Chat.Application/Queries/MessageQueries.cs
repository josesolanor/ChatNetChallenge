using Chat.Application.Interfaces;
using Chat.Infrastructure.Data;
using Chat.Domain.Entities;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using Chat.Application.Models;
using AutoMapper;
using Newtonsoft.Json;

namespace Chat.Application.Queries
{
    public class MessageQueries : IMessageQueries<MessageDTO>
    {
        private readonly ApplicationDBContext _context;
        private readonly IMapper _mapper;
        private readonly IStockBotApi _stockBotApi;

        public MessageQueries(ApplicationDBContext context, IMapper mapper, IStockBotApi stockBotApi)
        {
            _context = context;
            _mapper = mapper;
            _stockBotApi = stockBotApi;
        }

        public async Task<List<MessageDTO>> GetAll()
        {
            var listMessagesEntities = await _context.Messages.Include(x => x.User).OrderBy(m => m.Date).Take(50).ToListAsync();
            var result = _mapper.Map<List<MessageDTO>>(listMessagesEntities);
            return result;
        }

        public async Task<string> GetBotResponse(string text)
        {            
            var responseMessage = await _stockBotApi.SendCommandStockBot(text);
            if (responseMessage.IsSuccessStatusCode)
            {
                var result = responseMessage.Content.ReadAsStringAsync().Result;
                var json = JsonConvert.DeserializeObject(result);
                return json.ToString();
            }
            else
                return "StockBot not responding";            
        }
    }
}
