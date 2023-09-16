using OldStore.Catalogs.Domain.AggregatesModel.CatalogAggregate;
using OldStore.Catalogs.Infrastructure.DomainMappers;
using OldStore.Catalogs.Infrastructure.Repositories;

namespace OldStore.Catalogs.Infrastructure.Services
{
    public class CatalogsService
    {
        private readonly ICatalogsRepository _catalogsRepository;

        public CatalogsService(ICatalogsRepository catalogsRepository)
        {
            _catalogsRepository = catalogsRepository;
        }

        public Catalog? GetById(int id)
        {
            var catalogDb = _catalogsRepository.GetById(id);

            if (catalogDb is null) return null;

            var catalogEntity = catalogDb.CreateDomainEntity();

            catalogEntity.SetBlocks(catalogDb.Blocks.CreateDomainEntityList());

            return catalogEntity;
        }

        public List<Catalog> GetGenerals()
        {
            var catalogs = _catalogsRepository.GetGenerals();

            var catalogsEntity = new List<Catalog>();

            foreach (var catalog in catalogs)
            {
                var c = catalog.CreateDomainEntity();
                catalogsEntity.Add(c);
            }

            return catalogsEntity;
        }
    }
}
