using CompanyCatalogue.Entity;
using CompanyCatalogue.Interfaces;
using CompanyCatalogue.Models;
using System.Threading.Tasks;

namespace CompanyCatalogue.Repository
{
    public class DeleteCataloguesRepository  : IDeleteCataloguesRepository
    {
        private CatalogueContext _catalogueContext;
        public DeleteCataloguesRepository(CatalogueContext catalogueContext)
        {
            _catalogueContext = catalogueContext;
        }
        public async Task Delete(string catalogueId)
        {
            Catalogue catalogue = new Catalogue {CatalogueId = catalogueId };
            _catalogueContext.Catalogues.Attach(catalogue);
            _catalogueContext.Catalogues.Remove(catalogue);
            await _catalogueContext.SaveChangesAsync();
        }
    }
}
