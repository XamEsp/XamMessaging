using System.Diagnostics;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

// https://docs.microsoft.com/en-us/dotnet/api/Xamarin.Forms.MessagingCenter?view=xamarin-forms
namespace XamMessaging
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MessagingCenterCallAndReturnPage
    {
        public MessagingCenterCallAndReturnPage()
        {
            InitializeComponent();

            ReportStackLayout.Children.Clear();
        }

        public void HandleCall(MessagingCenterCallAndReturnViewModel sender)
        {
            Debug.WriteLine("Handling Call from ViewModel");
            var count = ReportStackLayout.Children.Count;
            ReportStackLayout.Children.Add(new Label { Text = $"Handling Call from ViewModel {count}" });
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            MessagingCenter.Subscribe<MessagingCenterCallAndReturnViewModel>(this, "CallViewFromViewModel", HandleCall);
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();

            MessagingCenter.Unsubscribe<MessagingCenterCallAndReturnViewModel>(this, "CallViewFromViewModel");
        }
    }
}
