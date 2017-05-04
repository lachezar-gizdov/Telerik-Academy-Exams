using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProjectManager.Common.Contracts;
using ProjectManager.Core;
using ProjectManager.Core.Contracts;
using Telerik.JustMock;

namespace ProjectManagerTests.Core.Commands
{
    [TestClass]
    public class CreateTaskCommandShould
    {
        [TestMethod]
        public void ThrowWhenParametersCountIsInvalid()
        {
            // Assign
            var loggerMock = Mock.Create<ILogger>();
            var parserMock = Mock.Create<IParser>();
            var readerMock = Mock.Create<IReader>();
            var writerMock = Mock.Create<IWriter>();
            var sut = new Engine(loggerMock, parserMock, readerMock, writerMock);

            //Act
            sut.Start();
        }
    }
}
