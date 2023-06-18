using OldStore.Services.Shared.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OldStore.Catalogs.Domain.AggregatesModel.BlockAggregate
{
    public class Block : DomainEntity
    {
        public string Title { get; private set; }

        public string Description { get; private set; }

        public BlockStatus Status { get; private set; }

        public BlockType @Type { get; private set; }

        public IReadOnlyCollection<long> GamesIds { get; private set; }

        public Block(string title, string description, BlockStatus status, BlockType type, IEnumerable<long> games)
        {
            this.Title = title;
            this.Description = description;
            this.Status = status;
            this.Type = type;
            this.GamesIds = games.ToList();
        }
    }
}
