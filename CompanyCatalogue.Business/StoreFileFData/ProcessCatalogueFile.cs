using CompanyCatalogue.Interfaces;
using CompanyCatalogue.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace CompanyCatalogue.Business
{
    public class ProcessCatalogueFile : IProcessCatalogueFile
    {
        private readonly ISaveFile _saveFile;
        private IFileParser _fileParser;
        private ICompanyCatalogueCollection _companyCatalogueCollection;
        private ICatalogueUOW _catalogueUOW;
        private IDeleteFile _deleteFile;
        public ProcessCatalogueFile(ISaveFile saveFile,
                                    IFileParser fileParser,
                                    ICompanyCatalogueCollection companyCatalogueCollection,
                                    ICatalogueUOW catalogueUOW,
                                    IDeleteFile deleteFile)
        {
            _saveFile = saveFile;
            _fileParser = fileParser;
            _companyCatalogueCollection = companyCatalogueCollection;
            _catalogueUOW = catalogueUOW;
            _deleteFile = deleteFile;
        }
        public async Task<string> Process(IFormFile catalogueFile)
        {
            string fileUniqueGuid = Guid.NewGuid().ToString();  
            if (catalogueFile != null)
            {
                string savedPath = await _saveFile.Save(catalogueFile, fileUniqueGuid);
                DataTable dtCompanyCatalogue = _fileParser.Parse(savedPath);
                //validation goes here
                List<CompanyDetailModel> catalogueDetails = _companyCatalogueCollection.GetCollection(dtCompanyCatalogue);
                _catalogueUOW.Create(catalogueDetails, fileUniqueGuid, catalogueFile.FileName);
                _deleteFile.Delete(savedPath);
            }
            return fileUniqueGuid;
        }
    }
}
