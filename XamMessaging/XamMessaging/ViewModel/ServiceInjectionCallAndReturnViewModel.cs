using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Windows.Input;
using Xamarin.Forms;
using XamMessaging.Service;

namespace XamMessaging.ViewModel
{
    public class ServiceInjectionCallAndReturnViewModel
    {

        private readonly IConfirmationService _confirmationService;
        public ICommand ExecuteSomeOperationCommand { get; set; }

        public ServiceInjectionCallAndReturnViewModel()
        {
            ExecuteSomeOperationCommand = new Command(DoSomething);
            _confirmationService = DependencyService.Get<IConfirmationService>();
        }

        public ObservableCollection<string> Operations { get; set; } = new ObservableCollection<string>();

        public async void DoSomething()
        {
            Debug.WriteLine("Handling Call in the ViewModel");
            if (await _confirmationService.AskConfirmation("Would you like to perform the operation?"))
            {
                Operations.Add($"Handling Operation {Operations.Count}");
            }
        }

    }
}
