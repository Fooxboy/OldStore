﻿using OldStore.Catalogs.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OldStore.Catalogs.Infrastructure.Repositories
{
    public class CatalogsRepository : ICatalogsRepository
    {
        public List<Catalog> GetGenerals()
        {
            throw new NotImplementedException();
        }

        public Catalog GetById(int id)
        {
            throw new NotImplementedException();
        }

        public List<Catalog> GetByIds(params int[] ids)
        {
            throw new NotImplementedException();
        }
    }
}