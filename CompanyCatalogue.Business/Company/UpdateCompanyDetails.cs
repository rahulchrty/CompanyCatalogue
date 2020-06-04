using CompanyCatalogue.Interfaces;
using CompanyCatalogue.Models;
using System.Threading.Tasks;

namespace CompanyCatalogue.Business
{
    public class UpdateCompanyDetails : IUpdateCompanyDetails
    {
        private IUpdateCompanyDetailsValidation _updateCompanyDetailsValidation;
        private IUpdateCompanyDetailsRepository _updateCompanyDetailsRepository;
        public UpdateCompanyDetails(
                                    IUpdateCompanyDetailsValidation updateCompanyDetailsValidation,
                                    IUpdateCompanyDetailsRepository updateCompanyDetailsRepository)
        {
            _updateCompanyDetailsValidation = updateCompanyDetailsValidation;
            _updateCompanyDetailsRepository = updateCompanyDetailsRepository;
        }
        public async Task<bool> Update(string catalogueId, int companyId, UpdateCompanyDetailModel updatedCompanyDetail)
        {
            bool isSuccess = false;
            if (_updateCompanyDetailsValidation.IsValid(catalogueId, companyId, updatedCompanyDetail))
            {
                await _updateCompanyDetailsRepository.Update(catalogueId, companyId, updatedCompanyDetail);
                isSuccess = true;
            }
            return isSuccess;
        }
    }
}
