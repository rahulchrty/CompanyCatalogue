using CompanyCatalogue.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CompanyCatalogue.Interfaces
{
    public interface IUpdateCompanyDetails
    {
        Task Update(List<CompanyDetailModel> companyDetails);
    }
}
