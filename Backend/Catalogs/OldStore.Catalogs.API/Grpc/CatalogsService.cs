using AutoMapper;
using Grpc.Core;
using GrpcCatalogs;

namespace OldStore.Catalogs.API.Grpc
{
    public class CatalogsService : GrpcCatalogs.Catalogs.CatalogsBase
    {
        private readonly OldStore.Catalogs.Infrastructure.Services.CatalogsService _catalogsService;
        private readonly IMapper _mapper;

        public CatalogsService(OldStore.Catalogs.Infrastructure.Services.CatalogsService catalogsService, IMapper mapper)
        {
            _catalogsService = catalogsService;
            _mapper = mapper;
        }

        public override async Task<CatalogResponse> GetCatalog(GetCatalogRequest request, ServerCallContext context)
        {
            var catalog = _catalogsService.GetById(request.Id);

            var response = _mapper.Map<CatalogResponse>(catalog);

            var blocks = catalog.Blocks.Select(x => _mapper.Map<BlockResponse>(x));

            response.Blocks.AddRange(blocks);

            return response;
        }

        public override Task<ListCatalogResponce> GetList(Empty request, ServerCallContext context)
        {
            return null;
            //return base.GetList(request, context);
        }
    }
}
