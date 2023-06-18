using AutoMapper;
using GrpcCatalogs;
using OldStore.Catalogs.Domain.AggregatesModel.BlockAggregate;
using OldStore.Catalogs.Domain.AggregatesModel.CatalogAggregate;

namespace OldStore.Catalogs.API.Helpers
{
    public class AppMappingProfile : Profile
    {
        public AppMappingProfile()
        {
            CreateMap<Block, BlockResponse>();
            CreateMap<Catalog, CatalogResponse>().ForMember(dest => dest.Blocks, opt => opt.Ignore());
        }
    }
}
