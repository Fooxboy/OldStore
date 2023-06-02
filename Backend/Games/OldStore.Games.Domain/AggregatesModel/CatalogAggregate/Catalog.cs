using OldStore.Games.Domain.AggregatesModel.BlockAggregate;
using OldStore.Services.Shared.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OldStore.Games.Domain.AggregatesModel.CatalogAggregate
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
