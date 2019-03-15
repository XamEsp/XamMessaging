using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Windows.Input;
using Xamarin.Forms;
using XamMessaging.Service;

namespace XamMessaging.ViewModel
{
   public class ServiceInjectionCallAndReturnViewModel : BaseViewModel
   {

      private readonly IConfirmationService _confirmationService;
      public ICommand ExecuteSomeOperationCommand { get; set; }

      public ServiceInjectionCallAndReturnViewModel() : this(DependencyService.Get<IConfirmationService>())
      {
      }

      public ServiceInjectionCallAndReturnViewModel(IConfirmationService confirmationService)
      {
         _confirmationService = confirmationService;
         ExecuteSomeOperationCommand = new Command(DoSomething);
      }

      public bool ButtonIsVisible => _isInitialized;

      private bool _isInitialized;

      private string _message = "default value";
      public string Message
      {
         get
         {
            if (!_isInitialized)
               return "Not initialized";
            else
               return _message;
         }
         set => SetValue(ref _message, value);
      }

      public void Initialize(string message)
      {
         Message = message;
         _isInitialized = true;
         OnPropertyChanged("ButtonIsVisible");
      }

      public ObservableCollection<string> Operations { get; set; } = new ObservableCollection<string>();

      public async void DoSomething()
      {
         if ( !_isInitialized )
         {
            throw new Exception("Not initialized");
         }

         Debug.WriteLine("Handling Call in the ViewModel");
         if (await _confirmationService.AskConfirmation(Message))
         {
            Operations.Add($"You said yes! {Operations.Count}");
         }
      }

   }
}
