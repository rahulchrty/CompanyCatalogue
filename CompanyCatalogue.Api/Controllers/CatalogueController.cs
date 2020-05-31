using CompanyCatalogue.Interfaces;
using CompanyCatalogue.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
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
        private IDeleteCompany _deleteCompany;
        private IDeleteCatalogue _deleteCatalogue;
        private IRetrieveCatalogue _retrieveCatalogue;
        private IUpdateCompanyDetails _updateCompanyDetails;
        public CatalogueController(IProcessCatalogueFile processCatalogueFile,
                                    ICatalogueDetails catalogueDetails,
                                    IDeleteCompany deleteCompany,
                                    IDeleteCatalogue deleteCatalogue,
                                    IRetrieveCatalogue retrieveCatalogue,
                                    IUpdateCompanyDetails updateCompanyDetails)
        {
            _processCatalogueFile = processCatalogueFile;
            _catalogueDetails = catalogueDetails;
            _deleteCompany = deleteCompany;
            _deleteCatalogue = deleteCatalogue;
            _retrieveCatalogue = retrieveCatalogue;
            _updateCompanyDetails = updateCompanyDetails;
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

        [HttpGet]
        public async Task<IActionResult> GetAllCatalogue()
        {
            try
            {
                List<CatalogueModel> catalogues = await _retrieveCatalogue.GetAllCatalogue();
                if (catalogues != null)
                {
                    return Ok(catalogues);
                }
                else
                {
                    return StatusCode(404);
                }
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpGet("{catalogueId}")]
        public async Task<IActionResult> GetCompanyDetails([FromRoute] string catalogueId)
        {
            try
            {
                CatalogueByGuidModel catalogueDetails = await _catalogueDetails.GetCatalogueByCatalogueId(catalogueId);
                if (catalogueDetails != null)
                {
                    return Ok(catalogueDetails);
                }
                else
                {
                    return StatusCode(404);
                }
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpDelete("{catalogueId}")]
        public async Task<IActionResult> DeleteCatalogue([FromRoute] string catalogueId)
        {
            try
            {
                await _deleteCatalogue.Delete(catalogueId);
                return StatusCode(204);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpDelete("company")]
        public IActionResult DeleteCompanyById([FromQuery] int companyId)
        {
            try
            {
                _deleteCompany.Delete(companyId);
                return StatusCode(204);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpPut("{catalogueId}")]
        public async Task<IActionResult> Update([FromBody] List<CompanyDetailModel> companyDetails)
        {
            try
            {
                await _updateCompanyDetails.Update(companyDetails);
                return StatusCode(202);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
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