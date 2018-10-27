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

        public ApiManager(HttpClient httpClient)
        {
            this.weatherService = RestService.For<IWeatherService>(httpClient);
        }

        public async Task<OperationResult<WeatherModel>> GetCurrentWeatherAsync(string city)
        {
            OperationResult<WeatherModel> operationResult = null;

            try
            {
                if (AppSettings.UseMocks)
                {
                    if (city == "NetworkConnectivity")
                    {
                        throw new ConnectivityException();
                    }
                }
                else if(Xamarin.Essentials.Connectivity.NetworkAccess == Xamarin.Essentials.NetworkAccess.Local)
                {
                    throw new ConnectivityException();
                }

                var response = await weatherService.GetCurrentWeatherAsync(city: city, appid: AppSettings.UseMocks ? "000000" : AppSettings.WeatherApiKey, units: AppSettings.WeatherUnits);
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
