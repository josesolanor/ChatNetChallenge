using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Chat.Presentation.StockBot.Interfaces
{
    public interface ICommandBot
    {
        string CommandMessage(string data);
    }
}
