using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OldStore.Catalogs.Infrastructure.Models
{
    public class GeneralSection
    {
        [Key]
        public int Id { get; set; }

        public int Title { get; set; }

        public int SectionId { get; set; }
    }
}
