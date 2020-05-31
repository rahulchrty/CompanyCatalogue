using System.Threading.Tasks;

namespace CompanyCatalogue.Interfaces
{
    public interface IDeleteCompany
    {
        Task Delete(int companyId);
    }
}
