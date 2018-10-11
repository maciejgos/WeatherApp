using System;
using System.Diagnostics;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using WeatherApp.Models;

namespace WeatherApp.Services
{
    public class WeatherApiService : IWeatherApiService
    {
        readonly IRequestService requestService;

        public WeatherApiService(IRequestService requestService)
        {
            this.requestService = requestService;
        }

        public async Task<WeatherModel> GetCurrentAsync(string city)
        {
            var uri = CreateUri(city);
            var currentWeather = await requestService.GetAsync<WeatherModel>(uri.ToString());

            return currentWeather;
        }

        private Uri CreateUri(string city)
        {
            UriBuilder uriBuilder = new UriBuilder(AppSettings.WeatherEndpoint);
            uriBuilder.Path = Path.Combine(uriBuilder.Path, Endpoints.CurrentWeatherEndpoint);
            uriBuilder.Query = string.Concat($"?q={city}", $"&units={AppSettings.WeatherUnits}", $"&appid={AppSettings.WeatherApiKey}");

            var uri = uriBuilder.Uri;

            Debug.WriteLine(uri.ToString());

            return uri;
        }


    }
}
