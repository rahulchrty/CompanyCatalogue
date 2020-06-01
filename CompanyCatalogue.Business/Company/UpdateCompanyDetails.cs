using CompanyCatalogue.Interfaces;
using CompanyCatalogue.Models;
using System.Threading.Tasks;

namespace CompanyCatalogue.Business
{
    public class UpdateCompanyDetails : IUpdateCompanyDetails
    {
        private IUpdateCompanyDetailsRepository _updateCompanyDetailsRepository;
        public UpdateCompanyDetails(IUpdateCompanyDetailsRepository updateCompanyDetailsRepository)
        {
            _updateCompanyDetailsRepository = updateCompanyDetailsRepository;
        }
        public async Task Update(string catalogueId, int companyId, UpdateCompanyDetailModel updatedCompanyDetail)
        {
            await _updateCompanyDetailsRepository.Update(catalogueId, companyId, updatedCompanyDetail);
        }
    }
}
