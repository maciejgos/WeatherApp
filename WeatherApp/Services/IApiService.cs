using System.Threading.Tasks;
using WeatherApp.Models;

namespace WeatherApp.Services
{
    public interface IApiService
    {
        Task<WeatherModel> GetCurrentWeatherAsync(string city);
    }
}