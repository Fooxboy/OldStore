using OldStore.Catalogs.Domain.AggregatesModel.CatalogAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OldStore.Catalogs.Infrastructure.DomainMappers
{
    public static class CatalogExtensions
    {
        public static Catalog CreateDomainEntity(this Models.Catalog dbCatalog)
        {
            return new Catalog(dbCatalog.Name, dbCatalog.Name);
        }

    }
}
