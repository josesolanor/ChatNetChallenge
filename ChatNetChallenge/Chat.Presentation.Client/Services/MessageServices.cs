using Chat.Presentation.Client.Interfaces;
using Chat.Presentation.Client.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Chat.Presentation.Client.Services
{
    public class MessageServices : IMessageServices
    {
        private readonly ClientConfig _api;

        public MessageServices()
        {
            _api = new ClientConfig();
        }

        public async Task<List<MessageOutputDataModel>> GetAllMessages()
        {
            var responseData = await GetMessagesFromAPI();
            if (responseData.IsSuccessStatusCode)
            {
                var responseContent = await responseData.Content.ReadAsStringAsync();                
                var messagesData = JsonConvert.DeserializeObject<List<MessageOutputDataModel>>(responseContent);
                return messagesData;
            }
            else
            {
                return new List<MessageOutputDataModel>();
            }
        }

        public async Task<MessageOutputDataModel> SendMessage(MessageInputDataModel model)
        {
            var responseData = await GetMessagesFromAPI();
            if (responseData.IsSuccessStatusCode)
            {
                var responseContent = await responseData.Content.ReadAsStringAsync();
                var messagesData = JsonConvert.DeserializeObject<MessageOutputDataModel>(responseContent);
                return messagesData;
            }
            else
            {
                return new MessageOutputDataModel();
            }
        }

        private async Task<HttpResponseMessage> GetMessagesFromAPI()
        {
            HttpClient client = _api.Initial();
            try
            {
                HttpResponseMessage response = await client.GetAsync("api/Messages");
                return response;
            }
            catch (Exception)
            {
                HttpResponseMessage message = new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.InternalServerError
                };
                return message;
            }

        }
        private async Task<HttpResponseMessage> SendMessageToAPI(MessageInputDataModel model)
        {
            HttpClient client = _api.Initial();
            HttpResponseMessage response = new HttpResponseMessage();
            try
            {
                HttpRequestMessage requestMessage = new HttpRequestMessage(HttpMethod.Post, $"" + client.BaseAddress + "api/Messages");

                var stringData = JsonConvert.SerializeObject(model);
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
