using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OldStore.Shared.Models
{
    public class CatalogModel
    {
       public string Name { get; set; }

       public List<BlockModel> Blocks { get; set; }
    }
}
