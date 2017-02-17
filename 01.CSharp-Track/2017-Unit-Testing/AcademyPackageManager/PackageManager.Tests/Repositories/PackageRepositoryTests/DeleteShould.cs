namespace PackageManager.Tests.Repositories.PackageRepositoryTests
{
    using Info.Contracts;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using PackageManager.Models.Contracts;
    using PackageManager.Repositories;
    using System;
    using System.Collections.Generic;
    using Telerik.JustMock;

    [TestClass]
    public class DeleteShould
    {
        [TestMethod]
        public void ThrowArgumentNullExceptionWhenPassedPackageIsNull()
        {
            //Arrange
            var packagesMock = Mock.Create<List<IPackage>>();
            var logerMock = Mock.Create<ILogger>();
            var sut = new PackageRepository(logerMock, packagesMock);

            //Act & Assert
            Assert.ThrowsException<ArgumentNullException>(() => sut.Delete(null));
        }

        [TestMethod]
        public void ThrowArgumentNullExceptionWhenPassedPackageIsNotFound()
        {
            //Arrange
            var packagesMock = Mock.Create<List<IPackage>>();
            var logerMock = Mock.Create<ILogger>();
            var sut = new PackageRepository(logerMock, packagesMock);
            var packageMock = Mock.Create<IPackage>();

            //Act & Assert
            Assert.ThrowsException<ArgumentNullException>(() => sut.Delete(packageMock));
        }
    }
}
