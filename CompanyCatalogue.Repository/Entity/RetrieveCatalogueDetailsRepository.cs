using CompanyCatalogue.Entity;
using CompanyCatalogue.Interfaces;
using CompanyCatalogue.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace CompanyCatalogue.Repository
{
    public class RetrieveCatalogueDetailsRepository : IRetrieveCatalogueDetailsRepository
    {
        private CatalogueContext _catalogueContext;
        public RetrieveCatalogueDetailsRepository(CatalogueContext catalogueContext)
        {
            _catalogueContext = catalogueContext;
        }
        public async Task<CatalogueByGuidModel> GetCatalogueByGuid(string catalogueId)
        {
            CatalogueByGuidModel catalogueDetails = await (from catalogues in _catalogueContext.Catalogues
                                          where catalogues.CatalogueId == catalogueId
                                          select new CatalogueByGuidModel
                                          {
                                              CatalogueId = catalogues.CatalogueId,
                                              FileName = catalogues.FileName,
                                              CompanyDetails = (from company in _catalogueContext.CompanyDetails
                                                           where company.CatalogueId == catalogueId
                                                           select new CompanyDetailModel
                                                           {
                                                               SlNo = company.SlNo,
                                                               CompanyName = company.CompanyName,
                                                               Region = company.Region,
                                                               Sector = company.Sector,
                                                               SubSector = company.SubSector,
                                                               NumberOfEmployees = company.NumberOfEmployees,
                                                               TotalRevenues = company.TotalRevenues,
                                                               WebSite = company.WebSite
                                                           }).ToList()
                                          }).FirstOrDefaultAsync();

            return catalogueDetails;
        }
    }
}
