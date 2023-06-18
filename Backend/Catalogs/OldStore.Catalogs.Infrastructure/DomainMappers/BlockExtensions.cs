using OldStore.Catalogs.Domain.AggregatesModel.BlockAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OldStore.Catalogs.Infrastructure.DomainMappers
{
    public static class BlockExtensions
    {
        public static Block CreateDomainEntity(this Models.Block block)
        {
            return new Block(block.Title, block.Description, (BlockStatus)block.Status, (BlockType)block.Type, block.GamesIds);
        }
    }
}
