namespace PackageManager.Tests.Models.PackageVersionTests
{
    using Enums;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using PackageManager.Models;
    using System;

    [TestClass]
    public class PackageVersionPropertiesShould
    {
        [TestMethod]
        public void ThrowArgumentExceptionWhenPassedNegativeValueToMinorProperty()
        {
            //Arrange
            var sut = new PackageVersion(1, 2, 3, VersionType.alpha);

            //Act & Assert
            Assert.ThrowsException<ArgumentException>(() => new PackageVersion(-1, 2, 3, VersionType.alpha));
        }

        [TestMethod]
        public void ThrowArgumentExceptionWhenPassedNegativeValueToMajorProperty()
        {
            //Arrange
            var sut = new PackageVersion(1, 2, 3, VersionType.alpha);

            //Act & Assert
            Assert.ThrowsException<ArgumentException>(() => new PackageVersion(1, -2, 3, VersionType.alpha));
        }

        [TestMethod]
        public void ThrowArgumentExceptionWhenPassedNegativeValueToPachProperty()
        {
            //Arrange
            var sut = new PackageVersion(1, 2, 3, VersionType.alpha);

            //Act & Assert
            Assert.ThrowsException<ArgumentException>(() => new PackageVersion(1, 2, -3, VersionType.alpha));
        }

        [TestMethod]
        public void ThrowArgumentExceptionWhenPassedInvalidValueToTypeProperty()
        {
            //Arrange
            var sut = new PackageVersion(1, 2, 3, VersionType.alpha);

            //Act & Assert
            Assert.ThrowsException<ArgumentException>(() => new PackageVersion(1, 2, 3, (VersionType)5));
        }

        [TestMethod]
        public void AssignMajorPropertyIFPassedValueIsCorrect()
        {
            //Arrange
            var sut = new PackageVersion(1, 2, 3, VersionType.alpha);

            //Act
            var result = sut.Major;

            //Assert
            Assert.AreEqual(1, sut.Major);
        }

        [TestMethod]
        public void AssignMinorPropertyIFPassedValueIsCorrect()
        {
            //Arrange
            var sut = new PackageVersion(1, 2, 3, VersionType.alpha);

            //Act
            var result = sut.Minor;

            //Assert
            Assert.AreEqual(2, sut.Minor);
        }

        [TestMethod]
        public void AssignPatchPropertyIFPassedValueIsCorrect()
        {
            //Arrange
            var sut = new PackageVersion(1, 2, 3, VersionType.alpha);

            //Act
            var result = sut.Patch;

            //Assert
            Assert.AreEqual(3, sut.Patch);
        }

        [TestMethod]
        public void AssignTypePropertyIfPassedValueIsCorrect()
        {
            //Arrange
            var sut = new PackageVersion(1, 2, 3, VersionType.alpha);

            //Act & Assert
            Assert.IsTrue(Enum.IsDefined(typeof(VersionType), (VersionType)2));
        }
    }
}
