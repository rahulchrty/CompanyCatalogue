using CompanyCatalogue.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CompanyCatalogue.Interfaces
{
    public interface ICatalogueDetails
    {
        Task<CatalogueByGuidModel> GetCatalogueByCatalogueId(string catalogueId);
    }
}
