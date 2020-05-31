using CompanyCatalogue.Interfaces;
using CompanyCatalogue.Models;
using System.Collections.Generic;
using System.Data;

namespace CompanyCatalogue.Business
{
    public class CompanyCatalogueCollection : ICompanyCatalogueCollection
    {
        public List<CompanyDetailModel> GetCollection(DataTable dtCompanyCatalogue)
        {
            List<CompanyDetailModel> catalogueDetails = new List<CompanyDetailModel>();
            foreach (DataRow eachRow in dtCompanyCatalogue.Rows)
            {
                catalogueDetails.Add(new CompanyDetailModel
                {
                    CompanyName = eachRow["Company"].ToString(),
                    Sector = eachRow["Sector"].ToString(),
                    SubSector = eachRow["Sub-Sector"].ToString(),
                    Region = eachRow["Region"].ToString(),
                    NumberOfEmployees = int.Parse(eachRow["No. of Employees"].ToString()),
                    TotalRevenues = double.Parse(eachRow["Total Revenues (in $M)"].ToString()),
                    WebSite = eachRow["Websites"].ToString()
                });
            }
            return catalogueDetails;
        }
    }
}
