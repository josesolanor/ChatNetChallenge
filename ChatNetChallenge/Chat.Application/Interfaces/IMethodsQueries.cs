using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Chat.Application.Interfaces
{
    public interface IMethodsQueries<T>
    {
        Task<List<T>> GetAll();
    }
}
