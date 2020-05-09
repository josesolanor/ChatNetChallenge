using Chat.Presentation.Client.Interfaces;
using Chat.Presentation.Client.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding;
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
    public class LoginServices : ILoginServices
    {
        private readonly ClientConfig _api;

        public LoginServices()
        {
            _api = new ClientConfig();
        }
        public async Task<LoginOutputDataModel> CheckCredencial(LoginInputDataModel model)
        {
            var responseModel = new LoginOutputDataModel();
            var responseMessage = await SendCredencials(model);
            if (responseMessage.IsSuccessStatusCode)
            {
                var result = responseMessage.Content.ReadAsStringAsync().Result;
                var json = JsonConvert.DeserializeObject(result);

                responseModel.APIResponse = (bool)json;
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

        public async Task<HttpResponseMessage> SendCredencials(LoginInputDataModel model)
        {
            HttpClient client = _api.Initial();
            HttpResponseMessage response = new HttpResponseMessage();
            try
            {
                HttpRequestMessage requestMessage = new HttpRequestMessage(HttpMethod.Post, $"" + client.BaseAddress + "api/Logins");

                var options = new
                {
                    Email = model.Email,
                    Password = model.Password
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
