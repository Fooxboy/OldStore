using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace OldStore.Shared.Enitites
{
    public class Cover
    {
        [Key]
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("url")]
        public string Url { get; set; }
    }
}
