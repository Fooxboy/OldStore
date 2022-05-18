using OldStore.Backend.Exceptions;
using OldStore.Backend.Managers;
using OldStore.Backend.Models.Entities;
using OldStore.Backend.Models.Enums;
using OldStore.Shared.Enitites;
using OldStore.Shared.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OldStore.Backend.Services
{
    public class GamesService
    {
        private readonly GamesManager gamesManager;

        public GamesService(GamesManager gamesManager)
        {
            this.gamesManager = gamesManager;
        }


        public async Task<List<Game>> GetGamesAsync(int? userId, GameGenre? genre, int skip=0, int take=10)
        {
            if(genre != null)
            {
                return await gamesManager.GetGamesByGenre(genre.Value, skip, take);
            }

            return await gamesManager.GetGamesAsync(skip, take);
        }

        public async Task<Game> GetGameAsync(int? userId, int id)
        {
            var game = await gamesManager.GetGameById(id);

            if(game == null)
            {
                throw new OldStoreException("Game with id '{id}' not found", ResponseErrorCode.GameNotFound);
            }

            return game;
        }
    }
}
