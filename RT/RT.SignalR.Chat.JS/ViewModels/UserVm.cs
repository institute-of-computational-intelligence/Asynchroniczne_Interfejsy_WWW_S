﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RT.SignalR.Chat.JS.ViewModels
{
    public class UserVm
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public IList<string> Groups { get; set; }
    }
}
