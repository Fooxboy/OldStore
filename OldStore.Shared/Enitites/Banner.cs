using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace OldStore.Shared.Enitites
{
    public class Banner
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Subtitle { get; set; }

        public string Description { get; set; }

        public string Image { get; set; }

        [JsonIgnore]
        public List<Catalog> Catalogs { get; set; }
    }
}
