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

        [TestMethod]
        public void ShouldThrowNullArgumentWithSpecificMessage_WhenNoFileManagerIsSupplied()
        {
            // Arrange
            var mockedLogger = new Mock<ILogger>();

            // Act
            var exceptionThrown = ThrowsAssert
                .Throws<ArgumentNullException>(() => new FileMapper(null, mockedLogger.Object));

            // Assert
            StringAssert.Contains(exceptionThrown.Message.ToLower(), "filemanager is null".ToLower());
        }

        [TestMethod]
        public void ShouldThrowNullArgument_WhenNoLoggerIsSupplied()
        {
            // Arrange
            var mockedManger = new Mock<IFileManager>();

            // Act and assert
            ThrowsAssert.Throws<ArgumentNullException>(() => new FileMapper(mockedManger.Object, null));
        }
    }
}
