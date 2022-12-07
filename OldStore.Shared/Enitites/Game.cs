using OldStore.Shared.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace OldStore.Shared.Enitites
{
    public class Game
    {
        [Key]
        public int Id { get; set; }

        [JsonPropertyName("title")]
        public string Title { get; set; }

        [JsonPropertyName("description")]
        public string Description { get; set; }

        [JsonPropertyName("cover_id")]
        public int CoverId { get; set; }

        [JsonPropertyName("cover")]
        public Cover Cover { get; set; }

        [JsonPropertyName("genre")]
        public GameGenre Genre { get; set; }

        [JsonPropertyName("files")]
        public List<File> Files { get; set; }
    }
}
