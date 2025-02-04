﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Chat.Application.Interfaces
{
    public interface IMessageCommands<T>
    {
        bool CheckBotCommand(string text);
        Task Insert(T model);
        Task Save();
    }
}
