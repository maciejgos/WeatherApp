using System;
using System.Threading.Tasks;
using WeatherApp.Models;

namespace WeatherApp.Services
{
    public interface IWeatherApiService
    {
        Task<WeatherModel> GetWeatherAsync(string city);
    }
}
