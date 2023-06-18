using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OldStore.Catalogs.Infrastructure.Models
{
    public class Block
    {
        [Key]
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public int Status { get; set; }

        public int @Type { get;  set; }

        public List<long> GamesIds { get; set; }
    }
}
