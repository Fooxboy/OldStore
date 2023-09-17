using Microsoft.AspNetCore.Mvc;
using OldStore.API.Services;
using OldStore.Shared.Models;

namespace OldStore.API.Controllers
{
    public class GamesController : Controller
    {
        private readonly IGamesService _gamesService;

        public GamesController(IGamesService gamesService)
        {
            _gamesService = gamesService;
        }

        [HttpGet("games.get")]
        public async Task<Game> GetGameById(int id)
        {
            var game = await  _gamesService.GetGameById(id);
            
            return game;
        }

        [HttpGet("games.getList")]
        public async Task<List<Game>> GetGamesByIds(int[] ids)
        {
            var games = await _gamesService.GetGamesByIds(ids);

            return games;
        }
    }
}
