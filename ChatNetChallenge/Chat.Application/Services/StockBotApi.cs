using Chat.Application.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Chat.Application.Services
{
    public class StockBotApi : IStockBotApi
    {
        private readonly ClientConfig _api;

        public StockBotApi()
        {
            _api = new ClientConfig();
        }

        public async Task<HttpResponseMessage> SendCommandStockBot(string text)
        {
            HttpClient client = _api.Initial();
            HttpResponseMessage response = new HttpResponseMessage();
            try
            {
                HttpRequestMessage requestMessage = new HttpRequestMessage(HttpMethod.Post, $"" + client.BaseAddress + "api/BotCommand");

                var options = new
                {
                    message = text                   
                };

                var stringData = JsonConvert.SerializeObject(options);
                var content = new StringContent(stringData, Encoding.UTF8, "application/json");
                requestMessage.Content = new StringContent(stringData, Encoding.UTF8, "application/json");
                response = await client.SendAsync(requestMessage);
                return response;
            }
            catch (Exception ex)
            {
                response.StatusCode = HttpStatusCode.InternalServerError;
                Console.WriteLine(ex);
                return response;
            }
        }
    }
}
