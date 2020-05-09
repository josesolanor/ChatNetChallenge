using Chat.Presentation.StockBot.Core.BotCommands;
using Chat.Presentation.StockBot.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Chat.Presentation.StockBot.Core
{
    public class CommandDiccionary
    {
        private readonly Dictionary<string, ICommandBot> botCommands = new Dictionary<string, ICommandBot>();

        public CommandDiccionary()
        {
            botCommands.Add("/stock=", new StockCode());
        }

        public async Task<string> GetMessageByCode(string code, string data)
        {
            try
            {
                return await botCommands[code].CommandMessage(data);
            }
            catch
            {
                return $"The command does not exist: {code}";
            }
            
        }
    }
}
