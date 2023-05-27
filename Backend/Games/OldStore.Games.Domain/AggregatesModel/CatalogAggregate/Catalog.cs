using OldStore.Games.Domain.AggregatesModel.GameAggregate;
using OldStore.Services.Shared.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OldStore.Games.Domain.AggregatesModel.CatalogAggregate
{
    public class Catalog : DomainEntity, IAggregateRoot
    {
        public string Title { get; private set; }

        public string Description { get; private set; }

        public CatalogStatus Status { get; private set; }

        public CatalogType @Type { get; private set; }

        public IReadOnlyCollection<Game> Games { get; private set; }

        public Catalog(string title, string description, CatalogStatus status, CatalogType type, IEnumerable<Game> games)
        {
            this.Title = title;
            this.Description = description;
            this.Status = status;
            this.Type   = type;
            this.Games =  games.ToList();
        }
    }
}
