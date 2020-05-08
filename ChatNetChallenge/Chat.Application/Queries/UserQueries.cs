using Chat.Application.Interfaces;
using Chat.Domain.Entities;
using Chat.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Chat.Application.Queries
{
    class UserQueries : IUserQueries<User>
    {
        private readonly ApplicationDBContext _context;

        public UserQueries(ApplicationDBContext context)
        {
            _context = context;
        }

        public Task<List<User>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<User> GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
