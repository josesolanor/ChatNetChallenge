using Chat.Application.Interfaces;
using Chat.Application.Models;
using Chat.Domain.Entities;
using Chat.Infrastructure.Data;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Chat.Application.Queries
{
    public class LoginQueries : ILoginQueries<LoginDTO>
    {
        private readonly ApplicationDBContext _context;

        public LoginQueries(ApplicationDBContext context)
        {
            _context = context;
        }
        public bool CheckCredencial(LoginDTO model)
        {
            var login = _context.Users.Where(m => m.Email.Equals(model.Email) && m.Password.Equals(model.Password)).FirstOrDefault();
            return login is null;
        }
    }
}
