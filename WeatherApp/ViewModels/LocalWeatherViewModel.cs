using System;
using System.Threading.Tasks;
using MvvmHelpers;
using WeatherApp.Models;
using WeatherApp.Services;

namespace WeatherApp.ViewModels
{
    public class LocalWeatherViewModel : BaseViewModel
    {
        IWeatherApiService weatherApi;

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

            Task.WhenAll(InitializeAsync());
        }

        public async Task InitializeAsync()
        {
            weatherApi = new WeatherApiService();

            try
            {
                IsBusy = true;

                WeatherModel weather = await weatherApi.GetData<WeatherModel>(string.Format(Endpoints.CurrentWeatherEndpoint,"Pruszków", AppSettings.WeatherFormat));
            }
            catch
            {
                throw;
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}
