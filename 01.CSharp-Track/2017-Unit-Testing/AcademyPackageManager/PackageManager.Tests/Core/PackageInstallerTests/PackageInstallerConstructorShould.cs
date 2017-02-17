
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PackageManager.Core;
using PackageManager.Core.Contracts;
using PackageManager.Models.Contracts;
using Telerik.JustMock;

namespace PackageManager.Tests.Core.PackageInstallerTests
{
    [TestClass]
    class PackageInstallerConstructorShould
    {
        [TestMethod]
        public void RestoringPackagaesWhenConstructorIsCalled()
        {
            var downloaderMock = Mock.Create<IDownloader>();
            var projectMock = Mock.Create<IProject>();
            var sut = new PackageInstaller(downloaderMock, projectMock);

            
        }
    }
}
