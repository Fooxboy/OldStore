using Microsoft.AspNetCore.Mvc;
using OldStore.Backend.Exceptions;
using OldStore.Backend.Models.Enums;
using OldStore.Backend.Models.General;
using OldStore.Backend.Services;
using OldStore.Shared.Models;

namespace OldStore.Api.Controllers
{
    [Route("api/catalogs")]
    [ApiController]
    public class CatalogsController:Controller
    {
        private readonly GamesService gamesService;
        private readonly CatalogsService catalogsService;

        public CatalogsController(GamesService gamesService, CatalogsService catalogsService)
        {
            this.gamesService = gamesService;
            this.catalogsService = catalogsService;
        }


        [HttpGet("home")]
        public async Task<Response<CatalogModel>> GetHomeCatalog()
        {
            try
            {
                var catalog = await this.catalogsService.GetHomeCatalog(null);

                return ResponseGeneratorService.GenerateData(catalog);
            }
            catch (OldStoreException ex)
            {
                var error = ResponseGeneratorService.Error<CatalogModel>(ex.ErrorCode, ex.Message);

                return error;
            }
            catch (Exception ex)
            {
                var error = ResponseGeneratorService.Error<CatalogModel>(ResponseErrorCode.Exception, ex.Message);

                return error;
            }
        }
    }
}
