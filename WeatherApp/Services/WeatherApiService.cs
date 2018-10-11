using System;
using System.Threading.Tasks;
using WeatherApp.Models;

namespace WeatherApp.Services
{
    public class WeatherApiService : IWeatherApiService
    {
        public Task<T> GetData<T>(string uri)
        {
            throw new NotImplementedException();
        }
    }
}
