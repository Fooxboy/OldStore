using Microsoft.AspNetCore.Mvc;
using OldStore.API.Services;
using OldStore.Shared.Models;

namespace OldStore.API.Controllers
{
    public class CatalogsController : Controller
    {
        private readonly ICatalogsService _catalogsService;

        public CatalogsController(ICatalogsService catalogsService)
        {
            _catalogsService = catalogsService;
        }

        /// <summary>
        /// Получить основные каталоги
        /// </summary>
        [HttpGet("catalogs.getGenerals")]
        public async Task<List<Catalog>> GetCatalogsList()
        {
            var catalogs = await _catalogsService.GetListCatalogsAsync();

            return catalogs;
        }

        /// <summary>
        /// Получить конкретный каталог по ID
        /// </summary>
        [HttpGet("catalogs.get")]
        public async Task<Catalog> GetCatalog(int id)
        {
            var catalog = await _catalogsService.GetCatalogAsync(id);

            return catalog;
        }

    }
}
