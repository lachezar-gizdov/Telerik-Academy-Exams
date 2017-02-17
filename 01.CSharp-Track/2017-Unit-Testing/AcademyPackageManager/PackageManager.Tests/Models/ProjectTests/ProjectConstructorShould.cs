namespace PackageManager.Tests.Models.ProjectTests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using PackageManager.Models;
    using PackageManager.Models.Contracts;
    using PackageManager.Repositories.Contracts;
    using System;
    using Telerik.JustMock;

    [TestClass]
    public class ProjectConstructorShould
    {
        [TestMethod]
        public void SetCorrectlyOptionalParameterPackages()
        {
            //Arrange
            var packagesMock = Mock.Create<IRepository<IPackage>>();
            var sut = new Project("name", "location", packagesMock);

            //Act & Assert
            Assert.IsNotNull(sut.PackageRepository);
        }

        [TestMethod]
        public void ThrowArgumentNullExceptionWhenPassedNameIsNull()
        {
            //Arrange
            var packagesMock = Mock.Create<IRepository<IPackage>>();

            //Act & Assert
            Assert.ThrowsException<ArgumentNullException>(() => new Project(null, "location", packagesMock));
        }

        [TestMethod]
        public void ThrowArgumentNullExceptionWhenPassedLocationIsNull()
        {
            //Arrange
            var packagesMock = Mock.Create<IRepository<IPackage>>();

            //Act & Assert
            Assert.ThrowsException<ArgumentNullException>(() => new Project("name", null, packagesMock));
        }
    }
}
