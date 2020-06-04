using CompanyCatalogue.Interfaces;
using System.Threading.Tasks;

namespace CompanyCatalogue.Business
{
    public class DeleteCatalogue : IDeleteCatalogue
    {
        private IDeleteCataloguesRepository _deleteCataloguesRepository;
        public DeleteCatalogue(IDeleteCataloguesRepository deleteCataloguesRepository)
        {
            _deleteCataloguesRepository = deleteCataloguesRepository;
        }
        public async Task<bool> Delete(string catalogueId)
        {
            bool isAccepted = false;
            if (!string.IsNullOrWhiteSpace(catalogueId))
            {
                await _deleteCataloguesRepository.Delete(catalogueId);
                isAccepted = true;
            }
            return isAccepted;
        }
    }
}
