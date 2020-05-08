using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Chat.Application.Interfaces
{
    public interface IUserQueries<T>
    {
        Task<List<T>> GetAll();
        Task<T> GetById(int id);
    }
}
