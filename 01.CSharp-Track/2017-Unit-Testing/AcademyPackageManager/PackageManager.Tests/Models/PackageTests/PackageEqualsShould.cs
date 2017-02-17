namespace PackageManager.Tests.Models.PackageTests
{
    using Enums;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using PackageManager.Models;
    using PackageManager.Models.Contracts;
    using System;
    using System.Collections.Generic;
    using Telerik.JustMock;

    [TestClass]
    public class PackageEqualsShould
    {
        [TestMethod]
        public void ThrowArgumentNullExceptionWhenPassedValueIsNull()
        {
            //Arrange
            var versionMock = Mock.Create<IVersion>();
            var packagesMock = Mock.Create<List<IPackage>>();
            var sut = new Package("name", versionMock, packagesMock);

            //Act & Assert
            Assert.ThrowsException<ArgumentNullException>(() => sut.Equals(null));
        }

        [TestMethod]
        public void TestIfPassedObjectIsIPackage()
        {
            //Arrange
            var versionMock = Mock.Create<IVersion>();
            var packagesMock = Mock.Create<List<IPackage>>();
            var sut = new Package("name", versionMock, packagesMock);
            var otherMock = Mock.Create<IPackage>();

            //Act & Assert
            Assert.IsInstanceOfType(otherMock, typeof(IPackage));
        }

        [TestMethod]
        public void ThrowArgumentExceptionIfPassedObjectIsNotIPackage()
        {
            //Arrange
            var versionMock = Mock.Create<IVersion>();
            var packagesMock = Mock.Create<List<IPackage>>();
            var sut = new Package("name", versionMock, packagesMock);
            var otherMock = Mock.Create<IProject>();

            //Act & Assert
            Assert.ThrowsException<ArgumentException>(() => sut.Equals(otherMock));
        }

        [TestMethod]
        public void ReturnTrueIfPassedPackageIsEqual()
        {
            //Arrange
            var versionMock = Mock.Create<IVersion>();
            Mock.Arrange(() => versionMock.Major).Returns(1);
            Mock.Arrange(() => versionMock.Minor).Returns(2);
            Mock.Arrange(() => versionMock.Patch).Returns(3);
            Mock.Arrange(() => versionMock.VersionType).Returns(VersionType.final);
            var packagesMock = Mock.Create<List<IPackage>>();
            var sut = new Package("paket", versionMock, packagesMock);

            var otherMock = Mock.Create<IPackage>();
            Mock.Arrange(() => otherMock.Name).Returns("paket");
            Mock.Arrange(() => otherMock.Version.Major).Returns(1);
            Mock.Arrange(() => otherMock.Version.Minor).Returns(2);
            Mock.Arrange(() => otherMock.Version.Patch).Returns(3);
            Mock.Arrange(() => otherMock.Version.VersionType).Returns(VersionType.final);

            //Act & Arrange
            Assert.IsTrue(sut.Equals(otherMock));
        }

        [TestMethod]
        public void ReturnFalseIfPassedPackageIsNotEqual()
        {
            //Arrange
            var versionMock = Mock.Create<IVersion>();
            Mock.Arrange(() => versionMock.Major).Returns(2);
            Mock.Arrange(() => versionMock.Minor).Returns(2);
            Mock.Arrange(() => versionMock.Patch).Returns(3);
            Mock.Arrange(() => versionMock.VersionType).Returns(VersionType.final);
            var packagesMock = Mock.Create<List<IPackage>>();
            var sut = new Package("paket", versionMock, packagesMock);

            var otherMock = Mock.Create<IPackage>();
            Mock.Arrange(() => otherMock.Name).Returns("paket");
            Mock.Arrange(() => otherMock.Version.Major).Returns(1);
            Mock.Arrange(() => otherMock.Version.Minor).Returns(2);
            Mock.Arrange(() => otherMock.Version.Patch).Returns(3);
            Mock.Arrange(() => otherMock.Version.VersionType).Returns(VersionType.final);

            //Act & Arrange
            Assert.IsFalse(sut.Equals(otherMock));
        }
    }
}
