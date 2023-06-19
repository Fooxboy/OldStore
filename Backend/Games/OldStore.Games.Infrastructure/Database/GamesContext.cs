using Microsoft.EntityFrameworkCore;
using OldStore.Games.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OldStore.Games.Infrastructure.Database
{
    public class GamesContext : DbContext
    {
        public DbSet<Game> Games { get; set; }

        public DbSet<Developer> Developers { get; set; }

        public DbSet<Image> Images { get; set; }
    }
}
