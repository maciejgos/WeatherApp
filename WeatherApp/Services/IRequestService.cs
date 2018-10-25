using System;
using System.Threading.Tasks;

namespace WeatherApp.Services
{
    [Obsolete]
    public interface IRequestService
    {
        [Obsolete]
        Task<TResult> GetAsync<TResult>(string uri);
    }
}
