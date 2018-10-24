using System.Net.Http;
using System.Threading.Tasks;

namespace WeatherApp.Services
{
    public interface IWeatherService
    {
        Task<HttpResponseMessage> GetCurrentWeatherAsync(string city);
    }
}
