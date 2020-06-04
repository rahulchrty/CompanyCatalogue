using CompanyCatalogue.Interfaces;
using CompanyCatalogue.Models;
using System.Threading.Tasks;

namespace CompanyCatalogue.Business
{
    public class CatalogueDetails : ICatalogueDetails
    {
        private readonly IRetrieveCatalogueDetailsRepository _retrieveCatalogueDetailsRepo;
        public CatalogueDetails(IRetrieveCatalogueDetailsRepository retrieveCatalogueDetailsRepo)
        {
            _retrieveCatalogueDetailsRepo = retrieveCatalogueDetailsRepo;
        }
        public async Task<CatalogueByGuidModel> GetCatalogueByCatalogueId(string catalogueId)
        {
            CatalogueByGuidModel catalogueByGuidModel = null;
            if (!string.IsNullOrWhiteSpace(catalogueId))
            {
                catalogueByGuidModel = await _retrieveCatalogueDetailsRepo.GetCatalogueByGuid(catalogueId);
            }
            return catalogueByGuidModel;
        }
    }
}
