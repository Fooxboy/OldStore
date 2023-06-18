using Microsoft.EntityFrameworkCore;
using OldStore.Catalogs.Infrastructure.Models;


namespace OldStore.Catalogs.Infrastructure.Database
{
    public class CatalogsContext
    {
        public DbSet<Block> Blocks { get; set; }
    }
}
