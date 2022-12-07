using System.Text.Json.Serialization;

namespace OldStore.Shared.Enitites
{
    public class Banner
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("title")]
        public string Title { get; set; }

        [JsonPropertyName("subtitle")]
        public string Subtitle { get; set; }

        [JsonPropertyName("description")]
        public string Description { get; set; }

        [JsonPropertyName("image")]
        public string Image { get; set; }

        [JsonIgnore]
        public List<Catalog> Catalogs { get; set; } = new();
    }
}
