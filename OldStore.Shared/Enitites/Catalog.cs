using System.ComponentModel.DataAnnotations;

namespace OldStore.Shared.Enitites
{
    public class Catalog
    {
        [Key]
        public int Key { get; set; }

        public string Name { get; set; }

        public string FrendlyName { get; set; }

        public virtual List<Banner> Banners { get; set; }

        public virtual List<Block> Blocks { get; set; }
    }
}
