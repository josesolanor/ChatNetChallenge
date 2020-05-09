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
        private readonly CommandDiccionary _commandDiccionary = new CommandDiccionary();

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

        public async Task<string> CommandMessage(string text)
        {
            if (CommandFormat(text))
            {
                var code = text.Split('=')[0];
                var data = text.Split('=')[1];

                return await _commandDiccionary.GetMessageByCode($"{code}=", data);
            }
            return $"incorrect command format: {text}";
        }
    }
}
