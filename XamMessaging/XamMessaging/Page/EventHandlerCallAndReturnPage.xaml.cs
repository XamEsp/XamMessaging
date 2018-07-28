using System.Diagnostics;
using System.Threading.Tasks;
using Acr.UserDialogs;
using Xamarin.Forms.Xaml;
using XamMessaging.ViewModel;

namespace XamMessaging.Page
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EventHandlerCallAndReturnPage
    {
        private EventHandlerCallAndReturnViewModel Vm => BindingContext as EventHandlerCallAndReturnViewModel;

        public EventHandlerCallAndReturnPage()
        {
            InitializeComponent();

            Vm.AskForConfirmation = async()=>
            {
                await HandleConfirmation();
            };
        }

        public async Task HandleConfirmation()
        {
            Debug.WriteLine("Handling Call from ViewModel");
            var config = new ConfirmConfig()
            {
                Title = "Confirmation",
                Message = "Would you like to perform the operation?",
                OkText = "Yes",
                CancelText = "No",
            };
            if (await UserDialogs.Instance.ConfirmAsync(config))
            {
                Vm.DoSomething();
            }
        }
    }
}
