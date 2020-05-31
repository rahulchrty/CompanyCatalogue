using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CompanyCatalogue.Models
{
    public class Catalogue
    {
        [Key]
        public string CatalogueId { get; set; }
        public string FileName { get; set; }
        public ICollection<CompanyDetail> CompanyDetails { get; set; }
    }
}
