using Chat.Presentation.StockBot.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;

namespace Chat.Presentation.StockBot.Core
{
    public class LogicMessage : ILogicMessage
    {

        static bool CommandFormat(string text)
        {
            if (!string.IsNullOrEmpty(text) && text.Contains('=') && text.Trim()[0] == '/')
            {
                var command = text.Split('=');
                if (command != null || command.Length != 0)
                    return true;
            }           
            return false;
        }

        public string CommandMessage(string text)
        {
            if (CommandFormat(text))
            {
                return "yes";
            }
            return "no";
        }
    }
}
