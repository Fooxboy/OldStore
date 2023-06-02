using OldStore.Games.Domain.AggregatesModel.GameAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OldStore.Games.Domain.AggregatesModel.BlockAggregate
{
    public class Block
    {
        public string Title { get; private set; }

        public string Description { get; private set; }

        public BlockStatus Status { get; private set; }

        public BlockType @Type { get; private set; }

        public IReadOnlyCollection<Game> Games { get; private set; }

        public Block(string title, string description, BlockStatus status, BlockType type, IEnumerable<Game> games)
        {
            this.Title = title;
            this.Description = description;
            this.Status = status;
            this.Type = type;
            this.Games = games.ToList();
        }
    }
}
