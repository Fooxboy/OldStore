using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OldStore.Backend.Migrations
{
    public partial class AddedCatalogs : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Blocks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Type = table.Column<int>(type: "int", nullable: false),
                    Metadata = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Blocks", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Catalogs",
                columns: table => new
                {
                    Key = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Catalogs", x => x.Key);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "BannerCatalog",
                columns: table => new
                {
                    BannersId = table.Column<int>(type: "int", nullable: false),
                    CatalogsKey = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BannerCatalog", x => new { x.BannersId, x.CatalogsKey });
                    table.ForeignKey(
                        name: "FK_BannerCatalog_Banners_BannersId",
                        column: x => x.BannersId,
                        principalTable: "Banners",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BannerCatalog_Catalogs_CatalogsKey",
                        column: x => x.CatalogsKey,
                        principalTable: "Catalogs",
                        principalColumn: "Key",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "BlockCatalog",
                columns: table => new
                {
                    BlocksId = table.Column<int>(type: "int", nullable: false),
                    CatalogsKey = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BlockCatalog", x => new { x.BlocksId, x.CatalogsKey });
                    table.ForeignKey(
                        name: "FK_BlockCatalog_Blocks_BlocksId",
                        column: x => x.BlocksId,
                        principalTable: "Blocks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BlockCatalog_Catalogs_CatalogsKey",
                        column: x => x.CatalogsKey,
                        principalTable: "Catalogs",
                        principalColumn: "Key",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_BannerCatalog_CatalogsKey",
                table: "BannerCatalog",
                column: "CatalogsKey");

            migrationBuilder.CreateIndex(
                name: "IX_BlockCatalog_CatalogsKey",
                table: "BlockCatalog",
                column: "CatalogsKey");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BannerCatalog");

            migrationBuilder.DropTable(
                name: "BlockCatalog");

            migrationBuilder.DropTable(
                name: "Blocks");

            migrationBuilder.DropTable(
                name: "Catalogs");
        }
    }
}
