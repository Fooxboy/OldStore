using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OldStore.Backend.Models.Entities
{
    public class Cover
    {
        [Key]
        public int Id { get; set; }

        public string Url { get; set; }

    }
}
