using CompanyCatalogue.Entity;
using CompanyCatalogue.Interfaces;
using CompanyCatalogue.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CompanyCatalogue.Repository
{
    public class DeleteCompanyRepository : IDeleteCompanyRepository
    {
        private CatalogueContext _catalogueContext;
        public DeleteCompanyRepository(CatalogueContext catalogueContext)
        {
            _catalogueContext = catalogueContext;
        }
        public async Task Delete(int companyId)
        {
            CompanyDetail companyDetail = new CompanyDetail { CompanyId = companyId };
            _catalogueContext.CompanyDetails.Attach(companyDetail);
            _catalogueContext.CompanyDetails.Remove(companyDetail);
            await _catalogueContext.SaveChangesAsync();
        }
    }
}
