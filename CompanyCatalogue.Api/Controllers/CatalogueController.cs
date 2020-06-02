using CompanyCatalogue.Interfaces;
using CompanyCatalogue.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CompanyCatalogue.Api.Controllers
{
    [EnableCors("company-cat-ui")]
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
        private IProcessExport _processExport;
        public CatalogueController(IProcessCatalogueFile processCatalogueFile,
                                    ICatalogueDetails catalogueDetails,
                                    IDeleteCompany deleteCompany,
                                    IDeleteCatalogue deleteCatalogue,
                                    IRetrieveCatalogue retrieveCatalogue,
                                    IUpdateCompanyDetails updateCompanyDetails,
                                    IProcessExport processExport)
        {
            _processCatalogueFile = processCatalogueFile;
            _catalogueDetails = catalogueDetails;
            _deleteCompany = deleteCompany;
            _deleteCatalogue = deleteCatalogue;
            _retrieveCatalogue = retrieveCatalogue;
            _updateCompanyDetails = updateCompanyDetails;
            _processExport = processExport;
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
        public async Task<IActionResult> DeleteCompanyById([FromQuery] int companyId)
        {
            try
            {
                await _deleteCompany.Delete(companyId);
                return StatusCode(204);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpPut("{catalogueId}/{companyId}")]
        public async Task<IActionResult> Update([FromRoute] string catalogueId, [FromRoute] int companyId, [FromBody] UpdateCompanyDetailModel companyDetails)
        {
            try
            {
                await _updateCompanyDetails.Update(catalogueId, companyId, companyDetails);
                return StatusCode(202);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpGet("Export")]
        public async Task<IActionResult> Export([FromQuery] string catalogueId)
        {
            byte[] file = await _processExport.Export(catalogueId);
            System.Net.Mime.ContentDisposition cd = new System.Net.Mime.ContentDisposition
            {
                FileName = "aa.xlsx",
                Inline = false  // false = prompt the user for downloading;  true = browser to try to show the file inline
            };
            Response.Headers.Add("Content-Disposition", cd.ToString());
            Response.Headers.Add("X-Content-Type-Options", "nosniff");
            return File(file, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet");
        }
    }
}