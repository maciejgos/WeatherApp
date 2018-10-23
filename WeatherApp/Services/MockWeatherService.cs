using System;
using System.Threading.Tasks;
using WeatherApp.Models;

namespace WeatherApp.Services
{
    public class MockWeatherService : IWeatherService
    {
        readonly WeatherModel weatherModel;

        public MockWeatherService()
        {
            weatherModel = new WeatherModel
            {
                Name = "Pruszków"
            };
        }

        public async Task<OperationResult<WeatherModel>> GetCurrentWeatherAsync(string city)
        {
            OperationResult<WeatherModel> operationResult = OperationResult<WeatherModel>.CreateSuccessResult(result: weatherModel);

            await Task.Delay(1000);

            return operationResult;
        }
    }
}
