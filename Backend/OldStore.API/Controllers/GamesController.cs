using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OldStore.Shared.Models;

namespace OldStore.API.Controllers
{
    public class GamesController : Controller
    {

        public GamesController() { }


        [HttpGet("games.get")]
        public async  Task<Game> GetGameById(int id)
        {
            //todo: get game

            return null;
        }
    }
}
