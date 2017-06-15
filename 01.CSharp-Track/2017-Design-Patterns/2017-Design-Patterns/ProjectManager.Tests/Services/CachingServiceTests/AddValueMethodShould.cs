using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProjectManager.Framework.Services;
using System;

namespace ProjectManager.Tests.Services.CachingServiceTests
{
    [TestClass]
    public class AddValueMethodShould
    {
        [TestMethod]
        public void AddValueToCache()
        {
            // Arrange
            var timeSpan = TimeSpan.FromSeconds(int.Parse("20"));
            var className = "Project";
            var methodName = "ToString()";
            object obj = new object();

            // Act
            var sut = new CachingService(timeSpan);
            sut.AddCacheValue(className, methodName, obj);

            // Assert
            try
            {
                sut.GetCacheValue(className, methodName);
            }
            catch (Exception ex)
            {

                Assert.Fail("No exception is expected, but got: " + ex);
            }
        }
    }
}
