using System;
using System.Diagnostics;
using System.Net.Http;
using System.Threading.Tasks;

namespace WeatherApp.Application.Networking
{
    public class ApiService : IApiService
    {
        readonly HttpClient httpClient;

        public ApiService()
        {
            HttpClientHandler handler = new HttpClientHandler();
            httpClient = new HttpClient(handler)
            {
                BaseAddress = new Uri(Constants.BaseUrl)
            };
        }

        public async Task<HttpResponseMessage> GetCurrentWeatherAsync(string city)
        {
            HttpResponseMessage response = await httpClient.GetAsync(new Uri($"/data/2.5/weather?q={city}&units=metric&APPID={Constants.AppID}", UriKind.Relative));
            if (response.IsSuccessStatusCode)
            {
                string responseJson = await response.Content.ReadAsStringAsync();
                Debug.WriteLine($"[WeatherApp] - [Endpoint] - {nameof(GetCurrentWeatherAsync)} - {responseJson}");
            }

            return response;
        }
    }
}
