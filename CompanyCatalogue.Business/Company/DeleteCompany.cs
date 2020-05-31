using CompanyCatalogue.Interfaces;
using System.Threading.Tasks;

namespace CompanyCatalogue.Business
{
    public class DeleteCompany : IDeleteCompany
    {
        private readonly IDeleteCompanyRepository _deleteCompanyRepository;
        public DeleteCompany(IDeleteCompanyRepository deleteCompanyRepository)
        {
            _deleteCompanyRepository = deleteCompanyRepository;
        }
        public async Task Delete(int companyId)
        {
            await _deleteCompanyRepository.Delete(companyId);
        }
    }
}
