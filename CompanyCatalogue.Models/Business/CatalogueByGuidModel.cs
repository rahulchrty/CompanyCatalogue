using System.Collections.Generic;

namespace CompanyCatalogue.Models
{
    public class CatalogueByGuidModel
    {
        public string CatalogueId { get; set; }
        public string FileName { get; set; }
        public List<CompanyDetailModel> CompanyDetails { get; set; }
    }
}
