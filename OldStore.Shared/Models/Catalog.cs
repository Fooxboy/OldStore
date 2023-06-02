using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OldStore.Shared.Models
{
    public class Catalog
    {
        public long Id { get; set; }

        public string Name { get; set; }
        
        public string Title { get; set; }

        public List<Block> Blocks { get; set; }
    }
}
