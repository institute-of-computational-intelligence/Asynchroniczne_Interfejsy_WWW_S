using System.ComponentModel.DataAnnotations;

namespace RT.SignalR.Chat.JS.ViewModels
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
