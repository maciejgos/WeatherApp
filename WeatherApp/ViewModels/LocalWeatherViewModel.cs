using MvvmHelpers;

namespace WeatherApp.ViewModels
{
    public class LocalWeatherViewModel : BaseViewModel
    {
        public string City
        {
            get => "Pruszków";
        }

        public string Weather
        {
            get => "Słonecznie";
        }

        public string Temp
        {
            get => "20,5";
        }

        public LocalWeatherViewModel()
        {
            Title = "Home";
            Icon = "";
        }
    }
}
