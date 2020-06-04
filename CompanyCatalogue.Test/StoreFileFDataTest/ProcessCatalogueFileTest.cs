using CompanyCatalogue.Business;
using CompanyCatalogue.Interfaces;
using CompanyCatalogue.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace CompanyCatalogue.Test
{
    [TestClass]
    public class ProcessCatalogueFileTest
    {
        private IProcessCatalogueFile _processCatalogueFile;
        private Mock<IConstructFileStoragePath> _mockConstructFileStoragePath;
        private Mock<ISaveFile> _mockSaveFile;
        private Mock<IFileParser> _mockFileParser;
        private Mock<ICompanyCatalogueCollection> _mockCompanyCatalogueCollection;
        private Mock<ICatalogueUOW> _mockCatalogueUOW;
        private Mock<IDeleteFile> _mockDeleteFile;
        [TestInitialize]
        public void Setup()
        {
            _mockConstructFileStoragePath = new Mock<IConstructFileStoragePath>();
            _mockSaveFile = new Mock<ISaveFile>();
            _mockFileParser = new Mock<IFileParser>();
            _mockCompanyCatalogueCollection = new Mock<ICompanyCatalogueCollection>();
            _mockCatalogueUOW = new Mock<ICatalogueUOW>();
            _mockDeleteFile = new Mock<IDeleteFile>();
            _processCatalogueFile = new ProcessCatalogueFile(_mockConstructFileStoragePath.Object,
                                    _mockSaveFile.Object, _mockFileParser.Object,
                                    _mockCompanyCatalogueCollection.Object,
                                    _mockCatalogueUOW.Object, _mockDeleteFile.Object);
        }

        //Given: A an excel file
        //WHen: I call Process
        //Then: I get a string in return
        [TestMethod]
        public void Given_A_Excel_File_Then_Get_A_String()
        {
            var mockFile = new Mock<IFormFile>();

            _mockConstructFileStoragePath.Setup(x => x.GetPath(It.IsAny<string>())).Returns("d:/123-qwe.elsx");
            _mockSaveFile.Setup(x => x.Save(It.IsAny<IFormFile>(), It.IsAny<string>()));
            _mockFileParser.Setup(x=>x.Parse(It.IsAny<string>())).Returns(new DataTable());
            _mockCompanyCatalogueCollection.Setup(x => x.GetCollection(It.IsAny<DataTable>()))
                                            .Returns(new List<CompanyDetailModel>());
            _mockCatalogueUOW
            .Setup(x => x.Create(It.IsAny<List<CompanyDetailModel>>(), It.IsAny<string>(), It.IsAny<string>()));
            _mockDeleteFile.Setup(x=>x.Delete(It.IsAny<string>()));

            var result = _processCatalogueFile.Process(mockFile.Object);

            Assert.IsTrue(result is Task<string>);
        }

        //Given: A an excel file
        //WHen: I call Process
        //Then: all the called methods executes
        [TestMethod]
        public void Process_Test_1()
        {
            var mockFile = new Mock<IFormFile>();

            _mockConstructFileStoragePath.Setup(x => x.GetPath(It.IsAny<string>())).Returns("d:/123-qwe.elsx");
            _mockSaveFile.Setup(x => x.Save(It.IsAny<IFormFile>(), It.IsAny<string>()));
            _mockFileParser.Setup(x => x.Parse(It.IsAny<string>())).Returns(new DataTable());
            _mockCompanyCatalogueCollection.Setup(x => x.GetCollection(It.IsAny<DataTable>()))
                                            .Returns(new List<CompanyDetailModel>());
            _mockCatalogueUOW
            .Setup(x => x.Create(It.IsAny<List<CompanyDetailModel>>(), It.IsAny<string>(), It.IsAny<string>()));
            _mockDeleteFile.Setup(x => x.Delete(It.IsAny<string>()));

            var result = _processCatalogueFile.Process(mockFile.Object);

            _mockConstructFileStoragePath.Verify(x => x.GetPath(It.IsAny<string>()), Times.Once());
            _mockSaveFile.Verify(x => x.Save(It.IsAny<IFormFile>(), It.IsAny<string>()), Times.Once());
            _mockFileParser.Verify(x => x.Parse(It.IsAny<string>()), Times.Once());
            _mockCompanyCatalogueCollection.Verify(x => x.GetCollection(It.IsAny<DataTable>()), Times.Once());
            _mockCatalogueUOW
            .Verify(x => x.Create(It.IsAny<List<CompanyDetailModel>>(), It.IsAny<string>(), It.IsAny<string>()), Times.Once());
            _mockDeleteFile.Verify(x => x.Delete(It.IsAny<string>()), Times.Once());
        }

        //Given: A an excel file
        //WHen: I call Process
        //Then: none the called methods executes
        [TestMethod]
        public void Process_Test_2()
        {
            IFormFile file = null;

            _mockConstructFileStoragePath.Setup(x => x.GetPath(It.IsAny<string>())).Returns("d:/123-qwe.elsx");
            _mockSaveFile.Setup(x => x.Save(It.IsAny<IFormFile>(), It.IsAny<string>()));
            _mockFileParser.Setup(x => x.Parse(It.IsAny<string>())).Returns(new DataTable());
            _mockCompanyCatalogueCollection.Setup(x => x.GetCollection(It.IsAny<DataTable>()))
                                            .Returns(new List<CompanyDetailModel>());
            _mockCatalogueUOW
            .Setup(x => x.Create(It.IsAny<List<CompanyDetailModel>>(), It.IsAny<string>(), It.IsAny<string>()));
            _mockDeleteFile.Setup(x => x.Delete(It.IsAny<string>()));

            var result = _processCatalogueFile.Process(file);

            _mockConstructFileStoragePath.Verify(x => x.GetPath(It.IsAny<string>()), Times.Never());
            _mockSaveFile.Verify(x => x.Save(It.IsAny<IFormFile>(), It.IsAny<string>()), Times.Never());
            _mockFileParser.Verify(x => x.Parse(It.IsAny<string>()), Times.Never());
            _mockCompanyCatalogueCollection.Verify(x => x.GetCollection(It.IsAny<DataTable>()), Times.Never());
            _mockCatalogueUOW
            .Verify(x => x.Create(It.IsAny<List<CompanyDetailModel>>(), It.IsAny<string>(), It.IsAny<string>()), Times.Never());
            _mockDeleteFile.Verify(x => x.Delete(It.IsAny<string>()), Times.Never());
        }
    }
}
