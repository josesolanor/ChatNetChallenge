using Chat.Domain.Entities;
using Microsoft.Data.Sqlite;
using System;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace TestAPI
{
    public class TestUserDB : TestWithSqlite
    {
        [Fact]
        public async Task DatabaseIsAvailableAndCanBeConnectedTo()
        {
            Assert.True(await DbContext.Database.CanConnectAsync());
        }

        [Fact]
        public void ShouldAddCompleteUserToDB()
        {
            var newItem = new User() 
            { 
                FirstName = "Test",
                LastName = "Test",
                SecondLastName = "Test",
                Email = "Test@Test.com",
                Password = "Test123*"
            };
            DbContext.Users.Add(newItem);
            DbContext.SaveChanges();

            Assert.Equal(newItem, DbContext.Users.Find(newItem.Id));
            Assert.Equal(1, DbContext.Users.Count());
        }

        [Fact]
        public void ShouldNotAddIncompleteUserToDB()
        {
            var exceptionMessage = "";
            var newItem = new User()
            {
                //No FirstName
                LastName = "Test",
                SecondLastName = "Test",
                Email = "Test@Test.com",
                Password = "Test123*"
            };

            try
            {
                DbContext.Users.Add(newItem);
                DbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                exceptionMessage = ex.InnerException.Message;
            }   
            
            Assert.NotEmpty(exceptionMessage);
            Assert.Equal("SQLite Error 19: 'NOT NULL constraint failed: Users.FirstName'.", exceptionMessage);            
        }

    }
}
