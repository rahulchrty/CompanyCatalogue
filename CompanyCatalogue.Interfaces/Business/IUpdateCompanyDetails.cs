using CompanyCatalogue.Models;
using System.Threading.Tasks;

namespace CompanyCatalogue.Interfaces
{
    public interface IUpdateCompanyDetails
    {
        Task<bool> Update(string catalogueId, int companyId, UpdateCompanyDetailModel updatedCompanyDetail);
    }
}
