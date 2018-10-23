using System;
using System.Threading.Tasks;
using WeatherApp.Models;

namespace WeatherApp.Services
{
    public class ApiManager : IApiManager
    {
        readonly IWeatherService weatherService;

        public ApiManager(IWeatherService weatherService)
        {
            this.weatherService = weatherService;
        }

        public async Task<OperationResult<WeatherModel>> GetCurrentWeatherAsync(string city)
        {
            return await weatherService.GetCurrentWeatherAsync(city);
        }
    }
}
