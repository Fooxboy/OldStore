using Microsoft.EntityFrameworkCore;
using OldStore.Backend.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OldStore.Backend.Databases
{
    public class StoreDatabaseContext:DbContext
    {

        public DbSet<User> Users;
        public DbSet<Game> Games;
        public DbSet<Cover> Covers;

        public StoreDatabaseContext()
        {
            
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            
        }
    }
}
