using System.Linq;
using AutoMapper;
using Microsoft.AspNetCore.Mvc.Rendering;
using RT.SignalR.Chat.JS.BLL;
using RT.SignalR.Chat.JS.ViewModels;

namespace RT.SignalR.Chat.JS.Configuration.AutoMapper
{
    public class MainProfile:Profile
    {
        public MainProfile()
        {
            CreateMap<User, UserVm>()
                .ForMember(dst => dst.Groups, y =>
                    y.MapFrom(src => src.ChatGroupToUsers.Select(cgu => cgu.ChatGroup.Name)));
            CreateMap<ChatGroup, SelectListItem>()
                .ForMember(x => x.Text, y => y.MapFrom(z => z.Name))
                .ForMember(x => x.Value, y => y.MapFrom(z => z.Id));
            CreateMap<User, SelectListItem>()
                .ForMember(x => x.Text, y => y.MapFrom(z => z.UserName))
                .ForMember(x => x.Value, y => y.MapFrom(z => z.Id));
        }
    }
}
