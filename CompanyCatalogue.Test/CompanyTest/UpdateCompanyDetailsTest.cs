using CompanyCatalogue.Business;
using CompanyCatalogue.Interfaces;
using CompanyCatalogue.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace CompanyCatalogue.Test
{
    [TestClass]
    public class UpdateCompanyDetailsTest
    {
        IUpdateCompanyDetails _updateCompanyDetails;
        private Mock<IUpdateCompanyDetailsValidation> _mockUpdateCompanyDetailsValidation;
        private Mock<IUpdateCompanyDetailsRepository> _mockUpdateCompanyDetailsRepository;
        [TestInitialize]
        public void Setup()
        {
            _mockUpdateCompanyDetailsValidation = new Mock<IUpdateCompanyDetailsValidation>();
            _mockUpdateCompanyDetailsRepository = new Mock<IUpdateCompanyDetailsRepository>();
            _updateCompanyDetails = new UpdateCompanyDetails(_mockUpdateCompanyDetailsValidation.Object, _mockUpdateCompanyDetailsRepository.Object);
        }

        //Given: an update data set for catalogueId "1a" and companyid 1
        //When: I call Update
        //Then: I get true
        [TestMethod]
        public void Given_Set_Of_Update_Data_For_CatalogueId_1a_And_CompanyId_1_Then_Return_True()
        {
            string catalogueId = "1a";
            int companyId = 1;
            UpdateCompanyDetailModel updatedData = new UpdateCompanyDetailModel { 
                CompanyName = "hooli",
                NumberOfEmployees = 50,
                Region = "WW",
                Sector = "Media",
                SubSector = "News",
                TotalRevenues = 123,
                WebSite = "hooli.xyz"
            };

            _mockUpdateCompanyDetailsValidation
                .Setup(x => x.IsValid(It.IsAny<string>(), It.IsAny<int>(), It.IsAny<UpdateCompanyDetailModel>()))
                .Returns(true);
            _mockUpdateCompanyDetailsRepository
                .Setup(x => x.Update(It.IsAny<string>(), It.IsAny<int>(), It.IsAny<UpdateCompanyDetailModel>()));
            var result = _updateCompanyDetails.Update(catalogueId, companyId, updatedData);
            Assert.IsTrue(result.Result);
        }

        //Given: an update data set for catalogueId "1a" and companyid 1
        //When: I call Update
        //Then: IUpdateCompanyDetailsRepository.Update executes
        [TestMethod]
        public void Given_Set_Of_Update_Data_For_CatalogueId_1a_And_CompanyId_1()
        {
            string catalogueId = "1a";
            int companyId = 1;
            UpdateCompanyDetailModel updatedData = new UpdateCompanyDetailModel
            {
                CompanyName = "hooli",
                NumberOfEmployees = 50,
                Region = "WW",
                Sector = "Media",
                SubSector = "News",
                TotalRevenues = 123,
                WebSite = "hooli.xyz"
            };

            _mockUpdateCompanyDetailsValidation
                .Setup(x => x.IsValid(It.IsAny<string>(), It.IsAny<int>(), It.IsAny<UpdateCompanyDetailModel>()))
                .Returns(true);
            _mockUpdateCompanyDetailsRepository
                .Setup(x => x.Update(It.IsAny<string>(), It.IsAny<int>(), It.IsAny<UpdateCompanyDetailModel>()));
            var result = _updateCompanyDetails.Update(catalogueId, companyId, updatedData);
            _mockUpdateCompanyDetailsRepository
                .Verify(x => x.Update(It.IsAny<string>(), It.IsAny<int>(), It.IsAny<UpdateCompanyDetailModel>()), Times.Once());
        }

        //Given: an update data set as null for catalogueId empty string and companyid 0
        //When: I call Update
        //Then: IUpdateCompanyDetailsRepository.Update never executes
        [TestMethod]
        public void Given_Set_Of_Update_Data_As_Null_For_CatalogueId_Empty_String_And_CompanyId_0()
        {
            string catalogueId = string.Empty;
            int companyId = 0;
            UpdateCompanyDetailModel updatedData = null;

            _mockUpdateCompanyDetailsValidation
                .Setup(x => x.IsValid(It.IsAny<string>(), It.IsAny<int>(), It.IsAny<UpdateCompanyDetailModel>()))
                .Returns(false);
            var result = _updateCompanyDetails.Update(catalogueId, companyId, updatedData);
            _mockUpdateCompanyDetailsRepository
                .Verify(x => x.Update(It.IsAny<string>(), It.IsAny<int>(), It.IsAny<UpdateCompanyDetailModel>()), Times.Never());
        }
    }
}
