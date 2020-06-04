using CompanyCatalogue.Interfaces;
using CompanyCatalogue.Models;

namespace CompanyCatalogue.Business
{
    public class CompanyUpdateModelValidation : ICompanyUpdateModelValidation
    {
        public bool IsModelValid (UpdateCompanyDetailModel updatedCompanyDetail)
        {
            bool isValid = false;
            if (updatedCompanyDetail != null)
            {
                if (!string.IsNullOrWhiteSpace(updatedCompanyDetail.CompanyName)
                    && (updatedCompanyDetail.NumberOfEmployees > 0 )
                    && !string.IsNullOrWhiteSpace(updatedCompanyDetail.WebSite))
                {
                    isValid = true;
                }
            }
            return isValid;
        }
    }
}
