using AutoMapper;
using GameHub.Models;
using GameHub.ViewModels;

namespace GameHub
{
    internal class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Players, PlayersViewModel>();
            CreateMap<Leagues, LeaguesViewModel>();
            CreateMap<Teams, TeamsViewModel>();
                
            CreateMap<Games, GamesViewModel>()
                .ForMember(x=> x.Date, opt=> opt.MapFrom(src=> src.DateTime.ToString("dd/MM/yyyy")))
                .ForMember(x=> x.Time, opt=> opt.MapFrom(src=> src.DateTime.ToString("HH:mm")));
        }
    }
}