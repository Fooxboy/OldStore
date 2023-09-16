using AutoMapper;
using GrpcCatalogs;
using OldStore.Shared.Models;

namespace OldStore.API.Services
{
    public class CatalogsService : ICatalogsService
    {
        private readonly GrpcCatalogs.Catalogs.CatalogsClient _client;

        private readonly IMapper _mapper;

        public CatalogsService(GrpcCatalogs.Catalogs.CatalogsClient client, IMapper mapper)
        {
            _client = client;
            _mapper = mapper;
        }

        public async Task<Catalog?> GetCatalogAsync(int id)
        {
            var catalogResponse = await _client.GetCatalogAsync(new GrpcCatalogs.GetCatalogRequest { Id = id });

            if (!catalogResponse.Success)
            {
                return null;
            }
            
            var catalog = _mapper.Map<Catalog>(catalogResponse);

            var blocks = catalogResponse.Blocks.Select(b => _mapper.Map<Block>(b));

            catalog.Blocks = new List<Block>(blocks);

            return catalog;
        }

        public async Task<List<Catalog>> GetListCatalogsAsync()
        {
            var catalogsResponse = await _client.GetListAsync(new Empty());

            var catalogs = catalogsResponse.Items
                .Where(c=> c.Success)
                .Select(c => _mapper.Map<Catalog>(c))
                .ToList();

            for(int i = 0; i < catalogs.Count(); i++)
            {
                var blocks = catalogsResponse.Items[i].Blocks.Select(x => _mapper.Map<Block>(x));

                catalogs[i].Blocks = new List<Block>(blocks);
            }

            return catalogs;
        }
    }
}
