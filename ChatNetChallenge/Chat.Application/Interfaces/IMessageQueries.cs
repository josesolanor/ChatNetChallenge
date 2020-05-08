using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Chat.Application.Interfaces
{
    public interface IMessageQueries<T>
    {
        Task<List<T>> GetAll();
        Task<string> GetBotResponse(string text);
    }
}
