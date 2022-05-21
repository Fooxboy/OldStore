using OldStore.Shared.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OldStore.Shared.Models
{
    public class BlockModel
    {
        public string Title { get; set; }

        public ButtonAction Action { get; set; }

        public BlockType Type { get; set; }

        public List<object> Items { get; set; }
    }
}
