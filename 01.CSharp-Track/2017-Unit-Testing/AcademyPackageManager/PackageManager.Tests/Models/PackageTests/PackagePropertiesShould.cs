namespace PackageManager.Tests.Models.PackageTests
{
    using Enums;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using PackageManager.Models;
    using PackageManager.Models.Contracts;
    using System.Collections.Generic;
    using Telerik.JustMock;

    [TestClass]
    public class PackagePropertiesShould
    {
        [TestMethod]
        public void SetNamePropertyCorrectlyWhenPassedValueIsValid()
        {
            //Arrange
            var versionMock = Mock.Create<IVersion>();
            var packagesMock = Mock.Create<List<IPackage>>();
            var sut = new Package("name", versionMock, packagesMock);

            //Act
            var result = sut.Name;

            //Assert
            Assert.AreEqual("name", result);
        }

        [TestMethod]
        public void SetVersionPropertyCorrectlyWhenPassedValueIsValid()
        {
            //Arrange
            var versionMock = Mock.Create<IVersion>();
            Mock.Arrange(() => versionMock.Major).Returns(4);
            Mock.Arrange(() => versionMock.Minor).Returns(5);
            Mock.Arrange(() => versionMock.Patch).Returns(6);
            Mock.Arrange(() => versionMock.VersionType).Returns(VersionType.beta);


            var packagesMock = Mock.Create<List<IPackage>>();
            var sut = new Package("name", versionMock, packagesMock);

            //Assert
            Assert.AreEqual(4, sut.Version.Major);
            Assert.AreEqual(5, sut.Version.Minor);
            Assert.AreEqual(6, sut.Version.Patch);
            Assert.AreEqual(VersionType.beta, sut.Version.VersionType);
        }
        [TestMethod]
        public void SetUrlPropertyCorrectlyWhenPassedValuesAreValid()
        {
            //Arrange
            var versionMock = Mock.Create<IVersion>();
            Mock.Arrange(() => versionMock.Major).Returns(4);
            Mock.Arrange(() => versionMock.Minor).Returns(5);
            Mock.Arrange(() => versionMock.Patch).Returns(6);
            Mock.Arrange(() => versionMock.VersionType).Returns(VersionType.beta);


            var packagesMock = Mock.Create<List<IPackage>>();
            var sut = new Package("name", versionMock, packagesMock);

            //Assert
            Assert.AreEqual("4.5.6-beta", sut.Url);
        }
    }
}
