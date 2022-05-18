using Microsoft.EntityFrameworkCore;
using OldStore.Backend.Models.Entities;
using OldStore.Shared.Enitites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OldStore.Backend.Databases
{
    public class StoreDatabaseContext:DbContext
    {

        public DbSet<User> Users { get; set; }
        public DbSet<Game> Games { get; set; }
        public DbSet<Cover> Covers { get; set; }
        public DbSet<Shared.Enitites.File> Files { get; set; }

        public DbSet<Banner> Banners { get; set; }

        public StoreDatabaseContext(DbContextOptions<StoreDatabaseContext> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            
        }
    }
}
