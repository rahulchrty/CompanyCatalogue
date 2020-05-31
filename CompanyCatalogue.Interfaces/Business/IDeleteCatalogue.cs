using System.Threading.Tasks;

namespace CompanyCatalogue.Interfaces
{
    public interface IDeleteCatalogue
    {
        Task Delete(string catalogueId);
    }
}
