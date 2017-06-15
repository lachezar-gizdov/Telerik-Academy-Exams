using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProjectManager.Framework.Services;
using System;

namespace ProjectManager.Tests.Services.CachingServiceTests
{
    [TestClass]
    public class ConstructorShould
    {
        [TestMethod]
        public void ThrowWhenDurationArgumentIsLessThanZero()
        {
            // Arrange
            TimeSpan span = TimeSpan.FromSeconds(int.Parse("-5"));

            //Act & Assert
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => new CachingService(span));
        }

        [TestMethod]
        public void NotThrowWhenDurationArgumentIsMoreThanZero()
        {
            // Arrange
            TimeSpan span = TimeSpan.FromSeconds(int.Parse("1"));

            //Act & Assert
            try
            {
                var sut = new CachingService(span);
            }
            catch (Exception ex)
            {

                Assert.Fail("No exception is expected, but got: " + ex);
            }
        }
    }
}