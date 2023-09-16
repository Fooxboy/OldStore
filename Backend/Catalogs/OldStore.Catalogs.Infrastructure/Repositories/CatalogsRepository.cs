using OldStore.Catalogs.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OldStore.Catalogs.Infrastructure.Database;

namespace OldStore.Catalogs.Infrastructure.Repositories
{
    public class CatalogsRepository : ICatalogsRepository
    {
        private readonly CatalogsContext _catalogsContext;

        public CatalogsRepository(CatalogsContext catalogsContext)
        {
            _catalogsContext = catalogsContext;
        }

        public List<Catalog> GetGenerals()
        {
            var generalsCatalogs = _catalogsContext.Catalogs.Where(x => x.Type == CatalogType.General);

            return generalsCatalogs.ToList();
        }

        public Catalog? GetById(int id)
        {
            return _catalogsContext.Catalogs
                .Include(c=> c.Blocks)
                .FirstOrDefault(c => c.Id == id);
        }

        public List<Catalog> GetByIds(params int[] ids)
        {
            return _catalogsContext.Catalogs
                .Include(c => c.Blocks)
                .Where(c => ids.Contains(c.Id))
                .ToList();
        }
    }
}
