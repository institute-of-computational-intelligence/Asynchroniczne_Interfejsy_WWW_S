using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace RT.SignalR.Chat.JS.BLL
{
    public class User : IdentityUser<int>
    {
       public ICollection<ChatGroupToUsers> ChatGroupToUsers { get; set; }
    }

}
