using System;
using System.Threading.Tasks;
using WeatherApp.Models;

namespace WeatherApp.Services
{
    public interface IApiManager
    {
        Task<OperationResult<WeatherModel>> GetCurrentWeatherAsync(string city);
    }
}
