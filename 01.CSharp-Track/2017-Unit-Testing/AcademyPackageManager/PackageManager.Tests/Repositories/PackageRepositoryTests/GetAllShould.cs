namespace PackageManager.Tests.Repositories.PackageRepositoryTests
{
    using Info.Contracts;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using PackageManager.Models.Contracts;
    using PackageManager.Repositories;
    using System.Collections.Generic;
    using System.Linq;
    using Telerik.JustMock;

    [TestClass]
    public class GetAllShould
    {
        [TestMethod]
        public void ReturnEmptyCollectionWhenThereAreNoPackages()
        {
            //Arrange
            var packagesMock = Mock.Create<List<IPackage>>();
            var loggerMock = Mock.Create<ILogger>();

            var sut = new PackageRepository(loggerMock);

            //Act
            var result = sut.GetAll();

            //Assert
            Assert.AreEqual(0, result.Count());
        }
    }
}
