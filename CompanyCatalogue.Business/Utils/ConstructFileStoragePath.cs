using CompanyCatalogue.Interfaces;
using Microsoft.Extensions.Configuration;

namespace CompanyCatalogue.Business
{
    public class ConstructFileStoragePath : IConstructFileStoragePath
    {
        private IConfiguration _configuration;
        public ConstructFileStoragePath(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public string GetPath(string fileGuidId)
        {
            string filePath = _configuration.GetSection("FileStorage").GetSection("Path").Value 
                                + fileGuidId 
                                + _configuration.GetSection("FileStorage").GetSection("Extention").Value;
            return filePath;
        }
    }
}
