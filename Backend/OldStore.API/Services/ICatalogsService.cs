using OldStore.Shared.Models;

namespace OldStore.API.Services
{
    public interface ICatalogsService
    {
        public Task<List<Catalog>> GetListCatalogsAsync();

        public Task<Catalog?> GetCatalogAsync(int id);
    }
}
