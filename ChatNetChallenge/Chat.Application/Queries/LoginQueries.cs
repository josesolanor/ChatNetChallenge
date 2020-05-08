using Chat.Application.Interfaces;
using Chat.Application.Models;
using Chat.Domain.Entities;
using Chat.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
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
        public async Task<bool> CheckCredencialAsync(LoginDTO model)
        {
            var login = await _context.Users.Where(m => m.Email.Equals(model.Email) && m.Password.Equals(model.Password)).FirstOrDefaultAsync();
            return login is null;
        }
    }
}
