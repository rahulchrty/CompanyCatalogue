using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace CompanyCatalogue.Interfaces
{
    public interface ISaveFile
    {
        Task<string> Save(IFormFile file, string fileUniqueName);
    }
}
