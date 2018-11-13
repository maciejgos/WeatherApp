using System.Threading.Tasks;
using Refit;
using WeatherApp.Models;

namespace WeatherApp.Services
{
    public interface IApiService
    {
        [Get("/weather?q={city}&appid=0d039917e0d2820c0dc9ab4f95cf10d8&units=metric")]
        Task<WeatherModel> GetCurrentWeatherAsync(string city);
    }
}