using Microsoft.EntityFrameworkCore;
using OldStore.Backend.Models.Entities;
using OldStore.Shared.Enitites;

namespace OldStore.Backend.Databases
{
    public class StoreDatabaseContext:DbContext
    {
        public DbSet<User> Users { get; set; }

        public DbSet<Game> Games { get; set; }

        public DbSet<Cover> Covers { get; set; }

        public DbSet<Shared.Enitites.File> Files { get; set; }

        public DbSet<Banner> Banners { get; set; }

        public DbSet<Catalog> Catalogs { get; set; }

        public DbSet<Block> Blocks { get; set; }

        public DbSet<ActionButton> ActionButtons { get; set; }


        public StoreDatabaseContext(DbContextOptions<StoreDatabaseContext> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=localhost;Database=store;Username=postgres;Password=123456;Pooling=true;Maximum Pool Size=1024;Port=5432;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder) 
        {
            //modelBuilder.Entity<Catalog>()
            //     .HasMany(c => c.Banners)
            //     .WithMany(s => s.Catalogs)
            //     .UsingEntity(j => j.ToTable("CatalogBanners"));

            //modelBuilder.Entity<Catalog>()
            //    .HasMany(c => c.Blocks)
            //    .WithMany(s => s.Catalogs)
            //    .UsingEntity(j => j.ToTable("CatalogBlocks"));
        }
    }
}
