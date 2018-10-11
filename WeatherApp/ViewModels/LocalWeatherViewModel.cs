using System;
using System.Linq;
using System.Threading.Tasks;
using MvvmHelpers;
using WeatherApp.Models;
using WeatherApp.Services;

namespace WeatherApp.ViewModels
{
    public class LocalWeatherViewModel : BaseViewModel
    {
        IWeatherApiService weatherApi;

        string city;
        string weather;
        int temp;

        public string City
        {
            get => city;
            set => SetProperty(ref city, value);
        }

        public string Description
        {
            get => weather;
            set => SetProperty(ref weather, value);
        }

        public int Temp
        {
            get => temp;
            set => SetProperty(ref temp, value);
        }

        public LocalWeatherViewModel(IWeatherApiService weatherApi)
        {
            Title = "Home";
            Icon = "";

            this.weatherApi = weatherApi;

            Task.WhenAll(InitializeAsync());
        }

        public async Task InitializeAsync()
        {
            try
            {
                IsBusy = true;

                WeatherModel weatherData = await weatherApi.GetCurrentAsync(city: "Pruszków");

                City = weatherData.Name;
                Description = weatherData.Weather.FirstOrDefault().Description;
                Temp = weatherData.Main.Temp;
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
