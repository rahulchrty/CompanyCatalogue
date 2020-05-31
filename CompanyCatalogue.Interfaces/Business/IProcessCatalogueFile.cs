using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace CompanyCatalogue.Interfaces
{
    public interface IProcessCatalogueFile
    {
        Task<string> Process(IFormFile catalogueFile);
    }
}
