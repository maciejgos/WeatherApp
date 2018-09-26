using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace WeatherApp.Application.Networking
{
    public interface IApiService
    {
        Task<HttpResponseMessage> GetCurrentWeatherAsync(string city);
    }
}
