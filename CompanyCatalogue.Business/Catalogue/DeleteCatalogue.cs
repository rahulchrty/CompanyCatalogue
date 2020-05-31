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
        public async Task Delete(string catalogueId)
        {
            await _deleteCataloguesRepository.Delete(catalogueId);
        }
    }
}
