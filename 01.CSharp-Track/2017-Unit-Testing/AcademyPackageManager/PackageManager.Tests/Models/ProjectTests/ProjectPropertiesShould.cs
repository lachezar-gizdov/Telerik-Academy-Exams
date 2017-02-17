namespace PackageManager.Tests.Models.ProjectTests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Mocks;
    using PackageManager.Models.Contracts;
    using PackageManager.Repositories.Contracts;
    using Telerik.JustMock;

    [TestClass]
    public class ProjectPropertiesShould
    {
        [TestMethod]
        public void SetNamePropertyCorrectly()
        {
            //Arrange
            var packagesMock = Mock.Create<IRepository<IPackage>>();
            var sut = new ProjectFake("name", "location", packagesMock);

            //Act
            var result = sut.Name;

            //Assert
            Assert.AreEqual("name", result);
        }

        [TestMethod]
        public void SetLocationPropertyCorrectly()
        {
            //Arrange
            var packagesMock = Mock.Create<IRepository<IPackage>>();
            var sut = new ProjectFake("name", "location", packagesMock);

            //Act
            var result = sut.Location;

            //Assert
            Assert.AreEqual("location", result);
        }
    }
}
