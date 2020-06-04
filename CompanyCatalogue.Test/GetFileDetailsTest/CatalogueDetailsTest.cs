using CompanyCatalogue.Business;
using CompanyCatalogue.Interfaces;
using CompanyCatalogue.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Threading.Tasks;

namespace CompanyCatalogue.Test
{
    [TestClass]
    public class CatalogueDetailsTest
    {
        private ICatalogueDetails _catalogueDetails;
        private Mock<IRetrieveCatalogueDetailsRepository> _mockRetrieveCatalogueDetailsRepo;
        [TestInitialize]
        public void Setup()
        {
            _mockRetrieveCatalogueDetailsRepo = new Mock<IRetrieveCatalogueDetailsRepository>();
            _catalogueDetails = new CatalogueDetails(_mockRetrieveCatalogueDetailsRepo.Object);
        }

        //Given: A catalogueId as "1"
        //When: I call GetCatalogueByCatalogueId
        //Then: get a type of Task<CatalogueByGuidModel>
        [TestMethod]
        public void Given_CatalogueId_As_string_1()
        {
            string catalogueId = "1";
            CatalogueByGuidModel catalogueByGuidModel = new CatalogueByGuidModel();
            var taskDecorator = Task.FromResult(catalogueByGuidModel);
            _mockRetrieveCatalogueDetailsRepo.Setup(x => x.GetCatalogueByGuid(It.IsAny<string>())).Returns(taskDecorator);
            var result = _catalogueDetails.GetCatalogueByCatalogueId(catalogueId);
            Assert.IsTrue(result is Task<CatalogueByGuidModel>);
        }

        //Given: A catalogueId as empty string 
        //When: I call GetCatalogueByCatalogueId
        //Then: GetCatalogueByGuid never executes
        [TestMethod]
        public void Given_CatalogueId_As_empty_string()
        {
            string catalogueId = string.Empty;
            var result = _catalogueDetails.GetCatalogueByCatalogueId(catalogueId);
            _mockRetrieveCatalogueDetailsRepo.Verify(x => x.GetCatalogueByGuid(It.IsAny<string>()), Times.Never());
        }

        //Given: A catalogueId as null 
        //When: I call GetCatalogueByCatalogueId
        //Then: GetCatalogueByGuid never executes
        [TestMethod]
        public void Given_CatalogueId_As_null()
        {
            string catalogueId = null;
            var result = _catalogueDetails.GetCatalogueByCatalogueId(catalogueId);
            _mockRetrieveCatalogueDetailsRepo.Verify(x => x.GetCatalogueByGuid(It.IsAny<string>()), Times.Never());
        }
    }
}
