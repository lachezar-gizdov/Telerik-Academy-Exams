namespace PackageManager.Tests.Models.PackageTests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using PackageManager.Models;
    using PackageManager.Models.Contracts;
    using System;
    using System.Collections.Generic;
    using Telerik.JustMock;

    [TestClass]
    public class PackageConstructorShould
    {
        [TestMethod]
        public void ThrowArgumentNullExceptionWhenPassedNameIsNull()
        {
            //Arrange
            var versionMock = Mock.Create<IVersion>();
            var packagesMock = Mock.Create<List<IPackage>>();

            //Act & Assert
            Assert.ThrowsException<ArgumentNullException>(() => new Package(null, versionMock, packagesMock));
        }
        [TestMethod]
        public void ThrowArgumentNullExceptionWhenPassedVersionIsNull()
        {
            //Arrange
            var packagesMock = Mock.Create<List<IPackage>>();

            //Act & Assert
            Assert.ThrowsException<ArgumentNullException>(() => new Package("name", null, packagesMock));
        }

        [TestMethod]
        public void SetNameProprtyCorrectlyWhenPassedValueIsValid()
        {
            //Arrange
            var versionMock = Mock.Create<IVersion>();
            var packagesMock = Mock.Create<List<IPackage>>();
            var sut = new Package("name", versionMock, packagesMock);

            //Act & Assert
            Assert.AreEqual("name", sut.Name);
        }

        [TestMethod]
        public void SetVersionProprtyCorrectlyWhenPassedValueIsValid()
        {
            //Arrange
            var versionMock = Mock.Create<IVersion>();
            var packagesMock = Mock.Create<List<IPackage>>();
            var sut = new Package("name", versionMock, packagesMock);

            //Act & Assert
            Assert.IsNotNull(sut.Version);
        }

        [TestMethod]
        public void SetUrlProprtyCorrectlyWhenPassedValueIsValid()
        {
            //Arrange
            var versionMock = Mock.Create<IVersion>();
            var packagesMock = Mock.Create<List<IPackage>>();
            var sut = new Package("name", versionMock, packagesMock);

            //Act & Assert
            Assert.IsNotNull(sut.Url);
        }
    }
}
