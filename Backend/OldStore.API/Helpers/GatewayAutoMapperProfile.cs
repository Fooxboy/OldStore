using AutoMapper;
using GrpcCatalogs;
using GrpcGames;
using OldStore.Shared.Models;

namespace OldStore.API.Helpers
{
    public class GatewayAutoMapperProfile : Profile
    {
        public GatewayAutoMapperProfile()
        {
            CreateMap<BlockResponse, Block>();
            CreateMap<CatalogResponse, Catalog>().ForMember(dest => dest.Blocks, opt => opt.Ignore());
            CreateMap<DeveloperGrpc, GameDeveloper>();
            CreateMap<ImageGrpc, GameImage>();
            CreateMap<GameGrpc, Game>();
        }
    }
}
