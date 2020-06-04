using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace CompanyCatalogue.Interfaces
{
    public interface ISaveFile
    {
        Task Save(IFormFile file, string filePath);
    }
}
