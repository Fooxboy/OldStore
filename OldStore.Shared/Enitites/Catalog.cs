
using System.ComponentModel.DataAnnotations;


namespace OldStore.Shared.Enitites
{
    public class Catalog
    {
        [Key]
        public int Key { get; set; }

        public string Name { get; set; }

        public List<Banner> Banners { get; set; }

        public List<Block> Blocks { get; set; }

    }
}
