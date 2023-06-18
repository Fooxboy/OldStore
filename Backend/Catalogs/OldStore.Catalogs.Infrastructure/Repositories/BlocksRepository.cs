using OldStore.Catalogs.Infrastructure.Database;
using OldStore.Catalogs.Infrastructure.Models;

namespace OldStore.Catalogs.Infrastructure.Repositories
{
    public class BlocksRepository : IBlocksRepository
    {
        private CatalogsContext _dbContext;

        public BlocksRepository(CatalogsContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<Block> GetByIds(params int[] ids)
        {
            return _dbContext.Blocks.Where(c=> ids.Contains(c.Id)).ToList();
        }
    }
}
