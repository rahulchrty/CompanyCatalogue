using CompanyCatalogue.Models;
using System.Threading.Tasks;

namespace CompanyCatalogue.Interfaces
{
    public interface IRetrieveCatalogueDetailsRepository
    {
        Task<CatalogueByGuidModel> GetCatalogueByGuid(string guid);
    }
}
