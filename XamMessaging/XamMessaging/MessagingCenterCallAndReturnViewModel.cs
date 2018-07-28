using System.Diagnostics;
using System.Windows.Input;
using Xamarin.Forms;

namespace XamMessaging
{
    public class MessagingCenterCallAndReturnViewModel
    {

        public ICommand CallViewCommand { get; set; }

        public MessagingCenterCallAndReturnViewModel()
        {
            CallViewCommand = new Command(CallView);
        }

        public void CallView()
        {
            Debug.WriteLine("Sending Message to the View");
            Device.BeginInvokeOnMainThread(() =>
            {
                MessagingCenter.Send(this, "CallViewFromViewModel");
            });
        }

    }
}
