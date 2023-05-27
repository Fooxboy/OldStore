using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace OldStore.API.Controllers
{
    public class GamesController : Controller
    {

        public GamesController() { }


        [HttpGet("games/{id}")]
        public void GetGameById(int id)
        {
            //todo: get game
        }
    }
}
