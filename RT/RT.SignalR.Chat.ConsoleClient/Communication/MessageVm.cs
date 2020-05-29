using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace RT.SignalR.Chat.ConsoleClient.Communication
{
    public class MessageVm
    {
        [Required]
        public string Content { get; set; }

        [Required]
        public string Author { get; set; }

        [Required]
        public string RecipientName { get; set; }
    }
}
