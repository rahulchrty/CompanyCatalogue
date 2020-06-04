using CompanyCatalogue.Models;

namespace CompanyCatalogue.Interfaces
{
    public interface ICompanyUpdateModelValidation
    {
        bool IsModelValid(UpdateCompanyDetailModel updatedCompanyDetail);
    }
}
