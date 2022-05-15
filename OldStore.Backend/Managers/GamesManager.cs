using Microsoft.EntityFrameworkCore;
using OldStore.Backend.Databases;
using OldStore.Backend.Models.Entities;
using OldStore.Backend.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OldStore.Backend.Managers
{
    public class GamesManager
    {

        private readonly StoreDatabaseContext db;

        public GamesManager(StoreDatabaseContext db)
        {
            this.db = db;
        }


        public async Task<List<Game>> GetGamesAsync(int skip=0, int take=10)
        {
            var games = await db.Games.Skip(skip).Take(take).ToListAsync();

            return games;
        }

        public async Task<List<Game>> GetGamesByGenre(GameGenre gameGenre, int skip = 0, int take = 10)
        {
            var games = await db.Games.Where(g=> g.Genre == gameGenre).Skip(skip).Take(take).ToListAsync();

            return games;
        }

        public async Task<Game> GetGameById(int id)
        {
            var game = await db.Games.SingleOrDefaultAsync(g => g.Id == id);

            return game;
        }


    }
}
