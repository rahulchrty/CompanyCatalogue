using CompanyCatalogue.Interfaces;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace CompanyCatalogue.Repository
{
    public class LocalStorage : ISaveFile
    {
        public async Task Save(IFormFile file, string filePath)
        {            
            using (var stream = System.IO.File.Create(filePath))
            {
                await file.CopyToAsync(stream);
            }
        }
    }
}
