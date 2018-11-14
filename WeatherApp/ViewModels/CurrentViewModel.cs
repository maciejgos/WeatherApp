using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using MvvmHelpers;
using WeatherApp.Models;
using WeatherApp.Services;

namespace WeatherApp.ViewModels
{
    public class CurrentViewModel : BaseViewModel
    {
        private readonly IApiService _service;
        
        private int _temperature;
        private string _city;
        private string _unit;
        private IEnumerable<ForecastLineViewModel> _weeklyForecast;

        public int Temperature { get => _temperature; set => SetProperty(ref _temperature, value); }
        public string City { get => _city; set => SetProperty(ref _city, value); }
        public string Unit { get => _unit; set => SetProperty(ref _unit, value); }
        public IEnumerable<ForecastLineViewModel> WeeklyForecast { get => _weeklyForecast; set => SetProperty(ref _weeklyForecast, value); }

        public CurrentViewModel()
        {
            var httpClient = new HttpClient
            {
                BaseAddress = new Uri(AppSettings.WeatherApiEndpoint)
            };
            _service = new ApiService(httpClient);
        }

        public async Task InitializeAsync()
        {
            var weatherModel = await _service.GetCurrentWeatherAsync("Pruszków");
            MapModelToViewModel(weatherModel);
        }

        private void MapModelToViewModel(WeatherModel weatherModel)
        {
            City = weatherModel.Name;
            Temperature = weatherModel.Main.Temp;
            Unit = "C";
        }
    }

    public class ForecastLineViewModel : BaseViewModel
    {
        private string _day;
        private int _temperature;
        
        public string Day { get => _day; set => SetProperty(ref _day, value); }
        public int Temperature { get => _temperature; set => SetProperty(ref _temperature, value); }
    }
}