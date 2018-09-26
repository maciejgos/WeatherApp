using System.Net.Http;
using Newtonsoft.Json;
using WeatherApp.Application.Dtos;

namespace WeatherApp.Application.Extensions
{
    public static class HttpResponseMessageExtensions
    {
        public static T MapToDto<T>(this HttpResponseMessage httpResponse) where T : BaseDto
        {
            var jsonResponse = httpResponse?.Content?.ReadAsStringAsync().Result;
            var result = JsonConvert.DeserializeObject<T>(jsonResponse);

            return result;
        }
    }
}
