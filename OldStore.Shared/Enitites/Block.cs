using OldStore.Shared.Enums;
using System.ComponentModel.DataAnnotations;

namespace OldStore.Shared.Enitites
{
    public class Block
    {
        [Key]
        public int Id { get; set; }

        public BlockType Type { get; set; }

        public string Title { get; set; }

        public int ActionButtonId { get; set; }

        public ActionButton ActionButton { get; set; }

        public string Metadata { get; set; }

        public List<Catalog> Catalogs { get; set; }
    }
}
