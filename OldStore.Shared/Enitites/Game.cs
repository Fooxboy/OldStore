﻿using OldStore.Shared.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OldStore.Shared.Enitites
{
    public class Game
    {
        [Key]
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public int CoverId { get; set; }

        public Cover Cover { get; set; }

        public GameGenre Genre { get; set; }

        public List<File> Files { get; set; }
    }
}
