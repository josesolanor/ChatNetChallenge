using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Chat.Application.Interfaces
{
    public interface IMethodsCommands<T>
    {
        Task InsertAsync(T model);
        Task Save();
    }
}
