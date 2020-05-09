﻿using Chat.Presentation.Client.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Chat.Presentation.Client.Interfaces
{
    public interface ILoginServices
    {
        Task<bool> CheckCredencial(LoginInputDataModel model);
    }
}
