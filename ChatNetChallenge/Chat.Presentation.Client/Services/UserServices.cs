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
    public class UserServices : IUserServices
    {
        private readonly ClientConfig _api;

        public UserServices()
        {
            _api = new ClientConfig();
        }

        public async Task<UserOutputDataModel> RegisterUser(UserInputDataModel model)
        {
            var responseModel = new UserOutputDataModel();
            var responseMessage = await SendUserData(model);
            if (responseMessage.IsSuccessStatusCode)
            {
                responseModel.Status = true;
                return responseModel;
            }
            else
            {
                responseModel.Status = false;
                responseModel.Error = "Server not responding";
                return responseModel;
            }
        }

        private async Task<HttpResponseMessage> SendUserData(UserInputDataModel model)
        {
            HttpClient client = _api.Initial();
            HttpResponseMessage response = new HttpResponseMessage();
            try
            {
                HttpRequestMessage requestMessage = new HttpRequestMessage(HttpMethod.Post, $"" + client.BaseAddress + "api/Users");

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
