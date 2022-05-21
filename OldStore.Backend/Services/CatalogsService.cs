using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using OldStore.Backend.Databases;
using OldStore.Shared.Models;
using OldStore.Shared.Models.Categories;

namespace OldStore.Backend.Services
{
    public class CatalogsService
    {

        private readonly StoreDatabaseContext db;
        private readonly GamesService gamesService;
        private readonly IConfiguration configuration;

        public CatalogsService(StoreDatabaseContext db, IConfiguration configuration, GamesService gamesService)
        {
            this.db = db;
            this.configuration = configuration;
            this.gamesService = gamesService;
        }

        public async Task<CatalogModel> GetHomeCatalog(int? userId)
        {
            var catalogName = configuration["HomeCatalogName"];
            var catalogEntity = await db.Catalogs.Include(c=> c.Banners).Include(c=> c.Blocks).FirstOrDefaultAsync(c => c.Name == catalogName);

            var catalogDto = new CatalogModel();

            catalogDto.Name = "Главная";

            catalogDto.Blocks = new List<BlockModel>();


            foreach(var block in catalogEntity.Blocks)
            {
                if(block.Type == Shared.Enums.BlockType.Banner)
                {
                    var banners = new List<object>();

                    foreach (var b in catalogEntity.Banners) banners.Add(b);
                    catalogDto.Blocks.Add(new BlockModel()
                    {
                        Type = block.Type,
                        Items = banners,
                        Priority = 0,
                    });
                }else if(block.Type == Shared.Enums.BlockType.CompactGame)
                {

                    var games = await gamesService.GetGamesAsync(null, null, 0, 4);

                    var gamesPlayed = new List<object>();

                    foreach (var g in games) gamesPlayed.Add(g);

                    catalogDto.Blocks.Add(new BlockModel()
                    {
                        Action = new ButtonAction()
                        {
                            Context = "library",
                            Action = "library",
                            Name = "Открыть библиотеку"
                        },
                        Items = gamesPlayed,
                        Title = "Недавно запущенные игры",
                        Type = block.Type,
                        Priority = 1,
                    });
                }else if(block.Type  == Shared.Enums.BlockType.Game)
                {
                    if (block.Metadata == "top")
                    {
                        var topGames = await gamesService.GetTopGamesAsync();

                        var top = new List<object>();

                        foreach (var g in topGames) top.Add(g);

                        catalogDto.Blocks.Add(new BlockModel()
                        {
                            Title = "Популярные игры",
                            Items = top,
                            Type = block.Type,
                            Priority = 2
                        });
                    }
                }else if(block.Type == Shared.Enums.BlockType.Category)
                {
                    if(block.Metadata == "genre")
                    {
                        var genres = new List<object>();

                        genres.Add(new GenreCategory() { Genre = Shared.Enums.GameGenre.Platformer, Title = "Платформеры" });
                        genres.Add(new GenreCategory() { Genre = Shared.Enums.GameGenre.Arcade, Title = "Аркады" });
                        genres.Add(new GenreCategory() { Genre = Shared.Enums.GameGenre.Adventure, Title = "Приключения" });
                        genres.Add(new GenreCategory() { Genre = Shared.Enums.GameGenre.Fighting, Title = "Файтинги" });

                        catalogDto.Blocks.Add(new BlockModel()
                        {
                            Title = "Игры по жарнрам",
                            Items = genres,
                            Type = block.Type,
                            Priority = 3
                        });
                    }
                    
                }
         
            }

            catalogDto.Blocks = catalogDto.Blocks.OrderBy(b => b.Priority).ToList();
            return catalogDto;
        }
    }
}
