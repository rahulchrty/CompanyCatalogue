using CompanyCatalogue.Entity;
using CompanyCatalogue.Interfaces;
using CompanyCatalogue.Models;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;

namespace CompanyCatalogue.Repository
{
    public class CatalogueUOF : ICatalogueUOW
    {
        private CatalogueContext _catalogueContext;
        public CatalogueUOF(CatalogueContext catalogueContext)
        {
            _catalogueContext = catalogueContext;
        }
        public void Create(List<CompanyDetailModel> catalogues, string guid, string fileName)
        {
            using (IDbContextTransaction transection = _catalogueContext.Database.BeginTransaction())
            {
                try
                {
                    _catalogueContext.Catalogues.Add(new Catalogue { 
                        CatalogueId = guid,
                        FileName = fileName
                    });
                    foreach (CompanyDetailModel eachCompany in catalogues)
                    {
                        _catalogueContext.CompanyDetails.Add(new CompanyDetail { 
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
                    _catalogueContext.SaveChanges();
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
