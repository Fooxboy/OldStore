using OldStore.Catalogs.Domain.AggregatesModel.BlockAggregate;
using OldStore.Services.Shared.Domain;

namespace OldStore.Catalogs.Domain.AggregatesModel.CatalogAggregate
{
    public class Catalog : DomainEntity
    {
        public string Name { get; private set; }

        public string Title { get; private set; }

        public List<Block> Blocks { get; private set; }

        public Catalog(string name, string title, IEnumerable<Block> blocks)
        {
            this.Name = name;
            this.Title = title;
            this.Blocks = blocks.ToList();
        }
    }
}
