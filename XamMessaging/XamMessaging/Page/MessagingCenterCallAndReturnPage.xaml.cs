using System.Diagnostics;
using Acr.UserDialogs;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamMessaging.ViewModel;

// https://docs.microsoft.com/en-us/dotnet/api/Xamarin.Forms.MessagingCenter?view=xamarin-forms
namespace XamMessaging.Page
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MessagingCenterCallAndReturnPage
    {
        private MessagingCenterCallAndReturnViewModel Vm => BindingContext as MessagingCenterCallAndReturnViewModel;

        public MessagingCenterCallAndReturnPage()
        {
            InitializeComponent();
        }

        public async void HandleConfirmation(MessagingCenterCallAndReturnViewModel sender)
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

        protected override void OnAppearing()
        {
            base.OnAppearing();

            MessagingCenter.Subscribe<MessagingCenterCallAndReturnViewModel>(this, "CallViewFromViewModel", HandleConfirmation);
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();

            MessagingCenter.Unsubscribe<MessagingCenterCallAndReturnViewModel>(this, "CallViewFromViewModel");
        }
    }
}
