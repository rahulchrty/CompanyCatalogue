using CompanyCatalogue.Business;
using CompanyCatalogue.Interfaces;
using CompanyCatalogue.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CompanyCatalogue.Test
{
    [TestClass]
    public class CompanyUpdateModelValidationTest
    {
        ICompanyUpdateModelValidation _companyUpdateModelValidation;
        [TestInitialize]
        public void Setup()
        {
            _companyUpdateModelValidation = new CompanyUpdateModelValidation();
        }


        // Given: A an object of updated data with
        // updated CompanyName as hooli, 
        // AumberOfEmployees as 5,
        // And   WebSite as "hooli.xyz"
        // When: I call IsModelValid
        // Then: I get true
        [TestMethod]
        public void IsModelValid_Test_1()
        {
            UpdateCompanyDetailModel updatedCompanyDetail = new UpdateCompanyDetailModel
            {
                CompanyName = "Hooli",
                NumberOfEmployees = 5,
                WebSite = "hooli.xyz"
            };
            var result = _companyUpdateModelValidation.IsModelValid(updatedCompanyDetail);
            Assert.IsTrue(result);
        }

        // Given: A an object of updated data with
        // updated CompanyName as empty string, 
        // AumberOfEmployees as 5,
        // And   WebSite as "hooli.xyz"
        // When: I call IsModelValid
        // Then: I get true
        [TestMethod]
        public void IsModelValid_Test_2()
        {
            UpdateCompanyDetailModel updatedCompanyDetail = new UpdateCompanyDetailModel
            {
                CompanyName = string.Empty,
                NumberOfEmployees = 5,
                WebSite = "hooli.xyz"
            };
            var result = _companyUpdateModelValidation.IsModelValid(updatedCompanyDetail);
            Assert.IsFalse(result);
        }

        // Given: A an object of updated data with
        // updated CompanyName as null, 
        // AumberOfEmployees as 5,
        // And   WebSite as "hooli.xyz"
        // When: I call IsModelValid
        // Then: I get true
        [TestMethod]
        public void IsModelValid_Test_3()
        {
            UpdateCompanyDetailModel updatedCompanyDetail = new UpdateCompanyDetailModel
            {
                CompanyName = null,
                NumberOfEmployees = 5,
                WebSite = "hooli.xyz"
            };
            var result = _companyUpdateModelValidation.IsModelValid(updatedCompanyDetail);
            Assert.IsFalse(result);
        }

        // Given: A an object of updated data with
        // updated CompanyName as 'hooli', 
        // AumberOfEmployees as -5,
        // And   WebSite as "hooli.xyz"
        // When: I call IsModelValid
        // Then: I get true
        [TestMethod]
        public void IsModelValid_Test_4()
        {
            UpdateCompanyDetailModel updatedCompanyDetail = new UpdateCompanyDetailModel
            {
                CompanyName = "hooli",
                NumberOfEmployees = -5,
                WebSite = "hooli.xyz"
            };
            var result = _companyUpdateModelValidation.IsModelValid(updatedCompanyDetail);
            Assert.IsFalse(result);
        }

        // Given: A an object of updated data with
        // updated CompanyName as 'hooli', 
        // AumberOfEmployees as 5,
        // And   WebSite as empty string
        // When: I call IsModelValid
        // Then: I get true
        [TestMethod]
        public void IsModelValid_Test_5()
        {
            UpdateCompanyDetailModel updatedCompanyDetail = new UpdateCompanyDetailModel
            {
                CompanyName = "hooli",
                NumberOfEmployees = 5,
                WebSite = string.Empty
            };
            var result = _companyUpdateModelValidation.IsModelValid(updatedCompanyDetail);
            Assert.IsFalse(result);
        }

        // Given: A an object of updated data with
        // updated CompanyName as 'hooli', 
        // AumberOfEmployees as 5,
        // And   WebSite as null
        // When: I call IsModelValid
        // Then: I get true
        [TestMethod]
        public void IsModelValid_Test_6()
        {
            UpdateCompanyDetailModel updatedCompanyDetail = new UpdateCompanyDetailModel
            {
                CompanyName = "hooli",
                NumberOfEmployees = 5,
                WebSite = null
            };
            var result = _companyUpdateModelValidation.IsModelValid(updatedCompanyDetail);
            Assert.IsFalse(result);
        }

        // Given: A an object of updated data with
        // updated CompanyName as null, 
        // AumberOfEmployees as -5,
        // And   WebSite as null
        // When: I call IsModelValid
        // Then: I get true
        [TestMethod]
        public void IsModelValid_Test_7()
        {
            UpdateCompanyDetailModel updatedCompanyDetail = new UpdateCompanyDetailModel
            {
                CompanyName = null,
                NumberOfEmployees = -5,
                WebSite = null
            };
            var result = _companyUpdateModelValidation.IsModelValid(updatedCompanyDetail);
            Assert.IsFalse(result);
        }

        // Given: A an object of updated data with
        // updated CompanyName as null, 
        // AumberOfEmployees as -5,
        // And   WebSite as "hooli.com"
        // When: I call IsModelValid
        // Then: I get true
        [TestMethod]
        public void IsModelValid_Test_8()
        {
            UpdateCompanyDetailModel updatedCompanyDetail = new UpdateCompanyDetailModel
            {
                CompanyName = null,
                NumberOfEmployees = -5,
                WebSite = "hooli.com"
            };
            var result = _companyUpdateModelValidation.IsModelValid(updatedCompanyDetail);
            Assert.IsFalse(result);
        }

        // Given: A an object of updated data with
        // updated CompanyName as null, 
        // AumberOfEmployees as 5,
        // And   WebSite as null
        // When: I call IsModelValid
        // Then: I get true
        [TestMethod]
        public void IsModelValid_Test_9()
        {
            UpdateCompanyDetailModel updatedCompanyDetail = new UpdateCompanyDetailModel
            {
                CompanyName = null,
                NumberOfEmployees = 5,
                WebSite = null
            };
            var result = _companyUpdateModelValidation.IsModelValid(updatedCompanyDetail);
            Assert.IsFalse(result);
        }

        // Given: A an object of updated data with
        // updated CompanyName as "hooli", 
        // AumberOfEmployees as -5,
        // And   WebSite as null
        // When: I call IsModelValid
        // Then: I get true
        [TestMethod]
        public void IsModelValid_Test_10()
        {
            UpdateCompanyDetailModel updatedCompanyDetail = new UpdateCompanyDetailModel
            {
                CompanyName = "hooli",
                NumberOfEmployees = -5,
                WebSite = null
            };
            var result = _companyUpdateModelValidation.IsModelValid(updatedCompanyDetail);
            Assert.IsFalse(result);
        }
    }
}
