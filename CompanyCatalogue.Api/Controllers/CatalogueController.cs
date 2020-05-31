using CompanyCatalogue.Interfaces;
using CompanyCatalogue.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Threading.Tasks;

namespace CompanyCatalogue.Api.Controllers
{
    [Route("api/catalogue")]
    [ApiController]
    public class CatalogueController : ControllerBase
    {
        private IProcessCatalogueFile _processCatalogueFile;
        private ICatalogueDetails _catalogueDetails;
        public CatalogueController(IProcessCatalogueFile processCatalogueFile,
                                    ICatalogueDetails catalogueDetails)
        {
            _processCatalogueFile = processCatalogueFile;
            _catalogueDetails = catalogueDetails;
        }
        [HttpPost]
        public async Task<IActionResult> PostAsync(IFormFile catalogueFile)
        {
            try
            {
                string catalogueId = await _processCatalogueFile.Process(catalogueFile);
                return Created("api/catalogue/" + catalogueId, new { CatalogueId = catalogueId });
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpGet("{catalogueId}")]
        public async Task<IActionResult> Get([FromRoute] string catalogueId)
        {
            CatalogueByGuidModel catalogueDetails = await _catalogueDetails.GetCatalogueByCatalogueId(catalogueId);
            return Ok(catalogueDetails);
        }


        [HttpGet("Export")]
        public async Task<FileStreamResult> Export([FromQuery] string fileGuid)
        {
            string filePath = "d:/" + fileGuid + ".xlsx";
            var fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read);
            return new FileStreamResult(fileStream, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet")
            {
                FileDownloadName = fileGuid + ".xlsx"
            };
        }
    }
}