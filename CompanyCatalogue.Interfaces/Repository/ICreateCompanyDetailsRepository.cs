using CompanyCatalogue.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CompanyCatalogue.Interfaces
{
    public interface ICreateCompanyDetailsRepository
    {
        void Create(List<CompanyDetailModel> catalogues, string guid);
    }
}
