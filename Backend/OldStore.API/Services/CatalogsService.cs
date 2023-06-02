using OldStore.Shared.Models;

namespace OldStore.API.Services
{
    public class CatalogsService : ICatalogsService
    {
        private readonly GrpcCatalogs.Catalogs.CatalogsClient _client;

        public CatalogsService(GrpcCatalogs.Catalogs.CatalogsClient client)
        {
            _client = client;
        }
        public async Task<Catalog> GetCatalogAsync(long id)
        {
            var catalog = await _client.GetCatalogAsync(new GrpcCatalogs.GetCatalogRequest { Id = id });

            //todo: magic mapping
            return null;
        }

        public async Task<List<Catalog>> GetListCatalogsAsync()
        {
            var catalogs = await _client.GetListAsync(null);

            //todo: magic mapping

            return null;
        }
    }
}
