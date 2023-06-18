using OldStore.Catalogs.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OldStore.Catalogs.Infrastructure.Repositories
{
    public interface ICatalogsRepository
    {
        public Catalog GetById(int id);

        public List<Catalog> GetAll();
    }
}
