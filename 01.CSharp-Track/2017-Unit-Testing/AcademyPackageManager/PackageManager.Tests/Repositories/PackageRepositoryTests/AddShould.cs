using Microsoft.VisualStudio.TestTools.UnitTesting;
using PackageManager.Enums;
using PackageManager.Info.Contracts;
using PackageManager.Models.Contracts;
using PackageManager.Repositories;
using System;
using System.Collections.Generic;
using Telerik.JustMock;

namespace PackageManager.Tests.Repositories.PackageRepositoryTests
{
    [TestClass]
    public class AddShould
    {
        [TestMethod]
        public void ThrowArgumentNullExceptionWhenPassedLoggerIsNull()
        {
            //Arrange
            var packagesMock = Mock.Create<List<IPackage>>();

            //Act & Assert
            Assert.ThrowsException<ArgumentNullException>(() => new PackageRepository(null, packagesMock));
        }

        [TestMethod]
        public void ThrowArgumentNullExceptionWhenPassedPackageIsNull()
        {
            //Arrange
            var packagesMock = Mock.Create<List<IPackage>>();
            var loggerMock = Mock.Create<ILogger>();
            var sut = new PackageRepository(loggerMock, packagesMock);

            //Act & Assert
            Assert.ThrowsException<ArgumentNullException>(() => sut.Add(null));
        }

        [TestMethod]
        public void AddPackageIfItsNotAddedAlready()
        {
            //Arrange
            var packagesMock = Mock.Create<List<IPackage>>();
            var loggerMock = Mock.Create<ILogger>();

            var sut = new PackageRepository(loggerMock, packagesMock);

            var packageMock = Mock.Create<IPackage>();
            Mock.Arrange(() => packageMock.Name).Returns("TestPackage");

            //Act

            //Assert
            //Should Check If .Log Method Is Called
        }

        [TestMethod]
        public void ReturnMessangeThatHigherVersionPackageAlreadyExistIfTryingToInstallLower()
        {
            //Arrange
            var packagesMock = Mock.Create<List<IPackage>>();
            
            var loggerMock = Mock.Create<ILogger>();

            var packageAlreadyAddedMock = Mock.Create<IPackage>();
            Mock.Arrange(() => packageAlreadyAddedMock.Name).Returns("TestPackage");
            Mock.Arrange(() => packageAlreadyAddedMock.Version.Major).Returns(3);
            Mock.Arrange(() => packageAlreadyAddedMock.Version.Minor).Returns(3);
            Mock.Arrange(() => packageAlreadyAddedMock.Version.Patch).Returns(3);
            Mock.Arrange(() => packageAlreadyAddedMock.Version.VersionType).Returns(VersionType.final);

            var packages = new List<IPackage>() { packageAlreadyAddedMock };

            var packageToAddMock = Mock.Create<IPackage>();
            Mock.Arrange(() => packageToAddMock.Name).Returns("TestPackage");
            Mock.Arrange(() => packageToAddMock.Version.Major).Returns(1);
            Mock.Arrange(() => packageToAddMock.Version.Minor).Returns(1);
            Mock.Arrange(() => packageToAddMock.Version.Patch).Returns(1);
            Mock.Arrange(() => packageToAddMock.Version.VersionType).Returns(VersionType.final);

            var sut = new PackageRepository(loggerMock, packages);

            sut.Add(packageToAddMock);

            //Should Check If .Log Method Is Called

            //Act & Assert
            //Mock.Assert(() => )
        }
    }
}