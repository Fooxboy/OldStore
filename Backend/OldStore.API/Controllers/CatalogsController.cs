using Microsoft.AspNetCore.Mvc;
using OldStore.Shared.Models;

namespace OldStore.API.Controllers
{
    public class CatalogsController : Controller
    {
        [HttpGet("catalogs.getList")]
        public async Task<List<Catalog>> GetCatalogsList()
        {
            //get list of catalogs

            return null;
        }

        [HttpGet("catalogs.get")]
        public async Task<Catalog> GetCatalog(string id)
        {
            //get catalog

            return null;
        }

        
    }
}
