using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Chat.Application.Interfaces
{
    public interface IStockBotApi
    {
        Task<HttpResponseMessage> SendCommandStockBot(string text);
    }
}
