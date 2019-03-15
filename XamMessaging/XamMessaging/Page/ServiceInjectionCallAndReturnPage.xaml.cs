using Xamarin.Forms.Xaml;
using XamMessaging.ViewModel;

namespace XamMessaging.Page
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ServiceInjectionCallAndReturnPage
    {
        public ServiceInjectionCallAndReturnPage()
        {
            InitializeComponent();
        }

       protected override void OnAppearing()
       {
          base.OnAppearing();

          var context = (ServiceInjectionCallAndReturnViewModel) BindingContext;
          context.Initialize("Hello MVPs");
       }
    }
}
