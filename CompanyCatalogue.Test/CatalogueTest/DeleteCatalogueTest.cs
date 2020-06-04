using CompanyCatalogue.Business;
using CompanyCatalogue.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;


namespace CompanyCatalogue.Test
{
    [TestClass]
    public class DeleteCatalogueTest
    {
        private IDeleteCatalogue deleteCatalogue;
        private Mock<IDeleteCataloguesRepository> _mockDeleteCataloguesRepository;
        [TestInitialize]
        public void Setup()
        {
            _mockDeleteCataloguesRepository = new Mock<IDeleteCataloguesRepository>();
            deleteCatalogue = new DeleteCatalogue(_mockDeleteCataloguesRepository.Object);
        }

        //Given: a catalogueId as '1'
        //When: I call Delete
        //Then:  IDeleteCataloguesRepository.Delete executes
        [TestMethod]
        public void Given_CatalogueId_As_1()
        {
            string catalogueId = "1";
            _mockDeleteCataloguesRepository.Setup(x => x.Delete(It.IsAny<string>()));
            deleteCatalogue.Delete(catalogueId);
            _mockDeleteCataloguesRepository.Verify(x => x.Delete(It.IsAny<string>()), Times.Once());
        }

        //Given: a catalogueId as empty string
        //When: I call Delete
        //Then:  IDeleteCataloguesRepository.Delete never executes
        [TestMethod]
        public void Given_CatalogueId_As_Empty_String()
        {
            string catalogueId = string.Empty;
            _mockDeleteCataloguesRepository.Setup(x => x.Delete(It.IsAny<string>()));
            deleteCatalogue.Delete(catalogueId);
            _mockDeleteCataloguesRepository.Verify(x => x.Delete(It.IsAny<string>()), Times.Never());
        }

        //Given: a catalogueId as null
        //When: I call Delete
        //Then:  IDeleteCataloguesRepository.Delete never executes
        [TestMethod]
        public void Given_CatalogueId_As_null()
        {
            string catalogueId = null;
            _mockDeleteCataloguesRepository.Setup(x => x.Delete(It.IsAny<string>()));
            deleteCatalogue.Delete(catalogueId);
            _mockDeleteCataloguesRepository.Verify(x => x.Delete(It.IsAny<string>()), Times.Never());
        }
    }
}
