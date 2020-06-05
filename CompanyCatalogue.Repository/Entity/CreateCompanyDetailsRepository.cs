using CompanyCatalogue.Entity;
using CompanyCatalogue.Interfaces;
using CompanyCatalogue.Models;
using System.Collections.Generic;

namespace CompanyCatalogue.Repository
{
    public class CreateCompanyDetailsRepository : ICreateCompanyDetailsRepository
    {
        private readonly CatalogueContext _catalogueContext;
        public CreateCompanyDetailsRepository(CatalogueContext catalogueContext)
        {
            _catalogueContext = catalogueContext;
        }
        public void Create(List<CompanyDetailModel> catalogues, string guid)
        {
            foreach (CompanyDetailModel eachCompany in catalogues)
            {
                _catalogueContext.CompanyDetails.Add(new CompanyDetail
                {
                    CatalogueId = guid,
                    CompanyName = eachCompany.CompanyName,
                    Region = eachCompany.Region,
                    Sector = eachCompany.Sector,
                    NumberOfEmployees = eachCompany.NumberOfEmployees,
                    SubSector = eachCompany.SubSector,
                    TotalRevenues = eachCompany.TotalRevenues,
                    WebSite = eachCompany.WebSite
                });
            }
        }
    }
}
