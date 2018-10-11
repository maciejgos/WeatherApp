using System.Threading.Tasks;

namespace WeatherApp.Services
{
    public interface IWeatherApiService
    {
        Task<T> GetData<T>(string uri);
    }
}
