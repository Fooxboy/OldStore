using OldStore.Shared.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OldStore.Shared.Models.Categories
{
    public class GenreCategory:CategoryModel
    {
        public GameGenre Genre { get; set; }
        public GenreCategory()
        {
            this.Type = Enums.CategoryType.Genre;
        }
    }
}
