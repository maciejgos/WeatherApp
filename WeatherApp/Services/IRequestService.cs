using System.Threading.Tasks;

namespace WeatherApp.Services
{
    public interface IRequestService
    {
        Task<TResult> GetAsync<TResult>(string uri);
    }
}
