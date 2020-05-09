using Chat.Presentation.StockBot.Interfaces;
using Chat.Presentation.StockBot.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace Chat.Presentation.StockBot.Core.BotCommands
{
    public class StockCode : ICommandBot
    {
        private async Task<HttpResponseMessage> SendCommandStockBot(string code)
        {
            HttpClient client = new HttpClient();        
            try
            {
                HttpResponseMessage res = await client.GetAsync($"https://stooq.com/q/l/?s={code}&f=sd2t2ohlcv&h&e=csv");
                return res;
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

        public async Task<StockModel> GetMessage(string text)
        {
            StockModel responseModel = new StockModel();

            var resultString = "";
            HttpResponseMessage responseMessage = await SendCommandStockBot(text);
            if (responseMessage.IsSuccessStatusCode)
            {
                resultString = responseMessage.Content.ReadAsStringAsync().Result;
                var CSVData = resultString.Substring(resultString.IndexOf(Environment.NewLine, StringComparison.Ordinal) + 2);
                var CSVArrayData = CSVData.Split(',');

                responseModel.Symbol = CSVArrayData[0];
                responseModel.Close = double.Parse(CSVArrayData[6]);

                return responseModel;
            }
            else
            {
                return new StockModel();
            }
        }

        public async Task<string> CommandMessage(string data)
        {
            var stockData = await GetMessage(data);
            return $"{stockData.Symbol} quote is ${stockData.Close} per share";
        }
    }
}
