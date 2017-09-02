using AutoMapper;
using Core.Controllers.Resources;
using Core.Core.Models;

namespace Core.Mapping
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {
            CreateMap<TeamQueryResource, TeamQuery>();
            CreateMap<Team, TeamResource>();
            CreateMap<Player, PlayerResource>();


            CreateMap<PlayerResource, Player>()
                .ForMember(x=> x.Id, opt=> opt.Ignore());
            CreateMap<SaveTeamResource, Team>()
                .ForMember(x=> x.Id, opt=> opt.Ignore());
            CreateMap<SavePlayerResource, Player>()
                .ForMember(x => x.Id, opt => opt.Ignore());
        }
    }
}
