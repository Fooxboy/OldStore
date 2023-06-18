using OldStore.Catalogs.Domain.AggregatesModel.CatalogAggregate;
using OldStore.Catalogs.Infrastructure.DomainMappers;
using OldStore.Catalogs.Infrastructure.Repositories;

namespace OldStore.Catalogs.Infrastructure.Services
{
    public class CatalogsService
    {
        private readonly ICatalogsRepository _catalogsRepository;
        private readonly IBlocksRepository _blocksRepository;

        public CatalogsService()
        {
            
        }

        public Catalog GetById(int id)
        {
            var catalogDb = _catalogsRepository.GetById(id);

            var catalogEntity = catalogDb.CreateDomainEntity();

            var blocksDb = _blocksRepository.GetByIds(catalogDb.BlocksIds.ToArray());

            var blocksEntities = blocksDb.Select(x=> x.CreateDomainEntity()).ToList();

            catalogEntity.SetBlocks(blocksEntities);

            return catalogEntity;

        }
    }
}
