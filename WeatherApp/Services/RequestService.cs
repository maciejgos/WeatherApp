using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace WeatherApp.Services
{
    [Obsolete]
    public class RequestService : IRequestService
    {
        [Obsolete]
        public async Task<TResult> GetAsync<TResult>(string uri)
        {
            var httpClient = CreateHttpClient();
            var response = await httpClient.GetAsync(uri);

            await HandleResponse(response);

            var serialized = await response.Content.ReadAsStringAsync();
            var result = await Task.Run(() => JsonConvert.DeserializeObject<TResult>(serialized));

            return result;
        }

        private async Task HandleResponse(HttpResponseMessage response)
        {
            if (response.IsSuccessStatusCode)
            {
                return;
            }

            var content = await response.Content.ReadAsStringAsync();
            if (response.StatusCode == System.Net.HttpStatusCode.Forbidden)
            {
                throw new Exception(content);
            }

            throw new HttpRequestException(content);
        }

        private HttpClient CreateHttpClient()
        {
            var httpClient = new HttpClient();

            httpClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

            return httpClient;
        }
    }
}
