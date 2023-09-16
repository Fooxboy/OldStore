using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OldStore.Catalogs.Infrastructure.Models
{
    public class Catalog
    {
        [Key]
        public int  Id { get; set; }

        public string Name { get;  set; }

        public string Title { get;  set; }
        
        public CatalogType @Type { get; set; }

        public List<Block> Blocks  { get; set; }
    }
}
