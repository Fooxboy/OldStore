using AutoMapper;
using GrpcGames;
using OldStore.Games.Domain.AggregatesModel.GameAggregate;

namespace OldStore.Games.API.Helpers
{
    public class GamesMappingProfile : Profile
    {
        public GamesMappingProfile()
        {
            CreateMap<Game, GameGrpc>();
        }
    }
}
