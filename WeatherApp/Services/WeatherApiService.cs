using System;
using System.Threading.Tasks;
using WeatherApp.Models;

namespace WeatherApp.Services
{
    public class WeatherApiService : IWeatherApiService
    {
        public Task<Weather> GetWeatherAsync(string city)
        {
            throw new NotImplementedException();
        }
    }
}
