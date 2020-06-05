using CompanyCatalogue.Entity;
using CompanyCatalogue.Interfaces;
using CompanyCatalogue.Models;

namespace CompanyCatalogue.Repository
{
    public class CreateCatalogueRepository : ICreateCatalogueRepository
    {
        private readonly CatalogueContext _catalogueContext;
        public CreateCatalogueRepository(CatalogueContext catalogueContext)
        {
            _catalogueContext = catalogueContext;
        }
        public void Create(string guid, string fileName)
        {
            _catalogueContext.Catalogues.Add(new Catalogue
            {
                CatalogueId = guid,
                FileName = fileName
            });
        }
    }
}
