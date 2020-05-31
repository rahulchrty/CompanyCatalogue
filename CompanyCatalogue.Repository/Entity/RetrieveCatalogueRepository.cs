using CompanyCatalogue.Entity;
using CompanyCatalogue.Interfaces;
using CompanyCatalogue.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace CompanyCatalogue.Repository
{
    public class RetrieveCatalogueRepository : IRetrieveCatalogueRepository
    {
        private readonly CatalogueContext _catalogueContext;
        public RetrieveCatalogueRepository(CatalogueContext catalogueContext)
        {
            _catalogueContext = catalogueContext;
        }
        public async Task<List<CatalogueModel>> GetAllCatalogues()
        {
            List<CatalogueModel> calatogues = await (from catalogue in _catalogueContext.Catalogues
                                               select new CatalogueModel
                                               {
                                                CatalogueId = catalogue.CatalogueId,
                                                FileName = catalogue.FileName
                                               }).ToListAsync();
            return calatogues;
        }
    }
}
