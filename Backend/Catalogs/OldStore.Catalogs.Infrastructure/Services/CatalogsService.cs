using OldStore.Catalogs.Domain.AggregatesModel.CatalogAggregate;
using OldStore.Catalogs.Infrastructure.DomainMappers;
using OldStore.Catalogs.Infrastructure.Repositories;

namespace OldStore.Catalogs.Infrastructure.Services
{
    public class CatalogsService
    {
        private readonly ICatalogsRepository _catalogsRepository;
        private readonly IBlocksRepository _blocksRepository;

        public CatalogsService(ICatalogsRepository catalogsRepository, IBlocksRepository blocksRepository)
        {
            _catalogsRepository = catalogsRepository;
            _blocksRepository = blocksRepository;
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

        public List<Catalog> GetGenerals()
        {
            var catalogs = _catalogsRepository.GetGenerals();

            var catalogsEntity = new List<Catalog>();

            foreach (var catalog in catalogs)
            {
                var c = catalog.CreateDomainEntity();
                var blocksEntities = _blocksRepository
                    .GetByIds(catalog.BlocksIds.ToArray())
                    .Select(x=> x.CreateDomainEntity())
                    .ToList();
                c.SetBlocks(blocksEntities);

                catalogsEntity.Add(c);
            }


            return catalogsEntity;
        }
    }
}
