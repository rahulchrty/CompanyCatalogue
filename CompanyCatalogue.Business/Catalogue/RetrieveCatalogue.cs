using CompanyCatalogue.Interfaces;
using CompanyCatalogue.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CompanyCatalogue.Business
{
    public class RetrieveCatalogue : IRetrieveCatalogue
    {
        private readonly IRetrieveCatalogueRepository _retrieveCatalogueRepository;
        public RetrieveCatalogue(IRetrieveCatalogueRepository retrieveCatalogueRepository)
        {
            _retrieveCatalogueRepository = retrieveCatalogueRepository;
        }
        public async Task<List<CatalogueModel>> GetAllCatalogue()
        {
            return await _retrieveCatalogueRepository.GetAllCatalogues();
        }
    }
}
