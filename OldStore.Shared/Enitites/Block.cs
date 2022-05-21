using OldStore.Shared.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OldStore.Shared.Enitites
{
    public class Block
    {
        [Key]
        public int Id { get; set; }

        public BlockType Type { get; set; }

        public string Metadata { get; set; }

        public List<Catalog> Catalogs { get; set; }
    }
}
