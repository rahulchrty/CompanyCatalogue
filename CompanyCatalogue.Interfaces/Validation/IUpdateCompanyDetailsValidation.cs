using CompanyCatalogue.Models;

namespace CompanyCatalogue.Interfaces
{
    public interface IUpdateCompanyDetailsValidation
    {
        bool IsValid(string catalogueId, int companyId, UpdateCompanyDetailModel updatedCompanyDetail);
    }
}
