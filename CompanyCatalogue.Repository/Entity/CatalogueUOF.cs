using CompanyCatalogue.Entity;
using CompanyCatalogue.Interfaces;
using CompanyCatalogue.Models;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CompanyCatalogue.Repository
{
    public class CatalogueUOF : ICatalogueUOW
    {
        private CatalogueContext _catalogueContext;
        private ICreateCatalogueRepository _createCatalogueRepository;
        private ICreateCompanyDetailsRepository _createCompanyDetailsRepository;
        public CatalogueUOF(CatalogueContext catalogueContext,
                            ICreateCatalogueRepository createCatalogueRepository,
                            ICreateCompanyDetailsRepository createCompanyDetailsRepository)
        {
            _catalogueContext = catalogueContext;
            _createCatalogueRepository = createCatalogueRepository;
            _createCompanyDetailsRepository = createCompanyDetailsRepository;
        }
        public async Task Create(List<CompanyDetailModel> catalogues, string guid, string fileName)
        {
            using (IDbContextTransaction transection = _catalogueContext.Database.BeginTransaction())
            {
                try
                {
                    _createCatalogueRepository.Create(guid, fileName);
                    _createCompanyDetailsRepository.Create(catalogues, guid);
                    await _catalogueContext.SaveChangesAsync();
                    transection.Commit();
                }
                catch (Exception e)
                {
                    throw e;
                }
            }
        }
    }
}
