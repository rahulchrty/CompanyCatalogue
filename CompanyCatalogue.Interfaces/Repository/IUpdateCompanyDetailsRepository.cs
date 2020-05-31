using CompanyCatalogue.Models;
using System.Threading.Tasks;

namespace CompanyCatalogue.Interfaces
{
    public interface IUpdateCompanyDetailsRepository
    {
        Task Update(CompanyDetailModel companyDetails);
    }
}
