using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;

namespace Chat.Application.Services
{
    public class ClientConfig
    {
        public HttpClient Initial()
        {
            var Host = Environment.GetEnvironmentVariable("SERVICE_BOT");
            var Port = Environment.GetEnvironmentVariable("SERVICE_BOT_PORT");
            var Client = new HttpClient();

            if (Host is null || Port is null)            
                //Localhost address
                Client.BaseAddress = new Uri("http://localhost:64594");            
            else            
                Client.BaseAddress = new Uri($"http://{Host}:{Port}/");
            
            Client.DefaultRequestHeaders.Accept.Clear();
            Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            return Client;
        }
    }
}
