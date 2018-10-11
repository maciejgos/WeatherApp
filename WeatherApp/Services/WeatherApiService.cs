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
        public async Task<WeatherModel> GetCurrentAsync(string city)
        {
            var httpClient = CreateHttpClient();
            var uri = CreateUri(city);
            var response = await httpClient.GetAsync(uri);

            await HandleResponse(response);

            var serialized = await response.Content.ReadAsStringAsync();
            var result = await Task.Run(() => JsonConvert.DeserializeObject<WeatherModel>(serialized));

            return result;
        }

        private async Task HandleResponse(HttpResponseMessage response)
        {
            if (response.IsSuccessStatusCode)
            {
                return;
            }

            var content = await response.Content.ReadAsStringAsync();
            if (response.StatusCode == System.Net.HttpStatusCode.Forbidden)
            {
                throw new Exception(content);
            }

            throw new HttpRequestException(content);
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

        private HttpClient CreateHttpClient()
        {
            var httpClient = new HttpClient();

            httpClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

            return httpClient;
        }
    }
}
