using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using WeatherApp.Exceptions;
using WeatherApp.Models;

namespace WeatherApp.Services
{
    public class MockWeatherService : IWeatherService
    {
        readonly WeatherModel weatherModel;
        readonly string json;

        public MockWeatherService()
        {
            weatherModel = new WeatherModel
            {
                Name = "Pruszków"
            };

            json = JsonConvert.SerializeObject(weatherModel);
        }

        public async Task<HttpResponseMessage> GetCurrentWeatherAsync(string city)
        {
            await Task.Delay(1000);

            if (city == "NetworkConnectivity")
            {
                throw new ConnectivityException();
            }

            HttpResponseMessage httpResponse = new HttpResponseMessage
            {
                StatusCode = System.Net.HttpStatusCode.OK,
                Content = new StringContent(json, System.Text.Encoding.UTF8, "application/json")
            };

            return httpResponse;
        }
    }
}
