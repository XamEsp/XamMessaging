using Microsoft.VisualStudio.TestTools.UnitTesting;
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
            var service = new ConfirmationService();    // TODO: create and use a mock with moq

            // Act
            var vm = new ServiceInjectionCallAndReturnViewModel(service);

            // Assert
            Assert.IsNotNull(vm);
        }
    }
}
