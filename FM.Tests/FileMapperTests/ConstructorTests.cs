using System;

using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using MSTestExtensions;

using FM.Common.Contracts;
using FM.Mapper;

namespace FM.Tests.FileMapperTests
{
    [TestClass]
    public class ConstructorTests
    {
        [TestMethod]
        public void ShouldThrowNullArgument_WhenNoFileManagerIsSupplied()
        {
            // Arrange
            var mockedLogger = new Mock<ILogger>();

            // Act and assert
            ThrowsAssert.Throws<ArgumentNullException>(() => new FileMapper(null, mockedLogger.Object));
        }
    }
}
