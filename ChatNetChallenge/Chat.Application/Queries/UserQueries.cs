using Chat.Application.Interfaces;
using Chat.Application.Models;
using Chat.Domain.Entities;
using Chat.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Chat.Application.Queries
{
    public class UserQueries : IUserQueries<UserDTO>
    {
        private readonly ApplicationDBContext _context;

        public UserQueries(ApplicationDBContext context)
        {
            _context = context;
        }

        public Task<List<UserDTO>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<UserDTO> GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
