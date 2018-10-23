using System;
using System.Threading.Tasks;
using WeatherApp.Models;

namespace WeatherApp.Services
{
    public interface IWeatherService
    {
        Task<OperationResult<WeatherModel>> GetCurrentWeatherAsync(string city);
    }
}
