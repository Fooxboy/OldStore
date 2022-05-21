using Microsoft.AspNetCore.Mvc;
using OldStore.Backend.Exceptions;
using OldStore.Backend.Models.Entities;
using OldStore.Backend.Models.Enums;
using OldStore.Backend.Models.General;
using OldStore.Backend.Services;
using OldStore.Shared.Enitites;
using OldStore.Shared.Enums;

namespace OldStore.Api.Controllers
{
    [Route("api/games")]
    [ApiController]
    public class GamesController: Controller
    {

        private readonly GamesService gamesService;

        public GamesController(GamesService gamesService)
        {
            this.gamesService = gamesService;
        }

        [HttpGet("get")]
        public async Task<Response<List<Game>>> GetGames(GameGenre? genre, int skip, int take)
        {
            try
            {
                var games = await gamesService.GetGamesAsync(0, genre, skip, take);

                return ResponseGeneratorService.GenerateData(games);
            }
            catch (OldStoreException ex)
            {
                var error = ResponseGeneratorService.Error<List<Game>> (ex.ErrorCode, ex.Message);

                return error;
            }
            catch (Exception ex)
            {
                var error = ResponseGeneratorService.Error<List<Game>>(ResponseErrorCode.Exception, ex.Message);

                return error;
            }
        }

        [HttpGet("getGame")]
        public async Task<Response<Game>> GetGame(int id)
        {
            try
            {
                var game = await gamesService.GetGameAsync(0, id);

                return ResponseGeneratorService.GenerateData(game);
            }catch(OldStoreException ex)
            {
                var error = ResponseGeneratorService.Error<Game>(ex.ErrorCode, ex.Message);

                return error;
            }

            catch (Exception ex)
            {
                var error = ResponseGeneratorService.Error<Game>(ResponseErrorCode.Exception, ex.Message);

                return error;
            }
        }
    }
}
