using Grpc.Core;
using GrpcCatalogs;

namespace OldStore.Catalogs.API.Grpc
{
    public class CatalogsService : GrpcCatalogs.Catalogs.CatalogsBase
    {
        public override Task<CatalogResponse> GetCatalog(GetCatalogRequest request, ServerCallContext context)
        {
            return null;
            //return base.GetCatalog(request, context);
        }

        public override Task<ListCatalogResponce> GetList(Empty request, ServerCallContext context)
        {
            return null;
            //return base.GetList(request, context);
        }
    }
}
