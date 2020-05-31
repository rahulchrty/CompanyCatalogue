using System.Threading.Tasks;

namespace CompanyCatalogue.Interfaces
{
    public interface IDeleteCataloguesRepository
    {
        Task Delete(string catalogueId);        
    }
}
