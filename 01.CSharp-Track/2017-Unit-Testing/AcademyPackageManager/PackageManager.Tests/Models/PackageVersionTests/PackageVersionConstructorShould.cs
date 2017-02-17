using Microsoft.VisualStudio.TestTools.UnitTesting;
using PackageManager.Enums;
using PackageManager.Models;

namespace PackageManager.Tests.Models.PackageVersionTests
{
    [TestClass]
    public class PackageVersionConstructorShould
    {
        [TestMethod]
        public void SetCorrectMajorValueWhenPassedValueIsValid()
        {
            //Arrange
            var sut = new PackageVersion(1, 2, 3, VersionType.final);

            //Act & Assert
            Assert.AreEqual(1, sut.Major);
        }

        [TestMethod]
        public void SetCorrectMinorValueWhenPassedValueIsValid()
        {
            //Arrange
            var sut = new PackageVersion(1, 2, 3, VersionType.final);

            //Act & Assert
            Assert.AreEqual(2, sut.Minor);
        }

        [TestMethod]
        public void SetCorrectPatchValueWhenPassedValueIsValid()
        {
            //Arrange
            var sut = new PackageVersion(1, 2, 3, VersionType.final);

            //Act & Assert
            Assert.AreEqual(3, sut.Patch);
        }

        [TestMethod]
        public void SetCorrectVersionTypeValueWhenPassedValueIsValid()
        {
            //Arrange
            var sut = new PackageVersion(1, 2, 3, VersionType.final);

            //Act & Assert
            Assert.AreEqual(VersionType.final, sut.VersionType);
        }
    }
}