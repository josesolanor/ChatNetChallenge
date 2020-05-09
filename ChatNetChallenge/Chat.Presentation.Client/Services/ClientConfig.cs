using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace Chat.Presentation.Client.Services
{
    public class ClientConfig
    {
        public HttpClient Initial()
        {
            var Host = Environment.GetEnvironmentVariable("SERVICE_API");
            var Port = Environment.GetEnvironmentVariable("SERVICE_API_PORT");
            var Client = new HttpClient();

            if (Host is null || Port is null)
                //Localhost address
                Client.BaseAddress = new Uri("http://localhost:64536");
            else
                Client.BaseAddress = new Uri($"http://{Host}:{Port}/");

            Client.DefaultRequestHeaders.Accept.Clear();
            Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            return Client;
        }
    }
}
