using Chat.Application.Interfaces;
using Chat.Application.Models;
using Chat.Domain.Entities;
using Chat.Presentation.API.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.Options;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using NuGet.Frameworks;
using System;
using System.Reflection.Emit;
using System.Threading.Tasks;

namespace TestIntegrationAPI
{
    [TestClass]
    public class TestMessageAPI
    {
        [TestMethod]
        public void SendNormalUserMessage()
        {
            var inputData = new MessageDTO
            {
                TextMessage = "Testing",
                UserEmail = "Test@Test.com"

            };

            var user = new UserDTO
            { 
                Id = 1,
                FirstName = "Test",
                LastName = "Test",
                SecondLastName = "Test",
                Email = "Test@Test.com",
                Password = "Test123*"
            };

            var message = new MessageDTO
            {
                UserEmail = inputData.UserEmail,
                TextMessage = "Testing",
                Date = DateTime.Now,
                UserId = user.Id,
                User = user
            };

            var mockMessageQueries = new Mock<IMessageQueries<MessageDTO>>();
            var mockMessageCommands = new Mock<IMessageCommands<MessageDTO>>();
            var mockUserQueries = new Mock<IUserQueries<UserDTO>>();

            mockMessageCommands.Setup(x => x.CheckBotCommand(inputData.TextMessage)).Returns(false);
            mockMessageCommands.Setup(x => x.Insert(message)).Returns(Task.FromResult(""));
            mockMessageCommands.Setup(x => x.Save()).Returns(Task.FromResult(""));            
            mockUserQueries.Setup(x => x.GetByEmail(inputData.UserEmail)).Returns(Task.FromResult(user));

            var messageController = new MessagesController
            (
                mockMessageQueries.Object,
                mockMessageCommands.Object, 
                mockUserQueries.Object
            );

            var result = messageController.Post(inputData);

            Assert.IsInstanceOfType(result.Result, typeof(OkObjectResult));

        }

        [TestMethod]
        public void SendCommandUserMessage()
        {
            var inputData = new MessageDTO
            {
                TextMessage = "/stock=aapl.us",
                UserEmail = "Test@Test.com"

            };

            var user = new UserDTO
            {
                Id = 1,
                FirstName = "Test",
                LastName = "Test",
                SecondLastName = "Test",
                Email = "Test@Test.com",
                Password = "Test123*"
            };

            var message = new MessageDTO
            {
                UserEmail = inputData.UserEmail,
                TextMessage = "Testing",
                Date = DateTime.Now,
                UserId = user.Id,
                User = user
            };

            var mockMessageQueries = new Mock<IMessageQueries<MessageDTO>>();
            var mockMessageCommands = new Mock<IMessageCommands<MessageDTO>>();
            var mockUserQueries = new Mock<IUserQueries<UserDTO>>();

            mockMessageCommands.Setup(x => x.CheckBotCommand(inputData.TextMessage)).Returns(true);
            mockMessageQueries.Setup(x => x.GetBotResponse(inputData.TextMessage)).Returns(Task.FromResult("APPL.US quote is $93.42 per share”."));            

            var messageController = new MessagesController
            (
                mockMessageQueries.Object,
                mockMessageCommands.Object,
                mockUserQueries.Object
            );

            var resultado = messageController.Post(inputData);

            Assert.IsInstanceOfType(resultado.Result, typeof(OkObjectResult));



        }
    }
}
