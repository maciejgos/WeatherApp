using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Refit;
using WeatherApp.Exceptions;
using WeatherApp.Models;

namespace WeatherApp.Services
{
    public class ApiManager : IApiManager
    {
        readonly IWeatherService weatherService;

        public ApiManager()
        {
            this.weatherService = RestService.For<IWeatherService>(AppSettings.WeatherApiKey);
        }

        public ApiManager(IWeatherService weatherService)
        {
            this.weatherService = weatherService;
        }

        public async Task<OperationResult<WeatherModel>> GetCurrentWeatherAsync(string city)
        {
            OperationResult<WeatherModel> operationResult = null;

            try
            {
                var response = await weatherService.GetCurrentWeatherAsync(city);
                response.EnsureSuccessStatusCode();

                if (response.IsSuccessStatusCode)
                {
                    string serialized = await response.Content.ReadAsStringAsync();
                    var weatherModel = await Task.Run(() => JsonConvert.DeserializeObject<WeatherModel>(serialized));

                    operationResult = OperationResult<WeatherModel>.CreateSuccessResult(result: weatherModel);
                }
            }
            catch (ConnectivityException cx)
            {
                operationResult = OperationResult<WeatherModel>.CreateFailResult(exception: cx);
            }
            catch(HttpRequestException rx)
            {
                operationResult = OperationResult<WeatherModel>.CreateFailResult(exception: rx);
            }
            catch(Exception ex)
            {
                operationResult = OperationResult<WeatherModel>.CreateFailResult(exception: ex);
            }

            return operationResult;
        }
    }
}
