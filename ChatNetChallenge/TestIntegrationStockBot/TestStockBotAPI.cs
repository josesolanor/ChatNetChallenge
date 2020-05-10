using Chat.Presentation.StockBot.Controllers;
using Chat.Presentation.StockBot.Interfaces;
using Chat.Presentation.StockBot.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Threading.Tasks;

namespace TestIntegrationStockBot
{
    [TestClass]
    public class TestStockBotAPI
    {
        [TestMethod]
        public void SendRightCommand()
        {
            var inputData = new BotCommandInputModel
            {
                Message = "/stock=aapl.us"
            };

            var mockLogicMessage = new Mock<ILogicMessage>();


            mockLogicMessage.Setup(x => x.CommandMessage(inputData.Message)).Returns(Task.FromResult("APPL.US quote is $93.42 per share”."));

            var botCommandController = new BotCommandController
            (
                mockLogicMessage.Object
            );

            var result = botCommandController.Post(inputData);

            Assert.IsInstanceOfType(result.Result, typeof(OkObjectResult));

        }
    }
}
