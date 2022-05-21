using OldStore.Shared.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OldStore.Shared.Models
{
    public class CategoryModel
    {
        public string Title { get; set; }

        public string CoverUrl { get; set; }

        public CategoryType Type { get; set; }
    }
}
