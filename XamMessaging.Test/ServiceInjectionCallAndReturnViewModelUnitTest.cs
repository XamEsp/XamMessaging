using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using XamMessaging.Service;
using XamMessaging.ViewModel;

namespace XamMessaging.Test
{
    [TestClass]
    public class ServiceInjectionCallAndReturnViewModelUnitTest
    {
        [TestMethod]
        public void CanCreateViewModelOk()
        {
            // Arrange
            var service = new Mock<IConfirmationService>();

            // Act
            var vm = new ServiceInjectionCallAndReturnViewModel(service.Object);

            // Assert
            Assert.IsNotNull(vm);
        }
    }
}
