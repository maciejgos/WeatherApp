using System;
using System.Net.Http;

namespace WeatherApp.Services
{
    public class WeatherHttpClient
    {
        static HttpClient instance;
        public static HttpClient Instance => instance ?? (instance = new HttpClient { BaseAddress = new Uri(AppSettings.WeatherEndpoint) });
    }
}
