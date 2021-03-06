// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using OldStore.Backend.Databases;

#nullable disable

namespace OldStore.Backend.Migrations
{
    [DbContext(typeof(StoreDatabaseContext))]
    [Migration("20220521174756_AddedCatalogs")]
    partial class AddedCatalogs
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("BannerCatalog", b =>
                {
                    b.Property<int>("BannersId")
                        .HasColumnType("int");

                    b.Property<int>("CatalogsKey")
                        .HasColumnType("int");

                    b.HasKey("BannersId", "CatalogsKey");

                    b.HasIndex("CatalogsKey");

                    b.ToTable("BannerCatalog");
                });

            modelBuilder.Entity("BlockCatalog", b =>
                {
                    b.Property<int>("BlocksId")
                        .HasColumnType("int");

                    b.Property<int>("CatalogsKey")
                        .HasColumnType("int");

                    b.HasKey("BlocksId", "CatalogsKey");

                    b.HasIndex("CatalogsKey");

                    b.ToTable("BlockCatalog");
                });

            modelBuilder.Entity("OldStore.Backend.Models.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .HasColumnType("longtext");

                    b.Property<string>("Email")
                        .HasColumnType("longtext");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("NormalizedEmail")
                        .HasColumnType("longtext");

                    b.Property<string>("NormalizedUserName")
                        .HasColumnType("longtext");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("longtext");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("longtext");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("longtext");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("UserName")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("OldStore.Shared.Enitites.Banner", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Image")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Subtitle")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Banners");
                });

            modelBuilder.Entity("OldStore.Shared.Enitites.Block", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Metadata")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Blocks");
                });

            modelBuilder.Entity("OldStore.Shared.Enitites.Catalog", b =>
                {
                    b.Property<int>("Key")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Key");

                    b.ToTable("Catalogs");
                });

            modelBuilder.Entity("OldStore.Shared.Enitites.Cover", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Url")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Covers");
                });

            modelBuilder.Entity("OldStore.Shared.Enitites.File", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("GameId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Url")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("GameId");

                    b.ToTable("Files");
                });

            modelBuilder.Entity("OldStore.Shared.Enitites.Game", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("CoverId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("Genre")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("CoverId");

                    b.ToTable("Games");
                });

            modelBuilder.Entity("BannerCatalog", b =>
                {
                    b.HasOne("OldStore.Shared.Enitites.Banner", null)
                        .WithMany()
                        .HasForeignKey("BannersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("OldStore.Shared.Enitites.Catalog", null)
                        .WithMany()
                        .HasForeignKey("CatalogsKey")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("BlockCatalog", b =>
                {
                    b.HasOne("OldStore.Shared.Enitites.Block", null)
                        .WithMany()
                        .HasForeignKey("BlocksId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("OldStore.Shared.Enitites.Catalog", null)
                        .WithMany()
                        .HasForeignKey("CatalogsKey")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("OldStore.Shared.Enitites.File", b =>
                {
                    b.HasOne("OldStore.Shared.Enitites.Game", "Game")
                        .WithMany("Files")
                        .HasForeignKey("GameId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Game");
                });

            modelBuilder.Entity("OldStore.Shared.Enitites.Game", b =>
                {
                    b.HasOne("OldStore.Shared.Enitites.Cover", "Cover")
                        .WithMany()
                        .HasForeignKey("CoverId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cover");
                });

            modelBuilder.Entity("OldStore.Shared.Enitites.Game", b =>
                {
                    b.Navigation("Files");
                });
#pragma warning restore 612, 618
        }
    }
}
