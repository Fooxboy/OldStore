using OldStore.Shared.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace OldStore.Shared.Models
{
    public class CategoryModel
    {
        [JsonPropertyName("title")]
        public string Title { get; set; }

        [JsonPropertyName("cover_url")]
        public string CoverUrl { get; set; }

        [JsonPropertyName("type")]
        public CategoryType Type { get; set; }
    }
}
