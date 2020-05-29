using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using RT.SignalR.Chat.JS.BLL;
using RT.SignalR.Chat.JS.DAL;

namespace RT.SignalR.Chat.JS.Controllers
{
    [Authorize]
    public class ChatController : Controller
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;
        public ChatController(ApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            var users = _dbContext.Users.ToList();
            users.Insert(0,new User()
            {
                UserName = "All"
            });
            var chatGroups = _dbContext.ChatGroups;
            var usersListItems = _mapper.Map<IEnumerable<SelectListItem>>(users);
            var chatGroupListItems = _mapper.Map<IEnumerable<SelectListItem>>(chatGroups);
            return View(new Tuple<IEnumerable<SelectListItem>, IEnumerable<SelectListItem>>(usersListItems, chatGroupListItems));
        }
    }
}