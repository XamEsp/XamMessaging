using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamMessaging.Service;

[assembly: XamlCompilation (XamlCompilationOptions.Compile)]
namespace XamMessaging.Page
{
	public partial class App : Application
	{
		public App ()
		{
			InitializeComponent();

            DependencyService.Register<IConfirmationService>();

			MainPage = new NavigationPage(new MainPage());
		}
	}
}
