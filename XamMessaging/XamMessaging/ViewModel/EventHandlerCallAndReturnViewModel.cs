using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Windows.Input;
using Xamarin.Forms;

namespace XamMessaging.ViewModel
{
    public class EventHandlerCallAndReturnViewModel
    {
        public ICommand ExecuteSomeOperationCommand => new Command(() =>
            {
                Debug.WriteLine("Sending Message to the View");
                AskForConfirmation?.Invoke();
            });

        public Action AskForConfirmation { get; set; }

        public ObservableCollection<string> Operations { get; set; } = new ObservableCollection<string>();

        public void DoSomething()
        {
            Operations.Add($"Handling Operation {Operations.Count}");
        }
    }
}
