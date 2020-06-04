using CompanyCatalogue.Interfaces;
using CompanyCatalogue.Models;
using System;
using System.IO;
using System.Threading.Tasks;

namespace CompanyCatalogue.Business
{
    public class ProcessExport : IProcessExport
    {
        private readonly IConstructFileStoragePath _constructFileStoragePath;
        private readonly IRetrieveCatalogueDetailsRepository _retrieveCatalogueDetailsRepo;
        private IConstructExcelFile _constructExcelFile;
        private IDeleteFile _deleteFile;
        public ProcessExport(IConstructFileStoragePath constructFileStoragePath,
                            IRetrieveCatalogueDetailsRepository retrieveCatalogueDetailsRepo,
                            IConstructExcelFile constructExcelFile,
                            IDeleteFile deleteFile)
        {
            _constructFileStoragePath = constructFileStoragePath;
            _retrieveCatalogueDetailsRepo = retrieveCatalogueDetailsRepo;
            _constructExcelFile = constructExcelFile;
            _deleteFile = deleteFile;
        }
        public async Task<byte[]> Export(string catalogueId)
        {
            try
            {
                CatalogueByGuidModel catalogueDetails = await _retrieveCatalogueDetailsRepo.GetCatalogueByGuid(catalogueId);
                string path = _constructFileStoragePath.GetPath(catalogueId);
                _constructExcelFile.Create(path, catalogueDetails.CompanyDetails);
                byte[] file = File.ReadAllBytes(path);
                _deleteFile.Delete(path);
                return file;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
