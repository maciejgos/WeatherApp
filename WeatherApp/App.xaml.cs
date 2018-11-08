using System;
using WeatherApp.ViewModels;
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
            BuildDependencies();

            MainPage = new CurrentPage();
        }

        public void BuildDependencies()
        {
            //Locator.Instance.Build();
        }
    }
}
