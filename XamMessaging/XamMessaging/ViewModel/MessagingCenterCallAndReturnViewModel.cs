using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Windows.Input;
using Xamarin.Forms;

namespace XamMessaging.ViewModel
{
    public class MessagingCenterCallAndReturnViewModel
    {

        public ICommand ExecuteSomeOperationCommand { get; set; }

        public MessagingCenterCallAndReturnViewModel()
        {
            ExecuteSomeOperationCommand = new Command(CallView);
        }

        public void CallView()
        {
            Debug.WriteLine("Sending Message to the View");
            Device.BeginInvokeOnMainThread(() =>
            {
                MessagingCenter.Send(this, "CallViewFromViewModel");
            });
        }

        public ObservableCollection<string> Operations { get; set; } = new ObservableCollection<string>();

        public void DoSomething()
        {
            Operations.Add($"Handling Operation {Operations.Count}");
        }

    }
}
