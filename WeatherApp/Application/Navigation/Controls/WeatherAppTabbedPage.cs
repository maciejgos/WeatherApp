using System;
using WeatherApp.Features.Favorites.Views;
using WeatherApp.Features.Local.Views;
using WeatherApp.Features.Settings.Views;
using Xamarin.Forms;

namespace WeatherApp.Application.Navigation.Controls
{
    public class WeatherAppTabbedPage : TabbedPage
    {
        public WeatherAppTabbedPage()
        {
            var localWeatherPage = new LocalWeatherPage();
            var favoritesPage = new FavoritesPage();
            var settingsPage = new SettingsPage();

            Children.Add(new WeatherAppNavigationPage(localWeatherPage) { Title = "Local", Icon = "Local" });
            Children.Add(new WeatherAppNavigationPage(favoritesPage) { Title = "Favorites", Icon = "Favorites" });
            Children.Add(new WeatherAppNavigationPage(settingsPage) { Title = "Settings", Icon = "Settings" });
        }
    }
}
