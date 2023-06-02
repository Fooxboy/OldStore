using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OldStore.Shared.Models
{
    public class Block
    {
        public string Title { get; private set; }

        public string Description { get; private set; }

        public BlockStatus Status { get; private set; }

        public BlockType @Type { get; private set; }

        public IReadOnlyCollection<Game> Games { get; private set; }
    }
}
