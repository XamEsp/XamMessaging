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

        [TestMethod]
        public void CanConfirmExecutionOfSomeOperation()
        {
            // Arrange
            var service = new Mock<IConfirmationService>();
            service.Setup(m => m.AskConfirmation(It.IsAny<string>())).ReturnsAsync(true);

            var vm = new ServiceInjectionCallAndReturnViewModel(service.Object);

            var startingNumberOfOperation = vm.Operations.Count;

            // Act
            vm.ExecuteSomeOperationCommand.Execute(null);

            // Assert
            Assert.AreEqual(startingNumberOfOperation + 1, vm.Operations.Count);
        }


        [TestMethod]
        public void CanCancelExecutionOfSomeOperation()
        {
            // Arrange
            var service = new Mock<IConfirmationService>();
            service.Setup(m => m.AskConfirmation(It.IsAny<string>())).ReturnsAsync(false);

            var vm = new ServiceInjectionCallAndReturnViewModel(service.Object);

            var startingNumberOfOperation = vm.Operations.Count;

            // Act
            vm.ExecuteSomeOperationCommand.Execute(null);

            // Assert
            Assert.AreEqual(startingNumberOfOperation, vm.Operations.Count);
        }

    }
}
