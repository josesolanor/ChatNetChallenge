using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Chat.Application.Interfaces
{
    public interface ILoginQueries<T>
    {
        Task<bool> CheckCredencial(T model);        
    }
}
