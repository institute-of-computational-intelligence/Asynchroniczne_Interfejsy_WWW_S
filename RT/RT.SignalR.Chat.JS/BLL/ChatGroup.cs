using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RT.SignalR.Chat.JS.BLL
{
    public class ChatGroup
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public ICollection<ChatGroupToUsers> ChatGroupToUsers { get; set; }
    }

}
