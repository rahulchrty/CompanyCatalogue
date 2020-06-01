using CompanyCatalogue.Models;
using System.Threading.Tasks;

namespace CompanyCatalogue.Interfaces
{
    public interface IUpdateCompanyDetails
    {
        Task Update(string catalogueId, int companyId, UpdateCompanyDetailModel updatedCompanyDetail);
    }
}
