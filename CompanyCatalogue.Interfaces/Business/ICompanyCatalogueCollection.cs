using CompanyCatalogue.Models;
using System.Collections.Generic;
using System.Data;

namespace CompanyCatalogue.Interfaces
{
    public interface ICompanyCatalogueCollection
    {
        List<CompanyDetailModel> GetCollection(DataTable dtCompanyCatalogue);
    }
}
