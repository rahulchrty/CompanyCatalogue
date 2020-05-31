using System.Threading.Tasks;

namespace CompanyCatalogue.Interfaces
{
    public interface IDeleteCompanyRepository
    {
        Task Delete(int companyId);
    }
}
