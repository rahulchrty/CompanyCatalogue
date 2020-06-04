using CompanyCatalogue.Business;
using CompanyCatalogue.Interfaces;
using CompanyCatalogue.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CompanyCatalogue.Test
{
    [TestClass]
    public class RetrieveCatalogueTest
    {
        private IRetrieveCatalogue _retrieveCatalogue;
        private Mock<IRetrieveCatalogueRepository> _mockRetrieveCatalogueRepo;
        [TestInitialize]
        public void Setup()
        {
            _mockRetrieveCatalogueRepo = new Mock<IRetrieveCatalogueRepository>();
            _retrieveCatalogue = new RetrieveCatalogue(_mockRetrieveCatalogueRepo.Object);
        }

        //Given:
        //When: I call  I call GetAllCatalogue
        //Then: I get type of List<CatalogueModel>
        [TestMethod]
        public void Test_GetAllCatalogue()
        {
            List<CatalogueModel> catalogueList = new List<CatalogueModel>();
            var taskDecorator = Task.FromResult(catalogueList);
            _mockRetrieveCatalogueRepo.Setup(x => x.GetAllCatalogues()).Returns(taskDecorator);
            var result = _retrieveCatalogue.GetAllCatalogue();

            Assert.IsTrue(result is Task<List<CatalogueModel>>);
        }
    }
}
