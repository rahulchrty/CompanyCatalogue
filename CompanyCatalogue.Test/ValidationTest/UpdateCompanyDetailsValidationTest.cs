using CompanyCatalogue.Business;
using CompanyCatalogue.Interfaces;
using CompanyCatalogue.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace CompanyCatalogue.Test
{
    [TestClass]
    public class UpdateCompanyDetailsValidationTest
    {
        private IUpdateCompanyDetailsValidation _updateCompanyDetailsValidation;
        private Mock<ICompanyUpdateModelValidation> _mockCompanyUpdateModelValidation;
        [TestInitialize]
        public void Setup()
        {
            _mockCompanyUpdateModelValidation = new Mock<ICompanyUpdateModelValidation>();
            _updateCompanyDetailsValidation = new UpdateCompanyDetailsValidation(_mockCompanyUpdateModelValidation.Object);
        }

        // Given a catalogueId as '1a'
        // companyId as 1
        // updated CompanyName as hooli, 
        // AumberOfEmployees as 5,
        // TotalRevenues as 10,
        // And   WebSite as "hooli.xyz"
        // When: I call IsValid
        // Then: I get true
        [TestMethod]
        public void Validation_Test_1()
        {
            string catalogueId = "1a";
            int companyId = 1;
            UpdateCompanyDetailModel updatedCompanyDetail = new UpdateCompanyDetailModel
            {
                CompanyName = "Hooli",
                NumberOfEmployees = 5,
                TotalRevenues = 10,
                WebSite = "hooli.xyz"
            };

            _mockCompanyUpdateModelValidation
                .Setup(x => x.IsModelValid(It.IsAny<UpdateCompanyDetailModel>()))
                .Returns(true);
            var result = _updateCompanyDetailsValidation.IsValid(catalogueId, companyId, updatedCompanyDetail);
            Assert.IsTrue(result);
        }

        // Given a catalogueId as empty string
        // companyId as 1
        // updated CompanyName as hooli, 
        // AumberOfEmployees as 5,
        // TotalRevenues as 10,
        // And   WebSite as "hooli.xyz"
        // When: I call IsValid
        // Then: I get false
        [TestMethod]
        public void Validation_Test_2()
        {
            string catalogueId = string.Empty;
            int companyId = 1;
            UpdateCompanyDetailModel updatedCompanyDetail = new UpdateCompanyDetailModel
            {
                CompanyName = "Hooli",
                NumberOfEmployees = 5,
                TotalRevenues = 10,
                WebSite = "hooli.xyz"
            };

            _mockCompanyUpdateModelValidation
                .Setup(x => x.IsModelValid(It.IsAny<UpdateCompanyDetailModel>()))
                .Returns(true);
            var result = _updateCompanyDetailsValidation.IsValid(catalogueId, companyId, updatedCompanyDetail);
            Assert.IsFalse(result);
        }

        // Given a catalogueId as null
        // companyId as 1
        // updated CompanyName as hooli, 
        // AumberOfEmployees as 5,
        // TotalRevenues as 10,
        // And   WebSite as "hooli.xyz"
        // When: I call IsValid
        // Then: I get false
        [TestMethod]
        public void Validation_Test_3()
        {
            string catalogueId = null;
            int companyId = 1;
            UpdateCompanyDetailModel updatedCompanyDetail = new UpdateCompanyDetailModel
            {
                CompanyName = "Hooli",
                NumberOfEmployees = 5,
                TotalRevenues = 10,
                WebSite = "hooli.xyz"
            };

            _mockCompanyUpdateModelValidation
                .Setup(x => x.IsModelValid(It.IsAny<UpdateCompanyDetailModel>()))
                .Returns(true);
            var result = _updateCompanyDetailsValidation.IsValid(catalogueId, companyId, updatedCompanyDetail);
            Assert.IsFalse(result);
        }

        // Given a catalogueId as '1a'
        // companyId as -1
        // updated CompanyName as hooli, 
        // AumberOfEmployees as 5,
        // TotalRevenues as 10,
        // And   WebSite as "hooli.xyz"
        // When: I call IsValid
        // Then: I get false
        [TestMethod]
        public void Validation_Test_4()
        {
            string catalogueId = "1a";
            int companyId = -1;
            UpdateCompanyDetailModel updatedCompanyDetail = new UpdateCompanyDetailModel
            {
                CompanyName = "Hooli",
                NumberOfEmployees = 5,
                TotalRevenues = 10,
                WebSite = "hooli.xyz"
            };

            _mockCompanyUpdateModelValidation
                .Setup(x => x.IsModelValid(It.IsAny<UpdateCompanyDetailModel>()))
                .Returns(true);
            var result = _updateCompanyDetailsValidation.IsValid(catalogueId, companyId, updatedCompanyDetail);
            Assert.IsFalse(result);
        }

        // Given a catalogueId as '1a'
        // companyId as 2
        // Updated data set as null
        // When: I call IsValid
        // Then: I get false
        [TestMethod]
        public void Validation_Test_5()
        {
            string catalogueId = "1a";
            int companyId = -1;
            UpdateCompanyDetailModel updatedCompanyDetail = null;

            _mockCompanyUpdateModelValidation
                .Setup(x => x.IsModelValid(It.IsAny<UpdateCompanyDetailModel>()))
                .Returns(false);
            var result = _updateCompanyDetailsValidation.IsValid(catalogueId, companyId, updatedCompanyDetail);
            Assert.IsFalse(result);
        }

        // Given a catalogueId as null
        // companyId as 0
        // Updated data set as null
        // When: I call IsValid
        // Then: I get false
        [TestMethod]
        public void Validation_Test_6()
        {
            string catalogueId = null;
            int companyId = 0;
            UpdateCompanyDetailModel updatedCompanyDetail = null;

            _mockCompanyUpdateModelValidation
                .Setup(x => x.IsModelValid(It.IsAny<UpdateCompanyDetailModel>()))
                .Returns(false);
            var result = _updateCompanyDetailsValidation.IsValid(catalogueId, companyId, updatedCompanyDetail);
            Assert.IsFalse(result);
        }

        // Given a catalogueId as null
        // companyId as 1
        // Updated data set as null
        // When: I call IsValid
        // Then: I get false
        [TestMethod]
        public void Validation_Test_7()
        {
            string catalogueId = null;
            int companyId = 1;
            UpdateCompanyDetailModel updatedCompanyDetail = null;

            _mockCompanyUpdateModelValidation
                .Setup(x => x.IsModelValid(It.IsAny<UpdateCompanyDetailModel>()))
                .Returns(false);
            var result = _updateCompanyDetailsValidation.IsValid(catalogueId, companyId, updatedCompanyDetail);
            Assert.IsFalse(result);
        }

        // Given a catalogueId as '1a'
        // companyId as 0
        // Updated data set as null
        // When: I call IsValid
        // Then: I get false
        [TestMethod]
        public void Validation_Test_8()
        {
            string catalogueId = "1a";
            int companyId = 0;
            UpdateCompanyDetailModel updatedCompanyDetail = null;

            _mockCompanyUpdateModelValidation
                .Setup(x => x.IsModelValid(It.IsAny<UpdateCompanyDetailModel>()))
                .Returns(false);
            var result = _updateCompanyDetailsValidation.IsValid(catalogueId, companyId, updatedCompanyDetail);
            Assert.IsFalse(result);
        }
    }
}
