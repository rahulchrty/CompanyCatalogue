using CompanyCatalogue.Models;
using System.Collections.Generic;

namespace CompanyCatalogue.Interfaces
{
    public interface ICatalogueUOW
    {
        void Create(List<CompanyDetailModel> catalogues, string guid, string fileName);
    }
}
