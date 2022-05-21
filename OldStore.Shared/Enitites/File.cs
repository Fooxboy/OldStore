using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace OldStore.Shared.Enitites
{
    public class File
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public string Url { get; set; }

        public int GameId { get; set; }

        [JsonIgnore]
        public Game Game { get; set; }
    }
}
