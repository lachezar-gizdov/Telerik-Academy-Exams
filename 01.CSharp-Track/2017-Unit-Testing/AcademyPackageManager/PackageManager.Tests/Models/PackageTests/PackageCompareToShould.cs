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
    public class PackageCompareToShould
    {
        [TestMethod]
        public void ThrowArgumentNullExceptionWhenPassedValueIsNull()
        {
            //Arrange
            var versionMock = Mock.Create<IVersion>();
            var packagesMock = Mock.Create<List<IPackage>>();
            var sut = new Package("name", versionMock, packagesMock);

            //Act & Assert
            Assert.ThrowsException<ArgumentNullException>(() => sut.CompareTo(null));
        }

        [TestMethod]
        public void ReturnZeroWhenTheTwoPakacgesAreTheSame()
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

            //Act
            var result = sut.CompareTo(otherMock);

            //Assert
            Assert.AreEqual(0, result);
        }

        [TestMethod]
        public void ReturnOneWhenTheFirstPakacgeVersionIsHigher()
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
           
            //Act
            var result = sut.CompareTo(otherMock);

            //Assert
            Assert.AreEqual(1, result);
        }

        [TestMethod]
        public void ReturnMinusOneWhenTheSecondPakacgeVersionIsHigher()
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
            Mock.Arrange(() => otherMock.Version.Major).Returns(2);
            Mock.Arrange(() => otherMock.Version.Minor).Returns(2);
            Mock.Arrange(() => otherMock.Version.Patch).Returns(3);
            Mock.Arrange(() => otherMock.Version.VersionType).Returns(VersionType.final);

            //Act
            var result = sut.CompareTo(otherMock);

            //Assert
            Assert.AreEqual(-1, result);
        }

        [TestMethod]
        public void ThrowArgumentExceptionWhenTheNamesAreDifferent()
        {
            //Arrange
            var versionMock = Mock.Create<IVersion>();
            Mock.Arrange(() => versionMock.Major).Returns(1);
            Mock.Arrange(() => versionMock.Minor).Returns(2);
            Mock.Arrange(() => versionMock.Patch).Returns(3);
            Mock.Arrange(() => versionMock.VersionType).Returns(VersionType.final);
            var packagesMock = Mock.Create<List<IPackage>>();
            var sut = new Package("paket1", versionMock, packagesMock);

            var otherMock = Mock.Create<IPackage>();
            Mock.Arrange(() => otherMock.Name).Returns("paket");
            Mock.Arrange(() => otherMock.Version.Major).Returns(2);
            Mock.Arrange(() => otherMock.Version.Minor).Returns(2);
            Mock.Arrange(() => otherMock.Version.Patch).Returns(3);
            Mock.Arrange(() => otherMock.Version.VersionType).Returns(VersionType.final);

            //Assert
            Assert.ThrowsException<ArgumentException>(() => sut.CompareTo(otherMock));
        }
    }
}
