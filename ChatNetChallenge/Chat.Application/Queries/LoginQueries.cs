using Chat.Application.Interfaces;
using Chat.Domain.Entities;
using Chat.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Chat.Application.Queries
{
    public class LoginQueries : ILoginQueries<User>
    {
        private readonly ApplicationDBContext _context;

        public LoginQueries(ApplicationDBContext context)
        {
            _context = context;
        }
        public Task<User> CheckCredencial(User model)
        {
            throw new NotImplementedException();
        }
    }
}
