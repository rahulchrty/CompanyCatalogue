using CompanyCatalogue.Interfaces;
using CompanyCatalogue.Models;

namespace CompanyCatalogue.Business
{
    public class UpdateCompanyDetailsValidation : IUpdateCompanyDetailsValidation
    {
        private ICompanyUpdateModelValidation _companyUpdateModelValidation;
        public UpdateCompanyDetailsValidation(ICompanyUpdateModelValidation companyUpdateModelValidation)
        {
            _companyUpdateModelValidation = companyUpdateModelValidation;
        }
        public bool IsValid(string catalogueId, int companyId, UpdateCompanyDetailModel updatedCompanyDetail)
        {
            bool isAllValid = false;
            bool isModelValid = _companyUpdateModelValidation.IsModelValid(updatedCompanyDetail);
            if (!string.IsNullOrWhiteSpace(catalogueId) && companyId > 0 && isModelValid)
            {
                isAllValid = true;
            }
            return isAllValid;
        }
    }
}
