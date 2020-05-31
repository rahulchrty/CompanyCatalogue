using CompanyCatalogue.Entity;
using CompanyCatalogue.Interfaces;
using CompanyCatalogue.Models;
using System.Linq;
using System.Threading.Tasks;

namespace CompanyCatalogue.Repository
{
    public class UpdateCompanyDetailsRepository : IUpdateCompanyDetailsRepository
    {
        private CatalogueContext _catalogueContext;
        public UpdateCompanyDetailsRepository(CatalogueContext catalogueContext)
        {
            _catalogueContext = catalogueContext;
        }
        public Task Update(CompanyDetailModel updatedCompanyDetail)
        {
            CompanyDetail companyDetail =  _catalogueContext.CompanyDetails
                                .FirstOrDefault(x=>x.CompanyId == updatedCompanyDetail.CompanyId);
            companyDetail.CompanyName = updatedCompanyDetail.CompanyName;
            companyDetail.Region = updatedCompanyDetail.Region;
            companyDetail.Sector = updatedCompanyDetail.Sector;
            companyDetail.SubSector = updatedCompanyDetail.SubSector;
            companyDetail.TotalRevenues = updatedCompanyDetail.TotalRevenues;
            companyDetail.WebSite = updatedCompanyDetail.WebSite;
            companyDetail.NumberOfEmployees = updatedCompanyDetail.NumberOfEmployees;
            _catalogueContext.CompanyDetails.Update(companyDetail);
            return _catalogueContext.SaveChangesAsync();
        }
    }
}
