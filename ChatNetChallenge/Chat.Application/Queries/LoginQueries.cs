using Chat.Application.Interfaces;
using Chat.Application.Models;
using Chat.Domain.Entities;
using Chat.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
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
            var loginExist = _context.Users.Where(m => m.Email.Equals(model.Email) && m.Password.Equals(model.Password)).FirstOrDefault();
            return loginExist is null ? false : true;
               
        }
    }
}
