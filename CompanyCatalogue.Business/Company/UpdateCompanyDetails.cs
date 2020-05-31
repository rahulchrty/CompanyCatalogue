using CompanyCatalogue.Interfaces;
using CompanyCatalogue.Models;
using System.Collections.Generic;
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
        public async Task Update(List<CompanyDetailModel> companyDetails)
        {
            foreach (CompanyDetailModel eachCompany in companyDetails)
            {
                await _updateCompanyDetailsRepository.Update(eachCompany);
            }
        }
    }
}
