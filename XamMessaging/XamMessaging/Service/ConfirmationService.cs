using System.Threading.Tasks;
using Acr.UserDialogs;
using Xamarin.Forms;
using XamMessaging.Service;

[assembly: Dependency(typeof(ConfirmationService))]
namespace XamMessaging.Service
{
    public class ConfirmationService : IConfirmationService
    {
        public async Task<bool> AskConfirmation(string message)
        {
            var config = new ConfirmConfig()
            {
                Title = "Confirmation",
                Message = message,
                OkText = "Yes",
                CancelText = "No",
            };
            return await UserDialogs.Instance.ConfirmAsync(config);
        }
    }
}
