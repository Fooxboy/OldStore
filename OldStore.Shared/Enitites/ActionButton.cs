using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OldStore.Shared.Enitites
{
    public class ActionButton
    {
        [Key]
        public int Id { get; set; }

        public string Title { get; set; }

        public string Action { get; set; }

        public string Metadata { get; set; }
    }
}
