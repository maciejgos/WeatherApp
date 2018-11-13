using System.Net.Http;
using System.Threading.Tasks;
using Refit;
using WeatherApp.Models;

namespace WeatherApp.Services
{
    public class ApiService : IApiService
    {
        private readonly IApiService _service;

        public ApiService(HttpClient httpClient)
        {
            _service = RestService.For<IApiService>(httpClient);
        }

        public async Task<WeatherModel> GetCurrentWeatherAsync(string city)
        {
            return await _service.GetCurrentWeatherAsync(city);
        }
    }
}