using Chat.Application.Commands;
using Chat.Application.Interfaces;
using Chat.Application.Models;
using Chat.Domain.Entities;
using Microsoft.Data.Sqlite;
using System;
using System.Linq;
using System.Threading.Tasks;
using Xunit;


namespace TestAPI
{
    public class TestMessageDB : TestWithSqlite
    {

        [Fact]
        public async Task DatabaseIsAvailableAndCanBeConnectedTo()
        {
            Assert.True(await DbContext.Database.CanConnectAsync());
        }

        [Fact]
        public void ShouldAddCompleteMessageToDB()
        {
            var newUser = new User()
            {
                FirstName = "Test",
                LastName = "Test",
                SecondLastName = "Test",
                Email = "Test@Test.com",
                Password = "Test123*"
            };

            DbContext.Users.Add(newUser);
            DbContext.SaveChanges();

            var newMessage = new Message()
            {
                UserEmail = newUser.Email,
                TextMessage = "Test Message",
                Date = DateTime.Now,
                UserId = newUser.Id,                
            };
            DbContext.Messages.Add(newMessage);
            DbContext.SaveChanges();

            Assert.Equal(newMessage, DbContext.Messages.Find(newMessage.Id));
            Assert.Equal(1, DbContext.Messages.Count());
        }

        [Fact]
        public void ShouldNotAddIncompleteMessageToDB()
        {
            var exceptionMessage = "";
            var newUser = new User()
            {
                FirstName = "Test",
                LastName = "Test",
                SecondLastName = "Test",
                Email = "Test@Test.com",
                Password = "Test123*"
            };

            DbContext.Users.Add(newUser);
            DbContext.SaveChanges();

            var newMessage = new Message()
            {
                //No UserEmail
                TextMessage = "Test Message",
                Date = DateTime.Now,
                UserId = newUser.Id,
            };

            try
            {
                DbContext.Messages.Add(newMessage);
                DbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                exceptionMessage = ex.InnerException.Message;
            }

            Assert.NotEmpty(exceptionMessage);
            Assert.Equal("SQLite Error 19: 'NOT NULL constraint failed: Messages.UserEmail'.", exceptionMessage);
        }


    }
}
