using CompanyCatalogue.Models;
using System.Collections.Generic;

namespace CompanyCatalogue.Interfaces
{
    public interface IConstructExcelFile
    {
        void Create(string storagePath, List<CompanyDetailModel> companyDetails);
    }
}
