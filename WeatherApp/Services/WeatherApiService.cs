using System;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;
using WeatherApp.Models;

namespace WeatherApp.Services
{
    [Obsolete]
    public class WeatherApiService : IWeatherApiService
    {
        readonly IRequestService requestService;

        [Obsolete]
        public WeatherApiService(IRequestService requestService)
        {
            this.requestService = requestService;
        }

        [Obsolete]
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
