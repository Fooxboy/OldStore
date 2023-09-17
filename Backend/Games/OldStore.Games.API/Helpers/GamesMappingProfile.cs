using AutoMapper;
using GrpcGames;
using OldStore.Games.Domain.AggregatesModel.GameAggregate;

namespace OldStore.Games.API.Helpers
{
    public class GamesMappingProfile : Profile
    {
        public GamesMappingProfile()
        {
            CreateMap<GameImage, ImageGrpc>();
            CreateMap<GameDeveloper, DeveloperGrpc>().ForMember(dest => dest.Payload, 
                opt => opt.Condition(src => (src.Payload != null)));
            
            CreateMap<Game, GameGrpc>().ForMember(d=> d.Success, 
                opt => opt.MapFrom(src => true))
                .ForMember(dest => dest.Description, 
                    opt => opt.Condition(src => (src.Description != null)))
                .ForMember(dest => dest.Publisher, 
                opt => opt.Condition(src => (src.Publisher != null)));
        }
    }
}
