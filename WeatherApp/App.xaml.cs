using WeatherApp.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace WeatherApp
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new CurrentPage();
        }

        protected override void OnStart()
        {
            base.OnStart();
            
            // Set app to run on device mode.
            AppSettings.IsInDesignMode = false;
        }
    }
}
