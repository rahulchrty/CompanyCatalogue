using System.ComponentModel.DataAnnotations;

namespace CompanyCatalogue.Models
{
    public class CompanyDetail
    {
        [Key]
        public int CompanyId { get; set; }
        public string CatalogueId { get; set; }
        [Required]
        public string CompanyName { get; set; }
        public string Sector { get; set; }
        public string SubSector { get; set; }
        public string Region { get; set; }
        public int NumberOfEmployees { get; set; }
        public double TotalRevenues { get; set; }
        public string WebSite { get; set; }
        public Catalogue Catalogue { get; set; }
    }
}
