using System.Threading.Tasks;

namespace CompanyCatalogue.Interfaces
{
    public interface IDeleteCatalogue
    {
        Task<bool> Delete(string catalogueId);
    }
}
