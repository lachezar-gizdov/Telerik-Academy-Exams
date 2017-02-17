namespace PackageManager.Tests.Commands.InstallCommandTests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using PackageManager.Commands;
    using PackageManager.Core.Contracts;
    using PackageManager.Models.Contracts;
    using System;
    using Telerik.JustMock;

    [TestClass]
    public class InstallCommandConstructorShould
    {
        [TestMethod]
        public void TrowArgumentNullExceptionWhenPassedInstallerIsNull()
        {
            //Arrange
            var packageMock = Mock.Create<IPackage>();

            //Act & Assert
            Assert.ThrowsException<ArgumentNullException>(() => new InstallCommand(null, packageMock));
        }

        //[TestMethod] //TODO FIX
        //public void TrowArgumentNullExceptionWhenPassedPackageIsNull()
        //{
        //    //Arrange
        //    var installerMock = Mock.Create<IInstaller<IPackage>>();

        //    //Act & Assert
        //    Assert.ThrowsException<ArgumentNullException>(() => new InstallCommand(installerMock, null));
        //}
    }
}
