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

            if (catalog is null) return new CatalogResponse() { Success = false };

            var response = _mapper.Map<CatalogResponse>(catalog);

            var blocks = catalog.Blocks.Select(x => _mapper.Map<BlockResponse>(x));

            response.Blocks.AddRange(blocks);

            response.Success = true;
            return response;
        }

        public override async Task<ListCatalogResponce> GetList(Empty request, ServerCallContext context)
        {
            var catalogsEntity = _catalogsService.GetGenerals();

            var response = new ListCatalogResponce();

            var catalogs = catalogsEntity.Select(x => _mapper.Map<CatalogResponse>(x)).ToList();
            
            for(int i = 0; i < catalogs.Count(); i++)
            {
                var blocks = catalogsEntity[i].Blocks.Select(x => _mapper.Map<BlockResponse>(x));
                catalogs[i].Blocks.AddRange(blocks);

                catalogs[i].Success = true;
            }

            response.Items.AddRange(catalogs);

            return response;
        }
    }
}
