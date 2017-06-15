using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProjectManager.Framework.Services;
using System;
using System.Collections.Generic;

namespace ProjectManager.Tests.Services.CachingServiceTests
{
    [TestClass]
    public class ResetCacheMethodShould
    {
        [TestMethod]
        public void EmptyCache()
        {
            // Arrange
            var timeSpan = TimeSpan.FromSeconds(int.Parse("20"));
            var className = "Project";
            var methodName = "ToString()";
            object obj = new object();

            // Act
            var sut = new CachingService(timeSpan);
            sut.AddCacheValue(className, methodName, obj);
            sut.ResetCache();

            // Assert

            Assert.ThrowsException<KeyNotFoundException>(() => sut.GetCacheValue(className, methodName));
        }
    }
}
