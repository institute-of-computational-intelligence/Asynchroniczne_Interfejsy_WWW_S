using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using RT.SignalR.Chat.JS.DAL;
using RT.SignalR.Chat.JS.ViewModels;

namespace RT.SignalR.Chat.JS.Hubs
{
    public class ChatHub : Hub
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;
        public ChatHub(ApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public override Task OnConnectedAsync()
        {
            SetGroups();
            return base.OnConnectedAsync();
        }
        private void SetGroups()
        {
            var user = _dbContext.Users
                        .Include(u => u.ChatGroupToUsers)
                        .ThenInclude(cug => cug.ChatGroup)
                        .FirstOrDefault(u => u.UserName == Context.User.Identity.Name);
            if (user == null) return;
            var userVm = _mapper.Map<UserVm>(user);
            foreach (var groupName in userVm.Groups)
                Groups.AddToGroupAsync(Context.ConnectionId, groupName);
        }
        public async Task SendMessageAll(MessageVm message)
        {
            if (message.Author == null)
                message.Author = Context?.User?.Identity?.Name;
            await Clients.All.SendAsync("ReceiveMessage", message);
        }
        [Authorize]
        public async Task SendMessageToUser(MessageVm message)
        {
            message.Author = Context.User.Identity.Name;
            var recipient = _dbContext.Users.FirstOrDefault(u => u.UserName == message.RecipientName);
            if (recipient != null)
            {
                await Clients.User(recipient.Id.ToString()).SendAsync("ReceiveMessage", message);
            }
        }
        [Authorize]
        public async Task SendMessageToGroup(MessageVm message)
        {
            message.Author = Context.User.Identity.Name;
            await Clients.Group(message.RecipientName).SendAsync("ReceiveMessage", message);
        }
    }
}
