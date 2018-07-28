using System;

namespace XamMessaging
{
    public partial class MainPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            var page = new MessagingCenterCallAndReturnPage();
            await Navigation.PushAsync(page);
        }
    }
}
