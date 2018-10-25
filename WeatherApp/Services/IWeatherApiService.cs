using System;
using System.Threading.Tasks;
using WeatherApp.Models;

namespace WeatherApp.Services
{
    [Obsolete]
    public interface IWeatherApiService
    {
        [Obsolete]
        Task<WeatherModel> GetCurrentAsync(string city);
    }
}
