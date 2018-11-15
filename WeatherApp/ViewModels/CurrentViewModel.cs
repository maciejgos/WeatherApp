using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using WeatherApp.Models;
using WeatherApp.ViewModels.Base;
using Xamarin.Essentials;

namespace WeatherApp.ViewModels
{
    public class CurrentViewModel : BaseViewModel
    {
        private double _temperature;
        private string _city;
        private string _unit;
        private IEnumerable<ForecastLineViewModel> _weeklyForecast;

        public double Temperature { get => _temperature; set => SetProperty(ref _temperature, value); }
        public string City { get => _city; set => SetProperty(ref _city, value); }
        public string Unit { get => _unit; set => SetProperty(ref _unit, value); }
        public IEnumerable<ForecastLineViewModel> WeeklyForecast { get => _weeklyForecast; set => SetProperty(ref _weeklyForecast, value); }

        public async Task InitializeAsync()
        {
            try
            {
                var location = await Geolocation.GetLocationAsync();
                var placemarks = await Geocoding.GetPlacemarksAsync(location);

                var city = placemarks.FirstOrDefault().Locality;

                Debug.WriteLine($"City: {city}");

                var weatherModel = await _service.GetCurrentWeatherAsync(city);
                MapModelToViewModel(weatherModel);
            }
            catch (FeatureNotSupportedException exception)
            {
                Debug.WriteLine(exception);
                throw;
            }
            catch (PermissionException exception)
            {
                Debug.WriteLine(exception);
                throw;
            }
            catch (Exception exception)
            {
                Debug.WriteLine(exception);
                throw;
            }
        }

        private void MapModelToViewModel(WeatherModel model)
        {
            City = model.Name;
            Temperature = model.Main.Temp;
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