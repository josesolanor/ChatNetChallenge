using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Chat.Application.Interfaces
{
    public interface IUserQueries<T>
    {
        Task<T> GetByEmail(string email);
    }
}
