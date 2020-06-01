using CompanyCatalogue.Interfaces;
using CompanyCatalogue.Models;
using System;
using System.IO;
using System.Threading.Tasks;

namespace CompanyCatalogue.Business
{
    public class ProcessExport : IProcessExport
    {
        private readonly IRetrieveCatalogueDetailsRepository _retrieveCatalogueDetailsRepo;
        private IConstructExcelFile _constructExcelFile;
        private IDeleteFile _deleteFile;
        public ProcessExport(IRetrieveCatalogueDetailsRepository retrieveCatalogueDetailsRepo,
                            IConstructExcelFile constructExcelFile,
                            IDeleteFile deleteFile)
        {
            _retrieveCatalogueDetailsRepo = retrieveCatalogueDetailsRepo;
            _constructExcelFile = constructExcelFile;
            _deleteFile = deleteFile;
        }
        public async Task<byte[]> Export(string catalogueId)
        {
            try
            {
                CatalogueByGuidModel catalogueDetails = await _retrieveCatalogueDetailsRepo.GetCatalogueByGuid(catalogueId);
                string path = "d:/" + catalogueDetails.CatalogueId + ".xlsx";
                _constructExcelFile.Create(path, catalogueDetails.CompanyDetails);
                byte[] file = File.ReadAllBytes(path);
                //FileStream fileStream = new FileStream(path, FileMode.Open);
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
