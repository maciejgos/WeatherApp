using System;
using Prism;
using Prism.Ioc;
using Prism.Unity;
using WeatherApp.Application.Navigation.Controls;
using WeatherApp.Application.Networking;
using WeatherApp.Features.Local.ViewModels;
using WeatherApp.Features.Local.Views;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace WeatherApp
{
    public partial class App : PrismApplication
    {
        // Default constructor required by XAML Preview
        public App(){}

        public App(IPlatformInitializer initializer) : base(initializer) { }

        protected override void OnInitialized()
        {
            InitializeComponent();

            NavigationService.NavigateAsync(new Uri("/WeatherAppTabbedPage?selectedTab=LocalWeatherPage", UriKind.Absolute));
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.Register<IApiService, ApiService>();

            containerRegistry.RegisterForNavigation<WeatherAppNavigationPage>();
            containerRegistry.RegisterForNavigation<WeatherAppTabbedPage>();

            containerRegistry.RegisterForNavigation<LocalWeatherPage, LocalWeatherPageViewModel>();
        }
    }
}
