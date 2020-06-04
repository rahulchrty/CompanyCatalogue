using CompanyCatalogue.Business;
using CompanyCatalogue.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace CompanyCatalogue.Test
{
    [TestClass]
    public class DeleteCompanyTest
    {
        private IDeleteCompany _deleteCompany;
        private Mock<IDeleteCompanyRepository> _mockDeleteCompanyRepository;
        [TestInitialize]
        public void Setup()
        {
            _mockDeleteCompanyRepository = new Mock<IDeleteCompanyRepository>();
            _deleteCompany = new DeleteCompany(_mockDeleteCompanyRepository.Object);
        }

        //Given: companyId as 1
        //When: I call Delete
        //Then: Method IDeleteCompanyRepository.Delete executes
        [TestMethod]
        public void Test_Delete()
        {
            int companyId = 1;
            _mockDeleteCompanyRepository.Setup(x=>x.Delete(It.IsAny<int>()));
            _deleteCompany.Delete(companyId);
            _mockDeleteCompanyRepository.Verify(x => x.Delete(It.IsAny<int>()), Times.Once());
        }
    }
}
