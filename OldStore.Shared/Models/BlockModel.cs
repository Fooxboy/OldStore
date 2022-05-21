using OldStore.Shared.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace OldStore.Shared.Models
{
    public class BlockModel
    {
        [JsonPropertyName("title")]
        public string Title { get; set; }

        [JsonPropertyName("action")]
        public ButtonAction Action { get; set; }

        [JsonPropertyName("type")]
        public BlockType Type { get; set; }

        [JsonPropertyName("items")]
        public List<object> Items { get; set; }

        [JsonIgnore]
        public int Priority { get; set; }
    }
}
