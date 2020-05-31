using CompanyCatalogue.Interfaces;
using Microsoft.AspNetCore.Http;
using System;
using System.Threading.Tasks;

namespace CompanyCatalogue.Repository
{
    public class LocalStorage : ISaveFile
    {
        public async Task<string> Save(IFormFile file, string fileUniqueName)
        {
            string filePath = "d:/" + fileUniqueName + ".xlsx";
            using (var stream = System.IO.File.Create(filePath))
            {
                await file.CopyToAsync(stream);
            }
            return filePath;
        }
    }
}
