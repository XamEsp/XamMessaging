using System;

namespace XamMessaging.Page
{
    public partial class MainPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void MessagingCenterButtonClicked(object sender, EventArgs e)
        {
            var page = new MessagingCenterCallAndReturnPage();
            await Navigation.PushAsync(page);
        }

        private async void EventHandlerButtonClicked(object sender, EventArgs e)
        {
            var page = new EventHandlerCallAndReturnPage();
            await Navigation.PushAsync(page);
        }


        private async void ServiceInjectionButtonClicked(object sender, EventArgs e)
        {
            var page = new ServiceInjectionCallAndReturnPage();
            await Navigation.PushAsync(page);
        }

    }
}
