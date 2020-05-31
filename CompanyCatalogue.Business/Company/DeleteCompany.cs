using CompanyCatalogue.Interfaces;

namespace CompanyCatalogue.Business
{
    public class DeleteCompany : IDeleteCompany
    {
        private IDeleteCompanyRepository _deleteCompanyRepository;
        public DeleteCompany(IDeleteCompanyRepository deleteCompanyRepository)
        {
            _deleteCompanyRepository = deleteCompanyRepository;
        }
        public void Delete(int companyId)
        {
            _deleteCompanyRepository.Delete(companyId);
        }
    }
}
