﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OldStore.Games.Infrastructure.Models
{
    public class Image
    {
        [Key]
        public int Id { get; set; }

        public Uri Url { get; set; }

        public Game Game { get; set; }
    }
}
