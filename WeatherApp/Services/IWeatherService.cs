using System.Net.Http;
using System.Threading.Tasks;
using Refit;

namespace WeatherApp.Services
{
    public interface IWeatherService
    {
        [Get("weather?q={city}&appid={appid}&units={units}")]
        Task<HttpResponseMessage> GetCurrentWeatherAsync(string city, string appid = "000000", string units = "metric");
    }
}
